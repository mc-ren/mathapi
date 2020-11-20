using MathApi.BusinessLogic;

namespace MathApi.DataTransfer
{
    public interface IMap
    {
        CalculationResponse From(CalculationResult calculationResult);
    }

    /// <summary>
    /// Class that could be used to map from Request/Response if needed.
    /// Would add production hardening around errors, this is a simple implementation.
    /// Could implement AutoMapper NuGet. 
    /// </summary>
    public class Map : IMap
    {
        public CalculationResponse From(CalculationResult calculationResult)
        {
            return new CalculationResponse
            {
                CalculationType = calculationResult.CalculationType, 
                Result = calculationResult.Result,
                ResultText = calculationResult.ResultText
            };
        }
    }
}