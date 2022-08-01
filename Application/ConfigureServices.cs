using Application.Contracts.Commands;
using Application.Contracts.Queries;
using Application.Handlers.Commands;
using Application.Handlers.Queries;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application {

    public static class ConfigureServices {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration) {
            services.AddScoped<IChargeMachineCommand, ChargeMachineCommand>();
            services.AddScoped<IChargeMachineQuery, ChargeMachineQuery>();

            return services;
        }
    }

}