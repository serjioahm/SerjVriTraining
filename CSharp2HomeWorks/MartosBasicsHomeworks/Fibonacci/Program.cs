using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int n = int.Parse(input);

            //1.Recursive
            Recursive recursive = new Recursive();
            Console.WriteLine("Recursive:");
            TimeN(() => recursive.Fibonacci(n));

            //2. Linear
            //Linear linear = new Linear();
            //Console.WriteLine("Linear:");
            //Time(() => linear.Fibonacci(n));

            ////3. Dynamic
            //Dynamic dynamic = new Dynamic();
            //Console.WriteLine("Dynamic:");
            //Time(() => dynamic.Fibonacci(n));

            Console.WriteLine("Recursive Optimized:");
            int[] cachedValues = new int[n + 1];
            cachedValues[1] = 1;

            TimeN(() => recursive.FibonacciOptimized(n, cachedValues));

            Console.ReadLine();
        }

        public static void Time(Expression<Func<int[]>> fibonacci)
        {
            DateTime start = DateTime.Now;
            var func = fibonacci.Compile();
            var sequence = func();
            DateTime end = DateTime.Now;
            var difference = end - start;
            PrintSequence(sequence);
            PrintTimelapse(difference);
        }

        public static void TimeN(Expression<Func<int>> fibonacci)
        {
            DateTime start = DateTime.Now;
            var func = fibonacci.Compile();
            var number = func();
            DateTime end = DateTime.Now;
            var difference = end - start;
            Console.WriteLine(number);
            PrintTimelapse(difference);
        }

        public static void PrintSequence(int[] sequence)
        {
            foreach (var item in sequence)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }

        public static void PrintTimelapse(TimeSpan span)
        {
            string lapse = string.Format("Miliseconds: {0}", span.Milliseconds);
            Console.WriteLine(lapse);
            Console.WriteLine();
        }
    }
}
