using FluentValidation;
using Microsoft.AspNetCore.Http;
using MotorcycleRental.Application.Commands.CreateCustomer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

            RuleFor(p=>p.Password)
                .Must(ValidPassword)
                .WithMessage("Senha deve conter pelo menos 8 caracteres, um número, uma letra maiúscula, uma minúscula, e um caractere especial");

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

        public bool ValidPassword(string password)
        {
            var regex = new Regex(@"^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$");

            return regex.IsMatch(password);
        }

    }
}
