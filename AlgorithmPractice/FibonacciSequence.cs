using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmPractice
{
    public static class FibonacciSequence
    {
        public static void Run()
        {
            Console.WriteLine("Enter a positive integer N and the program will return the fibonacci sequence up to N numbers. Enter X to exit the program.");

            string input = Console.ReadLine();

            if (input.ToUpper() != "X")
            {
                if (long.TryParse(input, out long number))
                {
                    Console.WriteLine(string.Join(',', GenerateFibonacciSequence(number)));
                }
                else
                {
                    Console.WriteLine("The number provided is invalid.");
                }

                Run();
            }
        }

        private static long[] GenerateFibonacciSequence(long sequenceSize)
        {
            long[] fibonacciSequence = new long[sequenceSize];

            if (sequenceSize > 0)
            {
                fibonacciSequence[0] = 1;
            }

            if (sequenceSize > 1)
            {
                fibonacciSequence[1] = 1;
            }

            for (long i = 2; i < sequenceSize; i++)
            {
                fibonacciSequence[i] = fibonacciSequence[i - 1] + fibonacciSequence[i - 2]; //GenerateFibonacciNumber(i + 1);
            }

            return fibonacciSequence;
        }

        private static long GenerateFibonacciNumber(long sequenceNumber)
        {
            if (sequenceNumber <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(sequenceNumber), $"Input parameter {nameof(sequenceNumber)} must be a positive number.");
            }

            if (sequenceNumber <= 2)
            {
                return 1;
            }

            return GenerateFibonacciNumber(sequenceNumber - 1) + GenerateFibonacciNumber(sequenceNumber - 2);
        }
    }
}
