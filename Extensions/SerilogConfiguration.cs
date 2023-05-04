using Serilog;

namespace Learn.Serilog.Extensions
{
    public static class SerilogConfiguration
    {
        public static void LoggingService(this WebApplicationBuilder builder, IServiceCollection services)
        {
            builder.Host.UseSerilog((context , services , configuration) => 
            configuration.ReadFrom.Configuration(context.Configuration));
            services.AddLogging();
        }
    }
}
