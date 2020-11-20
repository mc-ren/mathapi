using System.Collections.Generic;
using MathApi.BusinessLogic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MathApi.DataTransfer
{
    public class CalculationRequest
    {
        [JsonProperty("calculationType")]
        [JsonConverter(typeof(StringEnumConverter))]
        public CalculationType CalculationType { get; set; }

        [JsonProperty("numbers")]
        public IEnumerable<double> Numbers { get; set; }
    }
}