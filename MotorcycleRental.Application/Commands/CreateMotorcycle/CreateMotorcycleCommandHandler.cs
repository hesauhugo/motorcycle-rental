using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MotorcycleRental.Core.Repositories;
using MotorcycleRental.Infrastructure.MessageBus;
using MotorcycleRental.Application.Extensions;

namespace MotorcycleRental.Application.Commands.CreateMotorcycle
{
    public class CreateMotorcycleCommandHandler : IRequestHandler<CreateMotorcycleCommand, int>
    {
        private readonly IMotorcycleRepository _motorcycleRepository;
        private readonly IMessageBusClient _messageBus;

        public CreateMotorcycleCommandHandler(IMotorcycleRepository motorcycleRepository,IMessageBusClient messageBus)
        {
            _motorcycleRepository = motorcycleRepository;
            _messageBus = messageBus;
        }

        public async Task<int> Handle(CreateMotorcycleCommand request, CancellationToken cancellationToken)
        {
            var motorcycle = request.ToEntity();
            await _motorcycleRepository.AddAsync(motorcycle);

            foreach (var @event in motorcycle.Events)
            {
                
                var routingKey = @event.GetType().Name.ToDashCase();

                _messageBus.Publish(@event, routingKey, "motorcycle");
            }

            return motorcycle.Id;
            
        }
    }
}
