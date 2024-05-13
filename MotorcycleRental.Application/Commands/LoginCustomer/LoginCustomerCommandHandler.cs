using MediatR;
using MotorcycleRental.Application.ViewModels;
using MotorcycleRental.Core.Repositories;
using MotorcycleRental.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorcycleRental.Application.Commands.LoginCustomer
{
    public class LoginCustomerCommandHandler : IRequestHandler<LoginCustomerCommand, LoginCustomerViewModel>
    {

        private readonly IAuthCustomerService _authCustomerService;
        private readonly ICustomerRepository _customerRepository;
        public LoginCustomerCommandHandler(IAuthCustomerService authCustomerService, ICustomerRepository userRepository)
        {
            _authCustomerService = authCustomerService;
            _customerRepository = userRepository;
        }
        public async Task<LoginCustomerViewModel> Handle(LoginCustomerCommand request, CancellationToken cancellationToken)
        {
            
            var passwordHash = _authCustomerService.ComputeSha256Hash(request.Password);

            
            var customer = await _customerRepository.GetCustomerByCnhAndPasswordAsync(request.Cnh, passwordHash);

            if (customer == null)
            {
                return null;
            }

            
            var token = _authCustomerService.GenerateJwtToken(customer.Cnh);

            return new LoginCustomerViewModel(customer.Cnh, token);
        }
    }
}
