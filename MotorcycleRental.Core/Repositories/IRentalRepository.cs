using MotorcycleRental.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorcycleRental.Core.Repositories
{
    public interface IRentalRepository
    {
        Task<Rental> GetByIdAsync(int id);
        Task AddAsync(Rental rental);
    }
}
