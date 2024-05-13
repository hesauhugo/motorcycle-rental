using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorcycleRental.Application.Commands.UpdateLicensePlate
{
    public class UpdateLicensePlateCommand:IRequest<Unit>
    {
        public int Id { get; set; }
        public string  LicensePlate { get; set; }
    }
}
