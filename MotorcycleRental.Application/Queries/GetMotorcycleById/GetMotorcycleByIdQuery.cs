using MediatR;
using MotorcycleRental.Application.ViewModels;

namespace MotorcycleRental.Application.Queries.GetMotorcycleById
{
    public class GetMotorcycleByIdQuery : IRequest<MotorcycleViewModel>
    {
        public GetMotorcycleByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
