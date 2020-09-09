namespace PolicyManagementSystem.Api.ExceptionHandler
{
    using Microsoft.AspNetCore.Builder;
    
    public static class ExceptionHandlerExtension
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionHandler>();
        }
    }
}
