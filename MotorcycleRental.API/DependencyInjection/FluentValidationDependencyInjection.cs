using FluentValidation;
using FluentValidation.AspNetCore;
using MotorcycleRental.Application.Validators;

namespace MotorcycleRental.API.DependencyInjection
{
    public static class FluentValidationDependencyInjection
    {

        public static void AddFluentValidationDependencyInjection(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation();
            services.AddFluentValidationClientsideAdapters();
            services.AddValidatorsFromAssemblyContaining<CreateUserCommandValidator>();
        }
    }
}
