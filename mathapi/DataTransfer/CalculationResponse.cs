using MathApi.BusinessLogic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MathApi.DataTransfer
{
    public class CalculationResponse
    {
        [JsonProperty("calculationType")]
        [JsonConverter(typeof(StringEnumConverter))]
        public CalculationType CalculationType { get; set; }

        [JsonProperty("result")]
        public double Result { get; set; } 

        [JsonProperty("resultText")]
        public string ResultText { get; set; }
    }
}