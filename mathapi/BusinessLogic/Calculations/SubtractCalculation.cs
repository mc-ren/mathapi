using System;
using System.Collections.Generic;

namespace MathApi.BusinessLogic.Calculations
{
    public class SubtractCalculation : ICalculation
    {
        private const string SuccessMessage = "Success";

        public CalculationResult Calculate(IEnumerable<double> numbersToCalculate)
        {
            var result = 0.0;
            var messageTextResult = SuccessMessage;
            try
            {
                var cnt = 0;
                foreach (var nbr in numbersToCalculate)
                {
                    if (cnt == 0)
                    {
                        result = nbr;
                    }
                    else
                    {
                        result -= nbr;
                    }

                    cnt++;
                }
            }
            catch (Exception ex)
            {
                messageTextResult = $"Failure To Subtract: {ex}";
            }

            return new CalculationResult(result, messageTextResult, CalculationType.Subtract);
        }
    }
}