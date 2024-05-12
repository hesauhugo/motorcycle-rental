using Microsoft.Extensions.Configuration;
using MotorcycleRental.Core.Entities;
using MotorcycleRental.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Npgsql;

namespace MotorcycleRental.Infrastructure.Persistence.Repositories
{
    public class MotorcycleRepository : IMotorcycleRepository
    {
        private readonly MotorcycleRentalDbContext _context;
        private readonly string _connectionString;
        public MotorcycleRepository(MotorcycleRentalDbContext context,IConfiguration configuration)
        {
            _context = context;
            _connectionString = configuration.GetConnectionString("MotorcycleRental");
        }
        public async Task AddAsync(Motorcycle motorcycle)
        {
            
            await _context.AddAsync(motorcycle);
            await _context.SaveChangesAsync();

        }

        public async Task<Motorcycle> GetByIdAsync(int id)
        {
            using(var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                return await connection.QueryFirstOrDefaultAsync<Motorcycle>("SELECT id, year, model, license_plate as licenseplate FROM motorcycle WHERE id = @Id", new {Id=id});
            }
        }

        public async Task<Motorcycle> GetByLicensePlateAsync(string licensePlate)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                return await connection.QueryFirstOrDefaultAsync<Motorcycle>("SELECT id, year, model, license_plate as licenseplate FROM motorcycle WHERE license_plate = @LicensePlate", new { LicensePlate = licensePlate });
            }
        }
    }
}
