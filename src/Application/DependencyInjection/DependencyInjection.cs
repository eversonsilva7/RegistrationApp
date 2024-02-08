namespace Application.DependencyInjection
{
    using Application.Interfaces;
    using Application.Services;
    using Domain.DependencyInjection;
    using Infrastructure.DependencyInjection;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddApplicationServices();

            services.AddDomainDependencies();

            services.AddInfrastructureDependencies(configuration);

            services.AddInfrastructure();

            return services;
        }

        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            return services;
        }

        private static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<IClientProcessor, ClientProcessor>();
            services.AddScoped<IJobProcessor, JobProcessor>();
            return services;
        }
    }
}
