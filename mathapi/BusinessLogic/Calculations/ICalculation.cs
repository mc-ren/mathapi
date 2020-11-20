using System.Collections.Generic;

namespace MathApi.BusinessLogic.Calculations
{
    public interface ICalculation
    {
        CalculationResult Calculate(IEnumerable<double> numbersToCalculate);
    }
}