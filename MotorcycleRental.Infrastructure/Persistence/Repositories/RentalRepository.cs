using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MotorcycleRental.Core.Entities;
using MotorcycleRental.Core.Repositories;
using MotorcycleRental.Infrastructure.Persistence.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorcycleRental.Infrastructure.Persistence.Repositories
{
    public class RentalRepository : IRentalRepository
    {
        private readonly MotorcycleRentalDbContext _context;
        private readonly string _connectionString;
        public RentalRepository(MotorcycleRentalDbContext context, IConfiguration configuration)
        {
            _context = context;
            _connectionString = configuration.GetConnectionString("MotorcycleRental");
        }
        public async Task AddAsync(Rental rental)
        {

            await _context.Rentals.AddAsync(rental);
            await _context.SaveChangesAsync();
        }

        public Task<Rental> GetByIdAsync(int id)
        {
            var rental = _context.Rentals.Where(p => p.Id == id).Include(c => c.Customer).Include(m => m.Motorcycle).FirstOrDefaultAsync();
            return rental;
        }
    }
}
