using System;

namespace _3.Trapezoid
{
    class Program
    {
        static void Main(string[] args)
        {
            int topSide = int.Parse(Console.ReadLine());
            int leftSide = topSide;
            int betweenSides = topSide - 1;
          
            Console.WriteLine(new string('.', leftSide) + new string('*', topSide));

            for (int i = 0; i < topSide-1; i++)
            {
                leftSide -= 1;
                Console.WriteLine(new string('.', leftSide) + '*'+ new string('.', betweenSides) + '*');
                betweenSides++;
            }

            Console.WriteLine(new string('*', topSide * 2));
        }
    }
}
