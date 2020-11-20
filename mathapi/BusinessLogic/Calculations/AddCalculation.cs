using System;
using System.Collections.Generic;
using System.Linq;

namespace MathApi.BusinessLogic.Calculations
{
    public class AddCalculation : ICalculation
    {
        private const string SuccessMessage = "Success";

        public CalculationResult Calculate(IEnumerable<double> numbersToCalculate)
        {
            var result = 0.0;
            var messageTextResult = SuccessMessage;
            try
            {
                result = numbersToCalculate.Sum();
            }
            catch (Exception ex)
            {
                messageTextResult = $"Failure To Add: {ex}";
            }
            
            return new CalculationResult(result, messageTextResult, CalculationType.Add);
        }
    }
}