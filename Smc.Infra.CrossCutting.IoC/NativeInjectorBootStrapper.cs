
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
            services.AddScoped<IUserAppService, UserAppService>();
            services.AddScoped<IPersonAppService, PersonAppService>();

            // Infra - Data
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPersonRepository, PersonRepository>();

            services.AddScoped<IUserAppService, UserAppService>();

            //services.AddScoped<DbSession>(cnn => configuration.GetConnectionString("DefaultConnection"));
            services.AddScoped<DbSession>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

        }
    }
}
