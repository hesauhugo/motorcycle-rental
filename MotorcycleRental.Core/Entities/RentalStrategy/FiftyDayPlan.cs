using MotorcycleRental.Core.Enum;

namespace MotorcycleRental.Core.Entities.RentalStrategy
{
    public class FiftyDayPlan : IRentalPlanStrategy
    {
        private const decimal PRICE = 18M;
        private const decimal PRICE_PENALTY = 50M;

        public decimal CalculateTotal(int daysUsed)
        {
            decimal total = Math.Min(daysUsed, (int)RentalPlan.Fifty) * PRICE;
            int lowerThanPlan = (int)RentalPlan.Fifty - daysUsed;

            if (lowerThanPlan < 0)
            {
                total += (decimal)lowerThanPlan * PRICE_PENALTY * -1;
            }

            return total;
        }
    }
}
