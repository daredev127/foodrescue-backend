using FoodRescue.Application.Dtos;
using FoodRescue.Application.Features.Auth;
using FoodRescue.Domain.Repositories;
using Mapster;

namespace FoodRescue.Application.Features.AccountManagement.User.CreateUserAccount
{
    public class CreateUserAccountCommandHandler : ICreateUserAccountCommandHandler
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordUtils _passwordUtil;
        public CreateUserAccountCommandHandler(IUserRepository userRepository, IPasswordUtils passwordUtil)
        {
            _userRepository = userRepository;
            _passwordUtil = passwordUtil;
        }

        public async Task<ResponseBaseDto> Handle(CreateUserAccountCommand request)
        {
            if (await _userRepository.FindByUsername(request.Username) != null)
            {
                return new ResponseBaseDto { Status = "Error", Message = "Username already exists" };
            }

            var newUser = request.Adapt<Domain.Entities.User>();
            newUser.Password = _passwordUtil.GenerateHash(request.Password);
            newUser.CreatedDate = DateTime.Now;
            newUser.CreatedBy = "Admin";
            var user = await _userRepository.AddAsync(newUser);
            return new ResponseBaseDto { Status = "OK", Message = "Success", Data = user };
        }
    }
}

