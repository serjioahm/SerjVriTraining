using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsecutiveLettersToOne
{
    public class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();

            Program p = new Program();

            string answer = p.DeleteConsecutiveLetters(word);

            Console.WriteLine(answer);
        }

        public string DeleteConsecutiveLetters(string word)
        {
            if (string.IsNullOrEmpty(word))
            {
                throw new ArgumentException("Empty word! But why ?");
            }

            if (word.Length < 2)
            {
                return word;
            }

            char prevChar = ' ';
            StringBuilder sb = new StringBuilder();
            foreach (char chr in word)
            {
                if (chr != prevChar)
                {
                    sb.Append(chr);
                    prevChar = chr;
                }
            }
            string answer = sb.ToString();
            return answer;
        }
    }
}
