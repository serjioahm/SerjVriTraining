using MyExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ExtensionsTest
{
    public class Program
    {
        static void Main(string[] args)
        {
            StringBuilder printer = new StringBuilder();
            printer.Append("ABCDEFGHIJKLMNOPQRSTUVWXYZ");
            Console.WriteLine(printer.Substring(2, 4));

            List<int> listExp = new List<int>();
            int[] arrExp = new int[] { 2, 3, 4, 5, 6 };
            listExp = arrExp.ToList();

            int min = listExp.Min2();
            Console.WriteLine("The min is: " + min);
            int max = listExp.Max2();
            Console.WriteLine("The max is: " + max);
            double avgExample = arrExp.Avg2();
            Console.WriteLine("The avg is: {0:F2}", avgExample);
            int sum = listExp.Sum2();
            Console.WriteLine("The sum is: " + sum);
            int product = arrExp.Product2();
            Console.WriteLine("The product is: " + product);
            Console.WriteLine();
        }
    }
}
