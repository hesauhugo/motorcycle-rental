using MotorcycleRental.Core.Entities.RentalStrategy;

namespace MotorcycleRental.Test
{
    public class RentalStrategyFourtyFiveDaysTest
    {
        [Theory]
        [InlineData(3,60)]
        [InlineData(10, 200)]
        [InlineData(16, 320)]
        [InlineData(20, 400)]
        [InlineData(25, 500)]
        [InlineData(40, 800)]
        public void LowerDays_PlanIsFourtyFiveDays_ReturnWithoutPenalty(int daysUsed, decimal totalExpected)
        {

            var sevenDays = new FourtyFiveDayPlan();
            decimal totalCalculated = sevenDays.CalculateTotal(daysUsed);

            Assert.Equal(totalExpected,totalCalculated);
        }

        [Theory]
        [InlineData(45, 900)]
        public void DayIsFourtyFive_PlanIsFourtyFiveDays_ReturnWithoutPenalty(int daysUsed, decimal totalExpected)
        {

            var sevenDays = new FourtyFiveDayPlan();
            decimal totalCalculated = sevenDays.CalculateTotal(daysUsed);

            Assert.Equal(totalExpected, totalCalculated);
        }

        [Theory]
        [InlineData(50, 1150)]
        [InlineData(53, 1300)]
        [InlineData(60, 1650)]
        public void GreaterDays_PlanIsFourtyFiveDays_ReturnWithPricePenalty(int daysUsed, decimal totalExpected)
        {

            var sevenDays = new FourtyFiveDayPlan();
            decimal totalCalculated = sevenDays.CalculateTotal(daysUsed);

            Assert.Equal(totalExpected, totalCalculated);
        }
    }
}