using Microsoft.EntityFrameworkCore;
using MotorcycleRental.Core.Entities;
using MotorcycleRental.Core.Repositories;

namespace MotorcycleRental.Infrastructure.Persistence.Repositories
{
    public class UserRepository:IUserRepository
    {
        private readonly MotorcycleRentalDbContext _context;
        public UserRepository(MotorcycleRentalDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _context.Users.SingleOrDefaultAsync(u => u.Id == id);
        }

        public async Task<User> GetUserByEmailAndPasswordAsync(string email, string passwordHash)
        {
            return await _context
                .Users
                .SingleOrDefaultAsync(u => u.Email == email && u.Password == passwordHash);
        }
    }
}
