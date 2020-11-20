using System.Collections.Generic;
using MathApi.BusinessLogic.Calculations;

namespace MathApi.BusinessLogic
{
    public interface ICalculationFactory
    {
        ICalculation Build(CalculationType calculationType);
    }

    public class CalculationFactory : ICalculationFactory
    {
        private readonly Dictionary<CalculationType, ICalculation> _calculations = new Dictionary<CalculationType, ICalculation>
            {
                {CalculationType.Add, new AddCalculation()},
                {CalculationType.Subtract, new SubtractCalculation()},
                {CalculationType.Multiply, new MultiplyCalculation()},
                {CalculationType.Divide, new DivideCalculation()}
            };

        public ICalculation Build(CalculationType calculationType)
        {
            return _calculations[calculationType];
        }
    }
}