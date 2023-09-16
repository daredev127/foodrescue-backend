using Mapster;
using FoodRescue.Application.Common;
using FoodRescue.Application.Dtos;
using FoodRescue.Domain.Repositories;

namespace FoodRescue.Application.Features.AccountManagement.User.GetUserAccounts
{
    public class GetUserAccountsQueryHandler : IGetUserAccountsQueryHandler
    {
        private readonly IUserRepository _userRepository;

        public GetUserAccountsQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ResponseBaseDto> Handle(GetUserAccountsQuery request)
        {
            var users = await _userRepository.GetUsersBySearch(request.Search);
            var userDto = users.Adapt<IEnumerable<UserViewModel>>();
            return new ResponseBaseDto { Status = "OK", Message = "Success", Data = userDto };
        }
    }
}
