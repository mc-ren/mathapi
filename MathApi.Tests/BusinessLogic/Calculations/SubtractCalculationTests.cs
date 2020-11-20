using System.Collections.Generic;
using FluentAssertions;
using MathApi.BusinessLogic.Calculations;
using Xunit;

namespace MathApi.Tests.BusinessLogic.Calculations
{
    public class SubtractCalculationTests
    {
        [Theory]
        [InlineData(1, 2, 3, 4, 5)]
        [InlineData(1, 2, 3, 4, 0)]
        [InlineData(1, 2, 3, 0, 0)]
        [InlineData(1, 2, 0, 0, 0)]
        [InlineData(.1, .02, .00001, .10, .20)]
        [InlineData(501, 44, 20, 10, 10)]
        public void SubtractTests(double number1, double number2, double number3, double number4, double number5)
        {
            // arrangeMath.Round(number1, 10)
            var numbersToCalc = new List<double> { number1, number2, number3, number4, number5 };
            var subCalc = new SubtractCalculation();

            // act
            var response = subCalc.Calculate(numbersToCalc);

            // assert
            response.Result.Should().Be(number1 - number2 - number3 - number4 - number5);
        }

        [Fact]
        public void Fail()
        {
            // todo figure out fail scenario
        }
    }

}