using MotorcycleRental.Core.Repositories;
using MotorcycleRental.Core.Services;
using MotorcycleRental.Core.Storage.LocalStorage;
using MotorcycleRental.Infrastructure.Auth;
using MotorcycleRental.Infrastructure.Persistence.Repositories;
using MotorcycleRental.Infrastructure.Services;
using MotorcycleRental.Infrastructure.Storage.Local;

namespace MotorcycleRental.API.DependencyInjection
{
    public static class RepositoriesDependencyInjection
    {
        public static void AddRepositoriesDependencyInjection(this IServiceCollection services)
        {

            services.AddScoped(typeof(IMotorcycleRepository), typeof(MotorcycleRepository));
            services.AddScoped(typeof(IAuthUserService), typeof(AuthUserService));
            services.AddScoped(typeof(IAuthCustomerService), typeof(AuthCustomerService));
            services.AddScoped(typeof(IUserRepository), typeof(UserRepository));
            services.AddScoped(typeof(ICustomerRepository),typeof(CustomerRepository));
            services.AddScoped(typeof(IRentalRepository),typeof(RentalRepository));
            services.AddScoped(typeof(IRentalService),typeof(RentalService));

            //storage
            services.AddTransient(typeof(ILocalStorage), typeof(LocalStorage));
        }
    }
}
