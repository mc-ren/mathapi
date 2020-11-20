using System;
using System.Collections.Generic;
using System.Linq;

namespace MathApi.BusinessLogic.Calculations
{
    public class DivideCalculation : ICalculation
    {
        private const string SuccessMessage = "Success";

        public CalculationResult Calculate(IEnumerable<double> numbersToCalculate)
        {
            var result = 0.0;
            var messageTextResult = SuccessMessage;
            try
            {
                var numbersToCalculateList = numbersToCalculate.ToList();
                if (numbersToCalculateList.Any(nbr => nbr == 0))
                {
                    var errMessage = $"Undefined {numbersToCalculateList.CheckForZeros()}";
                    return new CalculationResult(result, errMessage, CalculationType.Divide);
                }

                var cnt = 0;
                foreach (var nbr in numbersToCalculateList)
                {
                    if (cnt == 0)
                    {
                        result = nbr;
                    }
                    else
                    {
                        result /= nbr;
                    }

                    cnt++;
                }
            }
            catch (Exception ex)
            {
                messageTextResult = $"Failure To Divide: {ex}";
            }

            return new CalculationResult(result, messageTextResult, CalculationType.Divide);
        }
    }
}