namespace Domain.DependencyInjection
{
    using Domain.Interfaces;
    using Domain.Services;
    using Microsoft.Extensions.DependencyInjection;
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    public static class DependencyInjection
    {
        public static IServiceCollection AddDomainDependencies(this IServiceCollection services)
        {
            services.AddDomainServices();

            return services;
        }

        private static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            // Domain Services
            services.AddTransient<IClientService, ClientService>();
            services.AddTransient<IIntegrationService, IntegrationService>();
            return services;
        }
    }
}