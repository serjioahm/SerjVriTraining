using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fibonacci
{
    public class Recursive
    {
        public int Fibonacci(int n)
        {
            if (n == 0)
            {
                return 0;
            }

            if (n==1)
            {
                return 1;
            }

            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }

        public int FibonacciOptimized(int n, int[] calculated)
        {
            if (calculated[n] != 0)
            {
                return calculated[n];
            }

            if (n == 0)
            {
                return 0;
            }

            //if (n == 1)
            //{
            //    return 1;
            //}

            calculated[n] = FibonacciOptimized(n - 1, calculated) + FibonacciOptimized(n - 2, calculated);
            return calculated[n];
        }

        //private int[] Fibonacci(int n, int[] result)
        //{
        //    if (n == 0)
        //    {
        //        return result;
        //    }

        //    if (result.Length >= 2)
        //    {
        //        int[] numbers = new int[result.Length + 1];
        //        for(int i = 0; i < result.Length; i++)
        //        {
        //            numbers[i] = result[i];
        //        }

        //        numbers[numbers.Length - 1] = (result[result.Length - 1] + result[result.Length - 2]);

        //        return Fibonacci(n - 1, numbers);
        //    }

        //    if (result.Length == 1)
        //    {
        //        return Fibonacci(n - 1, new int[] { 1, 1 });
        //    }

        //    if (result.Length == 0)
        //    {
        //        return Fibonacci(n - 1, new int[] { 1 });
        //    }

        //    return null; //never gonna happen ;)
        //}
    }
}
