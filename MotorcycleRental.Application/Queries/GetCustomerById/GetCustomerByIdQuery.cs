using MediatR;
using MotorcycleRental.Application.ViewModels;

namespace MotorcycleRental.Application.Queries.GetCustomerById
{
    public class GetCustomerByIdQuery:IRequest<CustomerViewModel>
    {
        public GetCustomerByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
