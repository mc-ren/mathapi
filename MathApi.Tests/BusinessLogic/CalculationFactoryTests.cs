using FluentAssertions;
using MathApi.BusinessLogic;
using Xunit;

namespace MathApi.Tests.BusinessLogic
{
    public class CalculationFactoryTests
    {
        [Theory]
        [InlineData(CalculationType.Add)]
        [InlineData(CalculationType.Subtract)]
        [InlineData(CalculationType.Multiply)]
        [InlineData(CalculationType.Divide)]
        public void ControllerErrorPayloadTooLargeOrSmall(CalculationType calculationType)
        {
            // arrange
            var calcFactory = new CalculationFactory();

            // act
            var calc = calcFactory.Build(calculationType);

            // assert
            calc.GetType().Name.Should().Contain(calculationType.ToString());
        }
    }
}