
using Smc.Domain.Commands;
using Smc.Domain.Interfaces;
using Smc.Infra.Data.Repository;
using Smc.Application.Interfaces;
using Smc.Application.Services;
using FluentValidation.Results;
using Microsoft.Extensions.DependencyInjection;
using Smc.Infra.Data;
using Microsoft.Extensions.Configuration;
using Smc.Infra.Data.Session;

namespace Smc.Infra.CrossCutting.IoC
{
    public static class NativeInjectorBootStrapper

    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services, IConfiguration configuration)
        {

            // Application
            services.AddTransient<IUserAppService, UserAppService>();
            services.AddTransient<IPersonAppService, PersonAppService>();

            // Infra - Data
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IPersonRepository, PersonRepository>();

            services.AddScoped(x => new DbSession(configuration.GetConnectionString("DefaultConnection")));
            services.AddTransient<IUnitOfWork, UnitOfWork>();

        }
    }
}
