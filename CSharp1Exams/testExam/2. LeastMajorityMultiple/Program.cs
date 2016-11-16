using System;

namespace _2.LeastMajorityMultiple
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            int d = int.Parse(Console.ReadLine());
            int e = int.Parse(Console.ReadLine());

            int counterOfDividers = 0;

            for (int number = 4; ; number++)
            {
                counterOfDividers = 0;

                if (number % a == 0)
                {
                    counterOfDividers++;
                }

                if (number % b == 0)
                {
                    counterOfDividers++;
                }

                if (number % c == 0)
                {
                    counterOfDividers++;
                }
                if (number % d == 0)
                {
                    counterOfDividers++;
                }
                if (number % e == 0)
                {
                    counterOfDividers++;
                }

                if (counterOfDividers >= 3)
                {
                    Console.WriteLine(number);
                    break;
                }
            }

        }
    }
}
