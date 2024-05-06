using MediatR;
using MotorcycleRental.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MotorcycleRental.Application.Commands.CreateMotorcycle
{
    public class CreateMotorcycleCommand:IRequest<int>
    {

        public int Year { get; set; }
        public string Model { get; set; }
        public string LicensePlate { get; set; }

        public  Motorcycle ToEntity()
        {
            return new Motorcycle(this.Year,this.Model, this.LicensePlate);
        }

    }
}
