using MotorcycleRental.Core.Events;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MotorcycleRental.Core.Entities
{
    public class Motorcycle:BaseEntity
    {
        public Motorcycle(int year, string model, string licensePlate)
        {
            Year = year;
            Model = model;
            LicensePlate = licensePlate;
            if(year == DateTime.Now.Year)
            {
                AddEvent(new MotorcycleCreatedEvent(licensePlate, year));
            }
        }

        public Motorcycle(int id, int year, string model, string licensePlate):base(id)
        {
            Year = year;
            Model = model;
            LicensePlate = licensePlate;
            
        }

        protected Motorcycle(){}

        public int Year { get; private set; }
        public string Model { get; private set; }
        public string LicensePlate {  get; private set; }


        private List<IDomainEvent>  _events = new List<IDomainEvent> ();
        public IEnumerable<IDomainEvent> Events => _events;

        private void AddEvent(IDomainEvent @event)
        {
            if (_events == null)
                _events = new List<IDomainEvent>();

            _events.Add(@event);
        }

        public void UpdateLicensePlate(string licensePlate)
        {
            this.LicensePlate = licensePlate;
        }

    }
}
