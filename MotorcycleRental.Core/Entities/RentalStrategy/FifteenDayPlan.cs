using MotorcycleRental.Core.Enum;

namespace MotorcycleRental.Core.Entities.RentalStrategy
{
    public class FifteenDayPlan : IRentalPlanStrategy
    {
        private const decimal PRICE = 28M;
        private const decimal PENALTY = 0.4M;
        private const decimal PRICE_PENALTY = 50M;
        public decimal CalculateTotal(int daysUsed)
        {
            decimal total = Math.Min(daysUsed, (int)RentalPlan.Fifteen) * PRICE;
            int lowerThanPlan = (int)RentalPlan.Fifteen - daysUsed;

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
