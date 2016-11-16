using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericClass
{
    class Program
    {
        static void Main(string[] args)
        {
            GenericList<int> newList = new GenericList<int>();

            //newList.AddElement(1);
            
            //newList.AddElement(2);
            //newList.AddElement(35);
            //newList.AddElement(543);
            ////newList.AddElement(353);
            ////newList.AddElement(351);
            ////for (int i = 0; i < 100; i++)
            ////{
            ////    newList.AddElement(i);
            ////}

            ////newList.InsertAt(5, 0);
            ////newList.InsertAt(7, 0);
            ////newList.InsertAt(9, 0);
            ////newList.RemoveAt(4);

            //Console.WriteLine("List: " + newList.ToString());
            //Console.WriteLine("Min: " + newList.Min());
            //Console.WriteLine("Max: " + newList.Max());
            //Console.WriteLine("Position of 543 (starting from the begining): " + newList.IndexOf(543));
            //Console.WriteLine("The element at position 1 is: " + newList[1]);

            ////newList.ClearList();

            //var item = newList[7];
            //Console.WriteLine(item);

        }
    }
}
