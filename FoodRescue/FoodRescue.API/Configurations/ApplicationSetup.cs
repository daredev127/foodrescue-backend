using FastExpressionCompiler;
using FluentValidation;
using Mapster;
using FoodRescue.Application.Common;
using FoodRescue.Application.Features.AccountManagement.User.CreateUserAccount;
using FoodRescue.Application.Features.AccountManagement.User.GetUserAccounts;
using FoodRescue.Application.Features.Auth;
using FoodRescue.Application.Features.Auth.User;
using FoodRescue.Application.MappingConfig;
using FoodRescue.Infrastructure.Persistence.Database;
using MassTransit;
using MassTransit.NewIdProviders;
using System.Reflection;

namespace FoodRescue.API.Configurations
{

    public static class ApplicationSetup
    {
        public static IServiceCollection AddApplicationSetup(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddScoped<IContext, DatabaseContext>();
            NewId.SetProcessIdProvider(new CurrentProcessIdProvider());
            ApplyAllMappingConfigFromAssembly();
            TypeAdapterConfig.GlobalSettings.Compiler = exp => exp.CompileFast();

            services.AddScoped<IPasswordUtils, PasswordUtils>();
            services.AddScoped<IJwtUtils, JwtUtils>();

            services.AddScoped<IGetUserAccountsQueryHandler, GetUserAccountsQueryHandler>();
            services.AddScoped<ICreateUserAccountCommandHandler, CreateUserAccountCommandHandler>();

            services.AddScoped<ILoginCommandHandler, LoginCommandHandler>();
            

            return services;
        }

        private static IEnumerable<Type> GetTypesWithInterface<TInterface>(Assembly asm)
        {
            var it = typeof(TInterface);
            return asm.GetTypes().Where(x => it.IsAssignableFrom(x) && x is { IsInterface: false, IsAbstract: false });
        }

        private static void ApplyAllMappingConfigFromAssembly()
        {
            var mappers = GetTypesWithInterface<IMappingConfig>(typeof(IMappingConfig).Assembly);
            foreach (var mapperType in mappers)
            {
                var instance = (IMappingConfig)Activator.CreateInstance(mapperType)!;
                instance.ApplyConfig();
            }
        }
    }
}
