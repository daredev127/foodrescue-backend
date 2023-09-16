using FoodRescue.Application.Dtos;

namespace FoodRescue.Application.Features.AccountManagement.User.GetUserAccounts
{
    public interface IGetUserAccountsQueryHandler
    {
        Task<ResponseBaseDto> Handle(GetUserAccountsQuery request);
    }
}
