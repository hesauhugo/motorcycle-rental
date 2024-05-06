using MotorcycleRental.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorcycleRental.Application.ViewModels
{
    public class MotorcycleViewModel
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public string Model { get; set; }
        public string LicensePlate { get; set; }

        public void FromEntity(Motorcycle motorcycle)
        {
            this.Id = motorcycle.Id;
            this.Year = motorcycle.Year;    
            this.Model = motorcycle.Model;
            this.LicensePlate=motorcycle.LicensePlate;
        }
    }
}
