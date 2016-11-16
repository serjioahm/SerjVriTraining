using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Tubes
{
    public class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            //int n = 3;

            int wantedTubes = int.Parse(Console.ReadLine());
            //int wantedTubes = 6;


            //long[] sizes = { 100, 200, 300 };
            long[] sizes = new long[n];
            for (int i = 0; i < n; i++)
            {
                sizes[i] = long.Parse(Console.ReadLine());
            }

            long start = 1;
            long end = sizes.Max();
            long answer = 0;

            while (start <= end)
            {
                long tubes = 0;
                long middle = (start + end) / 2;

                for (int i = 0; i < n; i++)
                {
                    tubes += sizes[i] / middle;
                }

                if (tubes < wantedTubes)
                {
                    end = middle - 1;
                }
                else if (tubes >= wantedTubes)
                {
                    answer = middle;
                    start = middle + 1;
                }
            }

            Console.WriteLine(answer);
        }

    }
}
