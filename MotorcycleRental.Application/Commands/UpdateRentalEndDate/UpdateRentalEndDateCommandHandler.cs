using MediatR;
using MotorcycleRental.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorcycleRental.Application.Commands.UpdateRentalEndDate
{
    public class UpdateRentalEndDateCommandHandler : IRequestHandler<UpdateRentalEndDateCommand, Unit>
    {

        private readonly IRentalRepository _rentalRepository;

        public UpdateRentalEndDateCommandHandler(IRentalRepository rentalRepository)
        {
            _rentalRepository = rentalRepository;
        }

        public async Task<Unit> Handle(UpdateRentalEndDateCommand request, CancellationToken cancellationToken)
        {
            await _rentalRepository.UpdateEndDateAsync(request.Id, request.EndDate);
            return Unit.Value;
        }
    }
}
