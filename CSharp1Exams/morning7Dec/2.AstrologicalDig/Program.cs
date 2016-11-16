using System;
using System.Numerics;

namespace _2.AstrologicalDig
{
    class Program
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();

            int indexOfDot = number.IndexOf('.');
            BigInteger currentNumber = 0;

            if (indexOfDot > -1)
            {
                number = number.Remove(indexOfDot, 1);
            }

            currentNumber = BigInteger.Parse(number);

            BigInteger sumOfDigits = currentNumber;
            int currentDigit = 0;

            if (sumOfDigits < 0)
            {
                sumOfDigits = sumOfDigits * (-1);
            }

            while (sumOfDigits > 9)
            {
                int nextSumOfDigits = 0;
                while (sumOfDigits > 0)
                {
                    currentDigit = (int)(sumOfDigits % 10);
                    nextSumOfDigits = nextSumOfDigits + currentDigit;
                    sumOfDigits = sumOfDigits / 10;
                }
                sumOfDigits = nextSumOfDigits;
            }

            Console.WriteLine(sumOfDigits);
        }
    }
}
