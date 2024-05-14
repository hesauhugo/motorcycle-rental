using MotorcycleRental.Core.Entities.RentalStrategy;

namespace MotorcycleRental.Test
{
    public class RentalStrategyFiftyDaysTest
    {
        [Theory]
        [InlineData(3,54)]
        [InlineData(10, 180)]
        [InlineData(16, 288)]
        [InlineData(20, 360)]
        [InlineData(25, 450)]
        [InlineData(40, 720)]
        [InlineData(45, 810)]
        [InlineData(48, 864)]
        public void LowerDays_PlanIsFiftyDays_ReturnWithoutPenalty(int daysUsed, decimal totalExpected)
        {

            var sevenDays = new FiftyDayPlan();
            decimal totalCalculated = sevenDays.CalculateTotal(daysUsed);

            Assert.Equal(totalExpected,totalCalculated);
        }

        [Theory]
        [InlineData(50, 900)]
        public void DayIsFifty_PlanIsFiftyDays_ReturnWithoutPenalty(int daysUsed, decimal totalExpected)
        {

            var sevenDays = new FiftyDayPlan();
            decimal totalCalculated = sevenDays.CalculateTotal(daysUsed);

            Assert.Equal(totalExpected, totalCalculated);
        }

        [Theory]
        [InlineData(53, 1050)]
        [InlineData(58, 1300)]
        [InlineData(67, 1750)]
        public void GreaterDays_PlanIsFiftyDays_ReturnWithPricePenalty(int daysUsed, decimal totalExpected)
        {

            var sevenDays = new FiftyDayPlan();
            decimal totalCalculated = sevenDays.CalculateTotal(daysUsed);

            Assert.Equal(totalExpected, totalCalculated);
        }
    }
}