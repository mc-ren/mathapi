using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using MathApi.BusinessLogic;
using MathApi.DataTransfer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MathApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MathController : ControllerBase
    {
        private const int MaxCollectionSize = 5;
        private readonly ICalculationFactory _calculationFactory;
        private readonly IMap _map;
        private readonly ILogger<MathController> _logger;

        public MathController(ICalculationFactory calculationFactory, IMap map,  ILogger<MathController> logger)
        {
            _calculationFactory = calculationFactory;
            _map = map;
            _logger = logger;
        }

        [HttpPost]
        public ActionResult<CalculationResponse> Post([FromBody] CalculationRequest value)
        { 
            try
            {
                var recordCount = value.Numbers.Count();
                // todo read from settings file. 
                if (recordCount > MaxCollectionSize || recordCount <= 1) 
                    return ReturnPayloadIncorrect(recordCount);

                var calculation = _calculationFactory.Build(value.CalculationType);
                var returnedCalculation = _map.From(calculation.Calculate(value.Numbers));

                return Ok(returnedCalculation);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                var response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    // todo could use settings to make sure messages are sent based on usage (internal/external/etc.)
                    Content = new StringContent($"An unhandled exception occurred, see log for full details. {ex.Message}")
                };

                return StatusCode(500, response);
            }
        }

        private ObjectResult ReturnPayloadIncorrect(int valueCount)
        {
            var response = new HttpResponseMessage
            {
                ReasonPhrase = $"The please include at least 2 to {MaxCollectionSize} records to calculate. You sent: {valueCount}."
            };

            return StatusCode(400, response);
        }
    }
}
