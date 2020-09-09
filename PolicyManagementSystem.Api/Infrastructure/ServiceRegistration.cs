namespace PolicyManagementSystem.Api.Infrastructure
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using PolicyManagementSystem.Api.Core.Model;
    using PolicyManagementSystem.Api.Core.Repository;

    public static class ServiceRegistration
    {
        public static void AddDbInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<CosmosDbOptions>(options => configuration.GetSection("Database:CosmosDb").Bind(options));

            services.AddTransient<IPolicyRepository, PolicyRepository>();
        }
    }
}
