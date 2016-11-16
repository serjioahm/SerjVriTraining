using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5ListSubsets
{
    class Program
    {
        static void Main(string[] args)
        {
            //int n = int.Parse(Console.ReadLine());
            int n = 3;
            string[] numbers = new string[] { "1","2","3"};
            

            //for (int i = 0; i < n; i++)
            //{
            //    numbers[i] = Console.ReadLine();
            //}

            List<string> elements = new List<string>();
            elements.Add("");

            for (int i = 0; i < n; i++)
            {
                List<string> newElements = new List<string>();
                for (int j = 0; j < elements.Count; j++)
                {
                    string newElem = elements[j] + numbers[i];
                    newElements.Add(newElem);
                }
                elements.AddRange(newElements);
            }
            Console.WriteLine(string.Join(" ", elements));
        }
    }
}
