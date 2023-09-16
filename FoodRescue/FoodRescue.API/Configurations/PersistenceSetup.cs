using FoodRescue.Domain.Repositories;
using FoodRescue.Infrastructure.Persistence.Database;
using FoodRescue.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FoodRescue.API.Configurations
{
    public static class PersistanceSetup
    {
        public static IServiceCollection AddPersistenceSetup(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<DatabaseContext>(o =>
            {
                o.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IDonationRepository, DonationRepository>();

            return services;
        }
    }
}
