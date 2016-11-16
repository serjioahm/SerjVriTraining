using System;
using System.Collections.Generic;
using System.Text;

namespace Task3ForestRoad
{
    class Program
    {
        static void Main(string[] args)
        {
            int step = int.Parse(Console.ReadLine());

            List<string> reverse = new List<string>();
            string[,] path = new string[step, step];
   
            for (int i = 0; i < step; i++)
            {
                for (int j = 0; j < step; j++)
                {
                    if (j == i)
                    {
                        path[i, j] = "*";
                    }
                    else
                    {
                        path[i, j] = ".";
                    }
                    Console.Write(string.Format("{0}", path[i, j]));
                }
                Console.WriteLine();
            }
            for (int i = step - 2; i >= 0; i--)
            {
                reverse = new List<string>();
                for (int j = step - 1; j >= 0; j--)
                {
                    reverse.Add(path[i, j]);
                }
                reverse.Reverse();
                Console.WriteLine(string.Join("", reverse));
            }
        }
    }
}
