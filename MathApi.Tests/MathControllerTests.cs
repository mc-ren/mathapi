using System;
using System.Collections.Generic;
using FluentAssertions;
using MathApi.BusinessLogic;
using MathApi.BusinessLogic.Calculations;
using MathApi.Controllers;
using MathApi.DataTransfer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Newtonsoft.Json;
using Xunit;

namespace MathApi.Tests
{
    public class MathControllerTests
    {
        [Fact]
        public void ControllerHappyPath()
        {
            // arrange
            var mockCalc = new Mock<ICalculation>();
            var mockLog = new Mock<ILogger<MathController>>();
            var mockMap = new Mock<IMap>();
            var mockFactory = new Mock<ICalculationFactory>();
            mockFactory.Setup(x => x.Build(It.IsAny<CalculationType>())).Returns(mockCalc.Object);

            var mathController = new MathController(mockFactory.Object, mockMap.Object, mockLog.Object);

            // act
            var result = mathController.Post(new CalculationRequest { CalculationType = CalculationType.Add, Numbers = new List<double> { 1, 2, 3, 4, 5 } });
            var objectResult = (ObjectResult)result.Result;

            // assert
            objectResult.StatusCode.Should().Be(200);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(6)]
        public void ControllerErrorPayloadTooLargeOrSmall(int itemsToCreate)
        {
            // arrange
            var numbersToCalc = new List<double>();
            for (var i = 0; i < itemsToCreate; i++)
            {
                numbersToCalc.Add(i + 1);
            }
            var mockCalc = new Mock<ICalculation>();
            var mockLog = new Mock<ILogger<MathController>>();
            var mockMap = new Mock<IMap>();
            var mockFactory = new Mock<ICalculationFactory>();
            mockFactory.Setup(x => x.Build(It.IsAny<CalculationType>())).Returns(mockCalc.Object);

            var mathController = new MathController(mockFactory.Object, mockMap.Object, mockLog.Object);

            // act
            var result = mathController.Post(new CalculationRequest { CalculationType = CalculationType.Add, Numbers = numbersToCalc});
            var objectResult = (ObjectResult)result.Result;

            // assert
            objectResult.StatusCode.Should().Be(413);
            // additional asserts to check text...
        }

        [Fact]
        public void UnknownError()
        {
            // arrange
            var mockCalc = new Mock<ICalculation>();
            var mockLog = new Mock<ILogger<MathController>>();
            var mockMap = new Mock<IMap>();
            var mockFactory = new Mock<ICalculationFactory>();
            mockFactory.Setup(x => x.Build(It.IsAny<CalculationType>())).Throws(new NullReferenceException());

            var mathController = new MathController(mockFactory.Object, mockMap.Object, mockLog.Object);

            // act
            var result = mathController.Post(new CalculationRequest { CalculationType = CalculationType.Add, Numbers = new List<double> { 1, 2, 3, 4, 5 } });
            var objectResult = (ObjectResult)result.Result;

            // assert
            objectResult.StatusCode.Should().Be(500);
        }

        public string Serialize()
        {
            var msg = JsonConvert.SerializeObject(new CalculationRequest
                {CalculationType = CalculationType.Add, Numbers = new List<double> {1, 2, 3}});

            return msg;
        }
    }
}
