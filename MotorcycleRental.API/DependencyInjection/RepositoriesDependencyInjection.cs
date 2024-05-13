using MotorcycleRental.Core.Repositories;
using MotorcycleRental.Core.Services;
using MotorcycleRental.Core.Storage.LocalStorage;
using MotorcycleRental.Infrastructure.Auth;
using MotorcycleRental.Infrastructure.Persistence.Repositories;
using MotorcycleRental.Infrastructure.Storage.Local;

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

            //storage
            services.AddTransient(typeof(ILocalStorage), typeof(LocalStorage));
        }
    }
}
