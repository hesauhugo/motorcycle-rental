using MotorcycleRental.Core.Entities.RentalStrategy;

namespace MotorcycleRental.Test
{
    public class RentalStrategyThirtyDaysTest
    {
        [Theory]
        [InlineData(3,66)]
        [InlineData(5, 110)]
        [InlineData(6, 132)]
        [InlineData(8, 176)]
        [InlineData(11, 242)]
        public void LowerDays_PlanIsThirtyDays_ReturnWithoutPenalty(int daysUsed, decimal totalExpected)
        {

            var sevenDays = new ThirtyDayPlan();
            decimal totalCalculated = sevenDays.CalculateTotal(daysUsed);

            Assert.Equal(totalExpected,totalCalculated);
        }

        [Theory]
        [InlineData(30, 660)]
        public void DayIsThirty_PlanIsThirtyDays_ReturnWithoutPenalty(int daysUsed, decimal totalExpected)
        {

            var sevenDays = new ThirtyDayPlan();
            decimal totalCalculated = sevenDays.CalculateTotal(daysUsed);

            Assert.Equal(totalExpected, totalCalculated);
        }

        [Theory]
        [InlineData(35, 910)]
        [InlineData(38, 1060)]
        [InlineData(40, 1160)]
        public void GreaterDays_PlanIsThirtyDays_ReturnWithPricePenalty(int daysUsed, decimal totalExpected)
        {

            var sevenDays = new ThirtyDayPlan();
            decimal totalCalculated = sevenDays.CalculateTotal(daysUsed);

            Assert.Equal(totalExpected, totalCalculated);
        }
    }
}