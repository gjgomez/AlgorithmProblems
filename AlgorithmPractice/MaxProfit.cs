using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmPractice
{
    public static class MaxProfit
    {
        public static void Run()
        {
            Console.WriteLine("Enter a list of positive integers separated by comma, representing currency values for the day, and the program will return the max possible profit. Enter X to exit the program.");

            string input = Console.ReadLine();

            if (input.ToUpper() != "X")
            {
                try
                {
                    Console.WriteLine($"Max profit = {CalculateMaxProfitOptimized(Array.ConvertAll(input.Split(','), int.Parse))}");
                    Console.WriteLine();
                }
                catch
                {
                    Console.WriteLine("The input provided is invalid.");
                }

                Run();
            }
        }

        private static int CalculateMaxProfit(int[] prices)
        {
            int maxProfit = 0;

            for (int i = 0; i < prices.Length; i++)
            {
                for (int j = i + 1; j < prices.Length; j++)
                {
                    int currentProfit = prices[j] - prices[i];
                    if (currentProfit > maxProfit)
                    {
                        maxProfit = currentProfit;
                    }
                }
            }

            return maxProfit;
        }

        private static int CalculateMaxProfitOptimized(int[] prices)
        {
            int maxProfit = 0;

            if (prices.Length > 0)
            {
                int minPrice = prices[0];

                for (int i = 1; i < prices.Length; i++)
                {
                    if (prices[i] - minPrice > maxProfit)
                    {
                        maxProfit = prices[i] - minPrice;
                    }

                    if (prices[i] < minPrice)
                    {
                        minPrice = prices[i];
                    }
                }
            }

            return maxProfit;
        }
    }
}
