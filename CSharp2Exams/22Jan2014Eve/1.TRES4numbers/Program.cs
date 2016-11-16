using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.TRES4numbers
{
    public class TRES4
    {
        static void Main(string[] args)
        {
            ulong numberInDecimal = ulong.Parse(Console.ReadLine());
            ulong numeralSystem = 9;

            string[] digits = new[] 
            {
                "LON+", "VK-", "*ACAD",
                "^MIM", "ERIK|", "SEY&",
                "EMY>>", "/TEL", "<<DON"
            };

            string result = "";

            do
            {
                int digitIn9th = (int)(numberInDecimal % numeralSystem);

                result = digits[digitIn9th] + result;
                numberInDecimal /= numeralSystem;

            } while (numberInDecimal > 0);

            Console.WriteLine(result);
        }
    }
}
