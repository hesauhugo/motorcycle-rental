using MediatR;
using MotorcycleRental.Application.ViewModels;
using MotorcycleRental.Core.Repositories;
using MotorcycleRental.Core.Services;
using MotorcycleRental.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorcycleRental.Application.Commands.CreateRental
{
    public class CreateRentalCommandHandler : IRequestHandler<CreateRentalCommand, int>
    {
        private readonly IRentalService _rentalService;
        public CreateRentalCommandHandler(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }

        public async Task<int> Handle(CreateRentalCommand request, CancellationToken cancellationToken)
        {
            var rental = request.ToEntity();
            await _rentalService.AddAsync(rental);
            return rental.Id;
        }
    }
}
