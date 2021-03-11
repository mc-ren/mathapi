using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using MathApi.BusinessLogic.Calculations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Xunit;

namespace MathApi.Tests.BusinessLogic.Calculations
{
    public class MultiplyCalculationTests
    {
        [Theory]
        [InlineData(100, 1, 10, 1, 1)]
        [InlineData(2, 4, 6, 7, 8)]
        [InlineData(.2, 1, .010, .11, -.1)]
        [InlineData(1300, 1, 10, 1, 1)]
        [InlineData(1040, 1, 10, 1, 1)]
        public void MultiplyTests(double number1, double number2, double number3, double number4, double number5)
        {
            // arrange
            var numbersToCalc = new List<double> { number1, number2, number3, number4, number5 };
            var multiply = new MultiplyCalculation();

            // act
            var response = multiply.Calculate(numbersToCalc);

            // assert
            response.Result.Should().Be(number1 * number2 * number3 * number4 * number5);
        }

        [Theory]
        [InlineData(0, 1, 10, 1, 1)]
        [InlineData(2, 0, 6, 7, 8)]
        [InlineData(.2, 1, 0, .11, -.1)]
        [InlineData(1300, 1, 10, 0, 1)]
        [InlineData(1040, 1, 10, 1, 0)]
        public void DivideTestsWithZero(double number1, double number2, double number3, double number4, double number5)
        {
            // arrange
            var numbersToCalc = new List<double> { number1, number2, number3, number4, number5 };
            var multiply = new MultiplyCalculation();

            // act
            var response = multiply.Calculate(numbersToCalc);

            // assert
            response.Result.Should().Be(0.0);
        }

        [Fact]
        public void Fail()
        {
            var arr = new int[] { 64, 25, 12, 22, 11 };
            int n = arr.Length;
            // SELECTION SORT
            for (int i = 0; i < n - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (arr[j] < arr[minIndex]) { minIndex = j; }
                }
                // Swap the found minimum element with the first 
                int temp = arr[minIndex];
                arr[minIndex] = arr[i];
                arr[i] = temp;
            }

            for (var j = 0; j < arr.Length; j++)
            {
                System.Console.WriteLine(arr[j]);
            }

            BinarySearch(arr, 12).Should().BeTrue();
        }

        [Fact]
        public void QuickSortTest()
        {
            var arr = new int[] { 64, 25, 12, 77, 99}.ToList();
            QuickSort(arr);
            
        }

        public static bool BinarySearch(int[] arry, int nbrToFind)
        {
            var low = 0;
            var high = arry.Length - 1;
            while (low <= high)
            {
                var mid = low + high / 2;
                var guess = arry[mid];
                if (guess == nbrToFind) { return true; }
                if (guess > nbrToFind)
                { high = mid - 1; }
                else
                { low = mid + 1; }
            }
            return false;
        }

        public static void QuickSort(List<int> array)
        {
            // base case
            if (array.Count < 2)
            {
                return ;
            }
            else
            {
                var pivot = array[0];
                var less = new List<int>();
                var more = new List<int>();
                foreach (var i in array)
                {
                    if (i <= pivot)
                    {
                        less.Add(i);
                    }
                    else
                    {
                        more.Add(i);
                    }
                }
                QuickSort(less);
                QuickSort(more);

                less.Add(pivot);
                less.AddRange(more);
                array = less;
                //QuickSort(less);
                //QuickSort(more);
                //var returnArry = new List<int>();
                //returnArry.AddRange(less);
                //returnArry.Add(pivot);
                //returnArry.AddRange(more);
            }
        }

        public static void QSort(List<int> arry)
        {

        }
    }
}