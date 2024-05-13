using MotorcycleRental.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorcycleRental.Core.Entities
{
    public class Rental:BaseEntity
    {
        public Rental(DateTime createAt, RentalPlan plan, int idCustomer)
        {
            CreateAt = createAt;
            Plan = plan;
            IdCustomer = idCustomer;
        }

        public Rental(int id,DateTime createAt, RentalPlan plan, int idCustomer) :base(id)
        {
            CreateAt = createAt;
            Plan = plan;
            IdCustomer = idCustomer;
        }

        protected Rental() { }
        public DateTime CreateAt { get; private set; }
        public DateTime? EndDate { get; private set; }
        public RentalPlan Plan { get; private set; }
        public int IdCustomer {  get; private set; }
        public Customer Customer { get; private set; }
        public int IdMotorcycle { get; private set; }
        public Motorcycle Motorcycle { get; private set; }
        public DateTime DueDate { get => BeginDate.AddDays((int)Plan); }
        public DateTime BeginDate { get => CreateAt.AddDays(1); }

        public void SetEndDate(DateTime endDate)
        {
            this.EndDate = endDate;
        }
        public void SetMotorcycleId(int IdMotorcycle)
        {
            this.IdMotorcycle = IdMotorcycle;
        }
    }
}
