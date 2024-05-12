using MediatR;
using MotorcycleRental.Application.Queries.GetMotorcycleById;
using MotorcycleRental.Application.ViewModels;
using MotorcycleRental.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorcycleRental.Application.Queries.GetMotorcycleByLicensePlate
{
    public class GetMotorcycleByLicensePlateQueryHandler : IRequestHandler<GetMotorcycleByLicensePlateQuery, MotorcycleViewModel>
    {
        private readonly IMotorcycleRepository _motorcycleRepository;

        public GetMotorcycleByLicensePlateQueryHandler(IMotorcycleRepository motorcycleRepository)
        {
            _motorcycleRepository = motorcycleRepository;
        }
        public async Task<MotorcycleViewModel> Handle(GetMotorcycleByLicensePlateQuery request, CancellationToken cancellationToken)
        {
            var motorcycle = await _motorcycleRepository.GetByLicensePlateAsync(request.LicensePlate);

            var motorcycleViewModel = new MotorcycleViewModel();
            motorcycleViewModel.FromEntity(motorcycle);

            return motorcycleViewModel;
        }
    }
}
