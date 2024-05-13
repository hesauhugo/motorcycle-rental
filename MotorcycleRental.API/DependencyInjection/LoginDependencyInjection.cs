using Serilog;

namespace MotorcycleRental.API.DependencyInjection
{
    public static class LoginDependencyInjection
    {
        public static void AddLoginDependencyInjection(this IServiceCollection services,IConfiguration configuration)
        {

            Log.Logger = new LoggerConfiguration()
                .ReadFrom
                .Configuration(configuration)
                .CreateLogger();

            
        }
    }
}
