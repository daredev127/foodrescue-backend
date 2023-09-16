using FoodRescue.Domain.Entities;

namespace FoodRescue.Domain.Repositories
{
    public interface IUserRepository : IAsyncRepository<User>
    {
        Task<User> FindByUsername(string username);
        Task<IEnumerable<User>> GetUsersBySearch(string search);
    }
}
