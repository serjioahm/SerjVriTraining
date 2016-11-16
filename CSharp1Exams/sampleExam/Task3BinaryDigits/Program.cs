using System;
using System.Collections.Generic;

namespace Task4BinaryDigits
{
    class Program
    {
        static void Main(string[] args)
        {
            int digit = int.Parse(Console.ReadLine());
            int length = int.Parse(Console.ReadLine());
            List<int> results = new List<int>();
            int counter = 0;

            for (int i = 0; i < length; i++)
            {
                long number = long.Parse(Console.ReadLine());
                counter = 0;

                while (number > 0)
                {
                    long result = 1 & number;
                    if (result == digit)
                    {
                        counter++;
                    }
                    number = number >> 1;
                }
                results.Add(counter);
            }

            Console.WriteLine(string.Join("\n", results));
        }
    }
}
