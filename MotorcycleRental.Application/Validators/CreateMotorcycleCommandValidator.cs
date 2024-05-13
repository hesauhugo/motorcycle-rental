using FluentValidation;
using MotorcycleRental.Application.Commands.CreateMotorcycle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorcycleRental.Application.Validators
{
    public class CreateMotorcycleCommandValidator:AbstractValidator<CreateMotorcycleCommand>
    {
        public CreateMotorcycleCommandValidator()
        {
            RuleFor(p => p.Year)
                .Must(p => p > 1990)
                .WithMessage("Year must be greater than 1990!");

            RuleFor(p => p.LicensePlate)
                .NotNull()
                .NotEmpty()
                .WithMessage("License plate is invalid!");

            RuleFor(p => p.Model)
                .NotNull()
                .NotEmpty()
                .WithMessage("Model is invalid!");
        }
    }
}
