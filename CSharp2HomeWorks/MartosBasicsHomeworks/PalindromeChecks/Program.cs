using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalindromeChecks
{
    public class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();

            Program p = new Program();

            string answer = p.CheckStringIfPolindrome(word);

            Console.WriteLine(answer);
        }

        public string CheckStringIfPolindrome(string word)
        {
            if (word==null)
            {
                throw new NullReferenceException("Null word! Why ?");
            }
            int firstElement = 0;
            int lastElement = word.Length - 1;

            while (firstElement < lastElement)
            {
                if (word[firstElement] != word[lastElement])
                {
                    return "no";
                }

                firstElement++;
                lastElement--;
            }

            return "yes";
        }
    }
}
