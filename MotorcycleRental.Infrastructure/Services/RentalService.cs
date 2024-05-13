using Microsoft.EntityFrameworkCore;
using MotorcycleRental.Core.Entities;
using MotorcycleRental.Core.Repositories;
using MotorcycleRental.Core.Services;
using MotorcycleRental.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorcycleRental.Infrastructure.Services
{
    public class RentalService:IRentalService
    {
        private readonly MotorcycleRentalDbContext _context;
        private readonly IRentalRepository _rentalRepository;

        public RentalService(MotorcycleRentalDbContext context, IRentalRepository rentalRepository)
        {
            _context = context;
            _rentalRepository = rentalRepository;
        }

        public async Task AddAsync(Rental rental)
        {
            var motorcycleUsedIds = _context.Rentals.Select(p => p.IdMotorcycle).ToList();
            var motocycleAvailableId = (await _context.Motorcycles.FirstOrDefaultAsync(p => !motorcycleUsedIds.Contains(p.Id)))?.Id ?? 0;
            if (motocycleAvailableId == 0)
            {
                throw new InvalidOperationException("Unavailable motorcycle");
            }

            rental.SetMotorcycleId(motocycleAvailableId);
            await _rentalRepository.AddAsync(rental);
        }
    }
}
