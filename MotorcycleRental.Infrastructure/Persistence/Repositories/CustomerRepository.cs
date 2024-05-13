using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MotorcycleRental.Core.Entities;
using MotorcycleRental.Core.Repositories;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorcycleRental.Infrastructure.Persistence.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly MotorcycleRentalDbContext _context;
        private readonly string _connectionString;
        public CustomerRepository(MotorcycleRentalDbContext context, IConfiguration configuration)
        {
            _context = context;
            _connectionString = configuration.GetConnectionString("MotorcycleRental");
        }
        public async Task AddAsync(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
        }

        public async Task<Customer> GetByIdAsync(int id)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                return await connection.QueryFirstOrDefaultAsync<Customer>("SELECT id, full_name as fullname,cnpj,birth_date as birthdate, cnh, cnh_kind as cnhkind FROM customer where id = @id", new { id });
            }
            
        }

        public async Task<Customer> GetCustomerByCnhAndPasswordAsync(string cnh, string passwordHash)
        {
            return await _context
                .Customers
                .SingleOrDefaultAsync(u => u.Cnh == cnh && u.Password == passwordHash);
        }
    }
}
