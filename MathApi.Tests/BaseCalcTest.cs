using System;

namespace MathApi.Tests
{
    public class BaseCalcTest
    {
        protected double GetRandomNumber(double minimum, double maximum)
        {
            Random random = new Random();
            return random.NextDouble() * (maximum - minimum) + minimum;
        }
    }
}