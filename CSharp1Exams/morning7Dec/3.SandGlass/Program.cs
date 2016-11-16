using System;

namespace _3.SandGlass
{
    class Program
    {
        static void Main(string[] args)
        {         
            int size = int.Parse(Console.ReadLine());
            string[] lines = new string[size];

            for (int i = 0; i <= size / 2; i++)
            {
                string dots = new string('.', i);
                string stars = new string('*', size - 2 * i);
                lines[i] = dots + stars + dots;
                Console.WriteLine(lines[i]);
                if (i == size / 2)
                {
                    for (int j = i-1; j >= 0; j--)
                    {
                        Console.WriteLine(lines[j]);
                    }
                }
            }
        }
    }
}
