using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MotorcycleRental.Core.Repositories;

namespace MotorcycleRental.Application.Commands.CreateMotorcycle
{
    public class CreateMotorcycleCommandHandler : IRequestHandler<CreateMotorcycleCommand, int>
    {
        private readonly IMotorcycleRepository _motorcycleRepository;

        public CreateMotorcycleCommandHandler(IMotorcycleRepository motorcycleRepository)
        {
            _motorcycleRepository = motorcycleRepository;
        }

        public async Task<int> Handle(CreateMotorcycleCommand request, CancellationToken cancellationToken)
        {
            var motorcycle = request.ToEntity();
            await _motorcycleRepository.AddAsync(motorcycle);
            return motorcycle.Id;
            
        }
    }
}
