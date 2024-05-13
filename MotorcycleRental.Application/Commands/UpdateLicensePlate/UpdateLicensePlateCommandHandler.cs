using MediatR;
using MotorcycleRental.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorcycleRental.Application.Commands.UpdateLicensePlate
{
    public class UpdateLicensePlateCommandHandler : IRequestHandler<UpdateLicensePlateCommand, Unit>
    {
        private readonly IMotorcycleRepository _motorcycleRepository;

        public UpdateLicensePlateCommandHandler(IMotorcycleRepository motorcycleRepository)
        {
            _motorcycleRepository = motorcycleRepository;
        }

        public async Task<Unit> Handle(UpdateLicensePlateCommand request, CancellationToken cancellationToken)
        {

            await _motorcycleRepository.UpdateLicensePlateAsync(request.Id, request.LicensePlate);

            return Unit.Value;
        }
    }
}
