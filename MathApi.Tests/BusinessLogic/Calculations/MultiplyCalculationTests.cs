using System.Collections.Generic;
using FluentAssertions;
using MathApi.BusinessLogic.Calculations;
using Xunit;

namespace MathApi.Tests.BusinessLogic.Calculations
{
    public class MultiplyCalculationTests
    {
        [Theory]
        [InlineData(100, 1, 10, 1, 1)]
        [InlineData(2, 4, 6, 7, 8)]
        [InlineData(.2, 1, .010, .11, -.1)]
        [InlineData(1300, 1, 10, 1, 1)]
        [InlineData(1040, 1, 10, 1, 1)]
        public void MultiplyTests(double number1, double number2, double number3, double number4, double number5)
        {
            // arrange
            var numbersToCalc = new List<double> { number1, number2, number3, number4, number5 };
            var multiply = new MultiplyCalculation();

            // act
            var response = multiply.Calculate(numbersToCalc);

            // assert
            response.Result.Should().Be(number1 * number2 * number3 * number4 * number5);
        }

        [Theory]
        [InlineData(0, 1, 10, 1, 1)]
        [InlineData(2, 0, 6, 7, 8)]
        [InlineData(.2, 1, 0, .11, -.1)]
        [InlineData(1300, 1, 10, 0, 1)]
        [InlineData(1040, 1, 10, 1, 0)]
        public void DivideTestsWithZero(double number1, double number2, double number3, double number4, double number5)
        {
            // arrange
            var numbersToCalc = new List<double> { number1, number2, number3, number4, number5 };
            var multiply = new MultiplyCalculation();

            // act
            var response = multiply.Calculate(numbersToCalc);

            // assert
            response.Result.Should().Be(0.0);
        }

        [Fact]
        public void Fail()
        {
            // todo figure out fail scenario
        }
    }
}