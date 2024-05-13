using MotorcycleRental.Core.Entities;
using MotorcycleRental.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorcycleRental.Application.ViewModels
{
    public class RentalViewModel
    {
        public int Id { get; set; } 
        public DateTime CreateAt { get;  set; }
        public DateTime? EndDate { get;  set; }
        public RentalPlan Plan { get;  set; }
        public DateTime DueDate { get; set; }
        public DateTime BeginDate { get; set; }
        public int IdCustomer { get;  set; }
        public string CustomerName { get;  set; }
        public int IdMotorcycle { get;  set; }
        public string ModelMotorcycle { get;  set; }
        public string LicensePlateMotorcycle { get; set; }


        public void FromEntity(Rental rental)
        {
            this.Id = rental.Id;
            this.CreateAt= rental.CreateAt;
            this.EndDate = rental.EndDate;
            this.Plan = rental.Plan;
            this.IdCustomer = rental.IdCustomer;
            this.CustomerName = rental.Customer.FullName;
            this.IdMotorcycle = rental.IdMotorcycle;
            this.ModelMotorcycle = rental.Motorcycle.Model;
            this.LicensePlateMotorcycle = rental.Motorcycle.LicensePlate;
            this.DueDate = rental.DueDate;
            this.BeginDate=rental.BeginDate;

        }
    }
}
