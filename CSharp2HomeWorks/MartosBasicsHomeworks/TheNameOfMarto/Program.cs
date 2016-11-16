using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheNameOfMarto
{
    public class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            Program p = new Program();

            string output = p.CreateOutputFromName(name);

            Console.WriteLine(output);
            Console.ReadLine();
        }

        public string CreateOutputFromName(string name)
        {
            if (name == null)
            {
                throw new NullReferenceException("The value of the parameter name is Null!");
            }
            if (name == "")
            {
                throw new ArgumentException("You should enter a name!");
            }
            string output = "Hello my name is \"" + name + "\"";
            return output;
        }
    }
}
