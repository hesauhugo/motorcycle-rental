using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorcycleRental.Application.ViewModels
{
    public class LoginCustomerViewModel
    {
        public LoginCustomerViewModel(string cnh, string token)
        {
            Cnh = cnh;
            Token = token;
        }

        public string Cnh { get; private set; }
        public string Token { get; private set; }
    }
}
