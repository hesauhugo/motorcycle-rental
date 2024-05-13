using MediatR;
using MotorcycleRental.Application.ViewModels;
using MotorcycleRental.Core.Repositories;

namespace MotorcycleRental.Application.Queries.GetMotorcycleById
{
    public class GetMotorcycleByIdQueryHandler : IRequestHandler<GetMotorcycleByIdQuery, MotorcycleViewModel>
    {
        private readonly IMotorcycleRepository _motorcycleRepository;

        public GetMotorcycleByIdQueryHandler(IMotorcycleRepository motorcycleRepository)
        {
            _motorcycleRepository = motorcycleRepository;
        }

        public async Task<MotorcycleViewModel> Handle(GetMotorcycleByIdQuery request, CancellationToken cancellationToken)
        {
            var motorcycle = await _motorcycleRepository.GetByIdAsync(request.Id);

            var motorcycleViewModel = new MotorcycleViewModel();
            motorcycleViewModel.FromEntity(motorcycle);

            return motorcycleViewModel;
        }
    }
}
