using MotorcycleRental.Core.Entities.RentalStrategy;

namespace MotorcycleRental.Test
{
    public class RentalStrategySevenDaysTest
    {
        [Theory]
        [InlineData(2,90)]
        [InlineData(3, 114)]
        [InlineData(4, 138)]
        [InlineData(5, 162)]
        [InlineData(6, 186)]
        public void LowerDays_PlanIsSevenDays_ReturnWithPenalty(int daysUsed, decimal totalExpected)
        {

            var sevenDays = new SevenDayPlan();
            decimal totalCalculated = sevenDays.CalculateTotal(daysUsed);

            Assert.Equal(totalExpected,totalCalculated);
        }

        [Theory]
        [InlineData(7, 210)]
        public void DayIsSeven_PlanIsSevenDays_ReturnWithoutPenalty(int daysUsed, decimal totalExpected)
        {

            var sevenDays = new SevenDayPlan();
            decimal totalCalculated = sevenDays.CalculateTotal(daysUsed);

            Assert.Equal(totalExpected, totalCalculated);
        }

        [Theory]
        [InlineData(8, 260)]
        [InlineData(9, 310)]
        [InlineData(10, 360)]
        public void GreaterDays_PlanIsSevenDays_ReturnWithPricePenalty(int daysUsed, decimal totalExpected)
        {

            var sevenDays = new SevenDayPlan();
            decimal totalCalculated = sevenDays.CalculateTotal(daysUsed);

            Assert.Equal(totalExpected, totalCalculated);
        }

    }
}