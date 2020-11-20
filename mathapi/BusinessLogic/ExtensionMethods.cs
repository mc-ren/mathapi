using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathApi.BusinessLogic
{
    public static class ExtensionMethods
    {
        public static string CheckForZeros(this IEnumerable<double> numbersToCalculate)
        {
            var numbersToCalculateList = numbersToCalculate.ToList();
            var messageToReturn = new StringBuilder("Zero records at index(s):");
            for (var nbr = 0; nbr < numbersToCalculateList.Count; nbr++)
            {
                if (numbersToCalculateList[nbr] == 0)
                {
                    messageToReturn.Append($"[{nbr}]");
                }
            }

            return messageToReturn.ToString();
        }
    }
}