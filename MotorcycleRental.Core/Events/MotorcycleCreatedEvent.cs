using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorcycleRental.Core.Events
{
    public class MotorcycleCreatedEvent:IDomainEvent
    {
        public MotorcycleCreatedEvent(string licensePlate, int year)
        {
            LicensePlate = licensePlate;
            Year = year;
        }

        public string LicensePlate { get; }
        public int Year { get; }
    }
}
