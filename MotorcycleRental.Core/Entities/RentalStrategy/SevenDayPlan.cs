using MotorcycleRental.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorcycleRental.Core.Entities.RentalStrategy
{
    public class SevenDayPlan : IRentalPlanStrategy
    {
        private const decimal PRICE = 30.0M;
        private const decimal PENALTY = 0.2M;
        private const decimal PRICE_PENALTY = 50M;
        public decimal CalculateTotal(int daysUsed)
        {
            decimal total = Math.Min(daysUsed, (int)RentalPlan.Seven) * PRICE;
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
}
