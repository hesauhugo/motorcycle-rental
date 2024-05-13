using MediatR;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using MotorcycleRental.Application.ViewModels;
using MotorcycleRental.Core.Entities;
using MotorcycleRental.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorcycleRental.Application.Commands.CreateRental
{
    public class CreateRentalCommand:IRequest<int>
    {
        public DateTime CreateAt { get;  set; }
        public RentalPlan Plan { get;  set; }
        public int IdCustomer { get;  private set; }

        public Rental ToEntity()
        {
           return new Rental(this.CreateAt, this.Plan,this.IdCustomer);
        }

        public void SetIdCustomer(int idCustomer)
        {
            this.IdCustomer = idCustomer;
        }

    }
}
