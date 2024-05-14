using MotorcycleRental.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorcycleRental.Core.Entities
{
    public class Rental : BaseEntity
    {
        public Rental(DateTime createAt, RentalPlan plan, int idCustomer)
        {
            CreateAt = createAt;
            Plan = plan;
            IdCustomer = idCustomer;
        }

        public Rental(int id, DateTime createAt, RentalPlan plan, int idCustomer) : base(id)
        {
            CreateAt = createAt;
            Plan = plan;
            IdCustomer = idCustomer;
        }

        protected Rental() { }
        public DateTime CreateAt { get; private set; }
        public DateTime? EndDate { get; private set; }
        public RentalPlan Plan { get; private set; }
        public int IdCustomer { get; private set; }
        public Customer Customer { get; private set; }
        public int IdMotorcycle { get; private set; }
        public Motorcycle Motorcycle { get; private set; }
        public DateTime DueDate { get => BeginDate.AddDays((int)Plan); }
        public DateTime BeginDate { get => CreateAt.AddDays(1); }
        public decimal TotalRental { get => GetTotalRental(); }
        public void SetEndDate(DateTime endDate)
        {
            this.EndDate = endDate;
        }
        public void SetMotorcycleId(int IdMotorcycle)
        {
            this.IdMotorcycle = IdMotorcycle;
        }

        private decimal GetTotalRental()
        {
            if (!EndDate.HasValue) return 0;

            TimeSpan difference = EndDate.Value - BeginDate;
            int daysUsed = difference.Days +1;

            IRentalPlanStrategy rentalPlanStrategy = null;

            switch (Plan)
            {
                case RentalPlan.Seven:
                    rentalPlanStrategy = new SevenDayPlan();
                    break;
                case RentalPlan.Fifteen:
                    rentalPlanStrategy = new FifteenDayPlan();
                    break;
                case RentalPlan.Thirty:
                    rentalPlanStrategy = new ThirtyDayPlan();
                    break;
                case RentalPlan.FourtyFive:
                    rentalPlanStrategy = new FourtyFiveDayPlan();
                    break;
                case RentalPlan.Fifty:
                    rentalPlanStrategy = new FiftyDayPlan();
                    break;
                default:
                    break;
            }

            return rentalPlanStrategy?.CalculateTotal(daysUsed) ?? 0M;
        }

        public interface IRentalPlanStrategy
        {
            decimal CalculateTotal(int daysUsed);
        }

        public class SevenDayPlan : IRentalPlanStrategy
        {
            private const decimal PRICE = 30.0M;
            private const decimal PENALTY = 0.2M;
            private const decimal PRICE_PENALTY = 50M;
            public decimal CalculateTotal(int daysUsed)
            {
                decimal total = daysUsed * PRICE;
                int lowerThanPlan = (int)RentalPlan.Seven - daysUsed;

                if (lowerThanPlan > 0)
                {
                    total += (decimal)lowerThanPlan * PRICE * PENALTY;
                }

                if (lowerThanPlan < 0)
                {
                    total += (decimal)lowerThanPlan * PRICE_PENALTY * -1;
                }

                return total;
            }
        }

        public class FifteenDayPlan : IRentalPlanStrategy
        {
            private const decimal PRICE = 28M;
            private const decimal PENALTY = 0.4M;
            private const decimal PRICE_PENALTY = 50M;
            public decimal CalculateTotal(int daysUsed)
            {
                decimal total = daysUsed * PRICE;
                int lowerThanPlan = (int)RentalPlan.Fifteen - daysUsed  ;

                if (lowerThanPlan > 0)
                {
                    total += (decimal)lowerThanPlan * PRICE * PENALTY;
                }

                if (lowerThanPlan < 0)
                {
                    total += (decimal)lowerThanPlan * PRICE_PENALTY * -1;
                }

                return total;
            }
        }

        public class ThirtyDayPlan : IRentalPlanStrategy
        {
            private const decimal PRICE = 22M;
            private const decimal PRICE_PENALTY = 50M;

            public decimal CalculateTotal(int daysUsed)
            {
                decimal total = daysUsed * PRICE;
                int lowerThanPlan =  (int)RentalPlan.Thirty - daysUsed;

                if (lowerThanPlan < 0)
                {
                    total += (decimal)lowerThanPlan * PRICE_PENALTY * -1;
                }

                return total;
            }
        }

        public class FourtyFiveDayPlan : IRentalPlanStrategy
        {
            private const decimal PRICE = 20M;
            private const decimal PRICE_PENALTY = 50M;

            public decimal CalculateTotal(int daysUsed)
            {
                decimal total = daysUsed * PRICE;
                int lowerThanPlan = (int)RentalPlan.FourtyFive - daysUsed;

                if (lowerThanPlan < 0)
                {
                    total += (decimal)lowerThanPlan * PRICE_PENALTY * -1;
                }

                return total;
            }
        }

        public class FiftyDayPlan : IRentalPlanStrategy
        {
            private const decimal PRICE = 18M;
            private const decimal PRICE_PENALTY = 50M;

            public decimal CalculateTotal(int daysUsed)
            {
                decimal total = daysUsed * PRICE;
                int lowerThanPlan = (int)RentalPlan.Fifty - daysUsed;

                if (lowerThanPlan < 0)
                {
                    total += (decimal)lowerThanPlan * PRICE_PENALTY * -1;
                }

                return total;
            }
        }

    }
}
