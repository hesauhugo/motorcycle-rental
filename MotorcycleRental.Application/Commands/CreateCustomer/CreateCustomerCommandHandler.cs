using MediatR;
using Microsoft.Extensions.Configuration;
using MotorcycleRental.Core.Repositories;
using MotorcycleRental.Core.Services;
using MotorcycleRental.Core.Storage.LocalStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorcycleRental.Application.Commands.CreateCustomer
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, int>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ILocalStorage _localStorage;
        private readonly IAuthCustomerService _authService;
        public CreateCustomerCommandHandler(ICustomerRepository customerRepository,ILocalStorage localStorage,IAuthCustomerService authService)
        {
            _customerRepository = customerRepository;
            _localStorage = localStorage;
            _authService = authService;
        }

        public async Task<int> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = request.ToEntity(_authService.ComputeSha256Hash(request.Password));
            await _customerRepository.AddAsync(customer);
            int id = customer.Id;

            byte[] fileBytes;
            using (var memoryStream = new MemoryStream())
            {
                await request.CnhImage.CopyToAsync(memoryStream);
                fileBytes = memoryStream.ToArray();
            }

            string fileName = $"{id}{Path.GetExtension(request.CnhImage.FileName)}";
            _localStorage.UpLoadImage(fileBytes, fileName);

            return customer.Id;
        }
    }
}
