using MediatR;
using MotorcycleRental.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorcycleRental.Application.Commands.LoginCustomer
{
    public class LoginCustomerCommand:IRequest<LoginCustomerViewModel>
    {
        public string Cnh { get; set; }
        public string Password { get; set; }
    }
}
