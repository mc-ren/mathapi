using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using MathApi.BusinessLogic.Calculations;
using Xunit;

namespace MathApi.Tests.BusinessLogic.Calculations
{
    public class AddCalculationTests
    {
        [Theory]
        [InlineData(1,2,3,4,5)]
        [InlineData(1,2,3,4,0)]
        [InlineData(1,2,3,0,0)]
        [InlineData(1,2,0,0,0)]
        [InlineData(.1, .02, .00001, .10, .20)]
        public void AddTests(double number1, double number2, double number3, double number4, double number5)
        {
            // arrange
            var numbersToCalc = new List<double> { number1, number2, number3, number4, number5};
            var addCalc = new AddCalculation();

            // act
            var response = addCalc.Calculate(numbersToCalc);

            // assert
            response.Result.Should().Be(numbersToCalc.Sum());
        }

        [Fact]
        public void Fail()
        {
            // todo figure out fail scenario
        }
    }
}