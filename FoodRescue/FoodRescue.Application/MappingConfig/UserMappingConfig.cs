using FoodRescue.Application.Common;
using FoodRescue.Domain.Entities;
using Mapster;

namespace FoodRescue.Application.MappingConfig
{
    public class UserMappingConfig : IMappingConfig
    {
        public void ApplyConfig()
        {
            TypeAdapterConfig<User, UserViewModel>
                .NewConfig()
                .Map(dest => dest.Organization, src => src.Organization.Name);
        }
    }
}
