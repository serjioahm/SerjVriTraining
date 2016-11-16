using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySummation
{
    public class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());

            Program p = new Program();
            int result = p.SummationOfBineryRepresentationOfIntegers(num1, num2);

            Console.WriteLine("The sum of the binary representation of the numbers is: " + result);
        }

        public int SummationOfBineryRepresentationOfIntegers(int num1, int num2)
        {
            int sum = 0;

            sum += CalculateOnesInNumber(num1);
            sum += CalculateOnesInNumber(num2);

            return sum;
        }

        public int CalculateOnesInNumber(int number)
        {
            int counter = 0;

            while (number > 0)
            {
                int result = 1 & number;
                if (result == 1)
                {
                    counter++;
                }

                number = number >> 1;
            }

            return counter;
        }
    }
}
