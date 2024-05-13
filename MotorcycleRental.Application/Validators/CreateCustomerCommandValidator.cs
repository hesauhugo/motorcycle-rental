using FluentValidation;
using Microsoft.AspNetCore.Http;
using MotorcycleRental.Application.Commands.CreateCustomer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorcycleRental.Application.Validators
{
    public class CreateCustomerCommandValidator:AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerCommandValidator()
        {
            RuleFor(p => p.CnhImage)
                .Must(IsValidImageType)
                .WithMessage("Image extension must be .png or bmp!");

            RuleFor(p => p.CnhKind)
                .Must(IsCnhKindValid)
                .WithMessage("CNH Kind is invalid. Must be A, B or A+B");

        }

        private bool IsCnhKindValid(string cnhKind)
        {
            var alloweKinds = new[] { "A", "B", "A+B" };
            return alloweKinds.Contains(cnhKind);
        }
        private bool IsValidImageType(IFormFile file)
        {
            // Obter a extensão do arquivo
            var allowedExtensions = new[] { ".png", ".bmp" };
            var fileExtension = Path.GetExtension(file.FileName).ToLowerInvariant();

            // Verificar se a extensão é válida
            return allowedExtensions.Contains(fileExtension);
        }

    }
}
