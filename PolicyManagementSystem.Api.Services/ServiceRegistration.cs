namespace PolicyManagementSystem.Api.Services
{
    using AutoMapper;
    using Microsoft.Extensions.DependencyInjection;
    using PolicyManagementSystem.Api.Services.Services;

    public static class ServiceRegistration
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ServiceRegistration));
            services.AddTransient<IPolicyService, PolicyService>();
        }
    }
}
