using MotorcycleRental.Core.Enum;

namespace MotorcycleRental.Core.Entities.RentalStrategy
{
    public class FourtyFiveDayPlan : IRentalPlanStrategy
    {
        private const decimal PRICE = 20M;
        private const decimal PRICE_PENALTY = 50M;

        public decimal CalculateTotal(int daysUsed)
        {
            decimal total = Math.Min(daysUsed, (int)RentalPlan.FourtyFive) * PRICE;
            int lowerThanPlan = (int)RentalPlan.FourtyFive - daysUsed;

            if (lowerThanPlan < 0)
            {
                total += (decimal)lowerThanPlan * PRICE_PENALTY * -1;
            }

            return total;
        }
    }
}
