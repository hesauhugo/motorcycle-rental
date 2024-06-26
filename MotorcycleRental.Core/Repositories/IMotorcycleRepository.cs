﻿using MotorcycleRental.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorcycleRental.Core.Repositories
{
    public interface IMotorcycleRepository
    {
        Task AddAsync(Motorcycle motorcycle);
        Task<Motorcycle> GetByIdAsync(int id);
        Task<Motorcycle> GetByLicensePlateAsync(string licensePlate);
        Task UpdateLicensePlateAsync(int id,string licensePlate);
    }
}
