using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VersionAttribute
{
    [Attributes("1.67")]
    public class Program
    {
        static void Main(string[] args)
        {
            Type type = typeof(Program);
            object[] allAttributes = type.GetCustomAttributes(false);
            foreach (Attributes authorAttribute in allAttributes)
            {
                Console.WriteLine("Version: ",
                    authorAttribute.Version);
            }


        }
    }
}
