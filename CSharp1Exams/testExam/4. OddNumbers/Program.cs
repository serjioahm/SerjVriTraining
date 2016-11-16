using System;

namespace _4.OddNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            long numberOccuringOddTimes = 0;

            long[] numbers = new long[n];

            for (int i = 0; i < n; i++)
            {
                numbers[i] = long.Parse(Console.ReadLine());
            }

            for (int i = 0; i < n; i++)
            {
                numberOccuringOddTimes = numberOccuringOddTimes ^ numbers[i];
            }

            Console.WriteLine(numberOccuringOddTimes);
        }
    }
}
