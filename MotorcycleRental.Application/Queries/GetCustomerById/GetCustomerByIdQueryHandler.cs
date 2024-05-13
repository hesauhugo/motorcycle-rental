using MediatR;
using MotorcycleRental.Application.ViewModels;
using MotorcycleRental.Core.Repositories;

namespace MotorcycleRental.Application.Queries.GetCustomerById
{
    public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, CustomerViewModel>
    {
        private readonly ICustomerRepository customerRepository;

        public GetCustomerByIdQueryHandler(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public async Task<CustomerViewModel> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            var customerEntity =  await customerRepository.GetByIdAsync(request.Id);
            var customer = new CustomerViewModel();
            customer.FromEntity(customerEntity);
            return customer;
        }
    }
}
