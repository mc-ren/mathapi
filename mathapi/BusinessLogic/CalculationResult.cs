namespace MathApi.BusinessLogic
{
    public readonly struct CalculationResult
    {
        public double Result { get; }
        public string ResultText { get; }
        public CalculationType CalculationType { get; }

        public CalculationResult(double result, string resultText, CalculationType calculationType)
        {
            Result = result;
            ResultText = resultText;
            CalculationType = calculationType;
        }
    }
}