using MotorcycleRental.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorcycleRental.Core.Services
{
    public interface IRentalService
    {
        Task AddAsync(Rental rental);
    }
}
