using FoodRescue.Application.Dtos;

namespace FoodRescue.Application.Features.AccountManagement.User.CreateUserAccount
{
    public interface ICreateUserAccountCommandHandler
    {
        Task<ResponseBaseDto> Handle(CreateUserAccountCommand request);
    }
}
