using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmPractice
{
    public static class ArrayIndexMultiplication
    {
        public static void Run()
        {
            Console.WriteLine("Enter a list of positive integers separated by comma, and the program will return the array with its values multiplied by all other values except itself. Enter X to exit the program.");

            string input = Console.ReadLine();

            if (input.ToUpper() != "X")
            {
                try
                {
                    Console.WriteLine($"Results = {string.Join(',', GetProductsOfAllIntsExceptAtIndex(Array.ConvertAll(input.Split(','), int.Parse)))}");
                    Console.WriteLine();
                }
                catch
                {
                    Console.WriteLine("The input provided is invalid.");
                }

                Run();
            }
        }

        private static int[] GetProductsOfAllIntsExceptAtIndexWithDivision(int[] values)
        {
            if (values.Length > 0)
            {
                int total = 1;

                for (int i = 0; i < values.Length; i++)
                {
                    total *= values[i];
                }

                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = total / values[i];
                }
            }

            return values;
        }

        private static int[] GetProductsOfAllIntsExceptAtIndex(int[] input)
        {
            var output = new int[input.Length];

            var productsOfElementsBeforeIndex = new int[input.Length];

            var productsOfElementsAfterIndex = new int[input.Length];

            //calculate product of elements before index
            for (int i = 0; i < input.Length; i++)
            {
                productsOfElementsBeforeIndex[i] = 1;

                if (i > 0)
                {
                    productsOfElementsBeforeIndex[i] = productsOfElementsBeforeIndex[i - 1] * input[i - 1];
                }
            }

            //calculate product of elements after index
            for (int i = input.Length - 1; i >= 0; i--)
            {
                productsOfElementsAfterIndex[i] = 1;

                if (i < input.Length - 1)
                {
                    productsOfElementsAfterIndex[i] = productsOfElementsAfterIndex[i + 1] * input[i + 1];
                }
            }

            //calculate products array
            for (int i = 0; i < input.Length; i++)
            {
                output[i] = productsOfElementsBeforeIndex[i] * productsOfElementsAfterIndex[i];
            }

            return output;
        }
    }
}
