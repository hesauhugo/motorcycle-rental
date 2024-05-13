using MotorcycleRental.Core.Repositories;
using MotorcycleRental.Core.Services;
using MotorcycleRental.Infrastructure.Auth;
using MotorcycleRental.Infrastructure.Persistence.Repositories;

namespace MotorcycleRental.API.DependencyInjection
{
    public static class RepositoriesDependencyInjection
    {
        public static void AddRepositoriesDependencyInjection(this IServiceCollection services)
        {

            services.AddScoped(typeof(IMotorcycleRepository), typeof(MotorcycleRepository));
            services.AddScoped(typeof(IAuthService), typeof(AuthService));
            services.AddScoped(typeof(IUserRepository), typeof(UserRepository));
            services.AddScoped(typeof(ICustomerRepository),typeof(CustomerRepository));
        }
    }
}
