using System;

namespace MathExpression
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal N = decimal.Parse(Console.ReadLine());
            decimal M = decimal.Parse(Console.ReadLine());
            decimal P = decimal.Parse(Console.ReadLine());

            decimal partUp = N * N + 1 / (M * P) + 1337;
            decimal partDown = N - (128.523123123M * P);
            decimal sin = (decimal)Math.Sin((int)M % 180);

            Console.WriteLine("{0:F6}", partUp / partDown + sin);

        }
    }
}
