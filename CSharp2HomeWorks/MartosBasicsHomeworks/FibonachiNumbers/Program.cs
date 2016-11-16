using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FibonachiNumbers
{
    public class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());

            Program p = new Program();
            int[] fibonachiNumbers = p.FindFibonachiNumbers(length);

            Console.WriteLine(string.Join(", ", fibonachiNumbers));
        }

        public int[] FindFibonachiNumbers(int length)
        {
            if (length < 0)
            {
                throw new ArgumentException();
            }

            int[] fibonachiNumbers = new int[length];

            if (length > 0)
            {
                fibonachiNumbers[0] = 0;
                fibonachiNumbers[1] = 1;
            }

            for (int i = 2; i < length; i++)
            {
                int nextItem = Math.Abs(fibonachiNumbers[i - 2]) + Math.Abs(fibonachiNumbers[i - 1]);
                fibonachiNumbers[i] = nextItem % 2 == 0 ? -nextItem : nextItem;
            }

            return fibonachiNumbers;
        }
    }
}
