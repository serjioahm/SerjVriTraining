using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fibonacci
{
    public class Linear
    {
        public int[] Fibonacci(int n)
        {
            int[] result = new int[n];

            int item1 = 1;
            int item2 = 1;
            result[0] = 1;
            result[1] = 1;
            int i = 2;

            while (n > 2) //because we added 2 numbers already!
            {
                result[i] = item1 + item2;
                i++;

                if (item2 > item1)
                {
                    item1 = item1 + item2;
                }
                else
                {
                    item2 = item1 + item2;
                }
                n--;
            }

            return result.ToArray();
        }
    }
}
