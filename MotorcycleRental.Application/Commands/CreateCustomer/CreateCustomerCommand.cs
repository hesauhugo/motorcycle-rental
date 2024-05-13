using MediatR;
using Microsoft.AspNetCore.Http;
using MotorcycleRental.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorcycleRental.Application.Commands.CreateCustomer
{
    public class CreateCustomerCommand : IRequest<int>
    {
        public string FullName { get; set; }
        public string Cnpj { get; set; }
        public DateTime BirthDate { get; set; }
        public string Cnh { get; set; }
        public string CnhKind { get; set; }
        public string Password { get; set; }
        public IFormFile CnhImage { get; set; }

        public Customer ToEntity(string passwordHash)
        {
            return new Customer(this.FullName,this.Cnpj,this.BirthDate,this.Cnh,this.CnhKind, passwordHash);
        }
    }
}
