using MediatR;
using MotorcycleRental.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorcycleRental.Application.Queries.GetMotorcycleByLicensePlate
{
    public class GetMotorcycleByLicensePlateQuery : IRequest<MotorcycleViewModel>
    {

        public GetMotorcycleByLicensePlateQuery(string licensePlate)
        {
            this.LicensePlate = licensePlate;
        }
        public string LicensePlate { get; private set; }
    }
}
