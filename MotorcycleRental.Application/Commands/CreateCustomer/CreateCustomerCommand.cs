﻿using MediatR;
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
        public string TipoCnh { get; set; }
        public IFormFile? CnhFoto { get; set; }

        public Customer ToEntity()
        {
            return new Customer(this.FullName,this.Cnpj,this.BirthDate,this.Cnh,this.TipoCnh);
        }
    }
}
