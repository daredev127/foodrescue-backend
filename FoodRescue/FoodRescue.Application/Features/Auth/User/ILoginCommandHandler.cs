using FoodRescue.Application.Dtos;

namespace FoodRescue.Application.Features.Auth.User
{
    public interface ILoginCommandHandler
    {
        Task<ResponseBaseDto> Handle(LoginCommand request);
    }
}
