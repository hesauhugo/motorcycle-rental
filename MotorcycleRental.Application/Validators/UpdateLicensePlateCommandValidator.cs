using FluentValidation;
using MotorcycleRental.Application.Commands.UpdateLicensePlate;

namespace MotorcycleRental.Application.Validators
{
    public class UpdateLicensePlateCommandValidator : AbstractValidator<UpdateLicensePlateCommand>
    {
        public UpdateLicensePlateCommandValidator()
        {
            RuleFor(p => p.Id)
            .NotNull()
            .Must(p=> p != 0)
            .WithMessage("Id is not valid!");

            RuleFor(p => p.LicensePlate)
            .NotNull()
            .Must(p => p.Length >= 6)
            .WithMessage("License plate must be equal or greater than 6!");
        }
    }
}
