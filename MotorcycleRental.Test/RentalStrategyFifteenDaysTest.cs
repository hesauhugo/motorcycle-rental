using MotorcycleRental.Core.Entities.RentalStrategy;

namespace MotorcycleRental.Test
{
    public class RentalStrategyFifteenTest
    {
        [Theory]
        [InlineData(2,201.6)]
        [InlineData(5, 252)]
        [InlineData(6, 268.8)]
        [InlineData(8, 302.4)]
        [InlineData(11, 352.8)]
        public void LowerDays_PlanIsFifteenDays_ReturnWithPenalty(int daysUsed, decimal totalExpected)
        {

            var sevenDays = new FifteenDayPlan();
            decimal totalCalculated = sevenDays.CalculateTotal(daysUsed);

            Assert.Equal(totalExpected,totalCalculated);
        }

        [Theory]
        [InlineData(15, 420)]
        public void DayIsFifteen_PlanIsFifteenDays_ReturnWithoutPenalty(int daysUsed, decimal totalExpected)
        {

            var sevenDays = new FifteenDayPlan();
            decimal totalCalculated = sevenDays.CalculateTotal(daysUsed);

            Assert.Equal(totalExpected, totalCalculated);
        }

        [Theory]
        [InlineData(16, 470)]
        [InlineData(18, 570)]
        [InlineData(20, 670)]
        public void GreaterDays_PlanIsFifteenDays_ReturnWithPricePenalty(int daysUsed, decimal totalExpected)
        {

            var sevenDays = new FifteenDayPlan();
            decimal totalCalculated = sevenDays.CalculateTotal(daysUsed);

            Assert.Equal(totalExpected, totalCalculated);
        }
    }
}