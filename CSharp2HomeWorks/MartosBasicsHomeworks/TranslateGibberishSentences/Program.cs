using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TranslateGibberishSentences
{
    public class Program
    {
        static void Main(string[] args)
        {
            string sentence = Console.ReadLine();
            Program p = new Program();
            string answer = p.TranslateGibberishSentence(sentence);

            Console.WriteLine(answer);
        }

        public string TranslateGibberishSentence(string sentence)
        {
            if (string.IsNullOrEmpty(sentence))
            {
                throw new ArgumentException("Empty sentence! Why ?");
            }
            if (sentence.Length == 1)
            {
                return sentence.ToUpper();
            }

            string sentenceWithoutSpaceAtTheEnd = sentence.TrimEnd(' ');

            string[] splitSentence;
            splitSentence = sentenceWithoutSpaceAtTheEnd.Split(' ');
            Array.Reverse(splitSentence);

            string output = string.Join(" ", splitSentence);

            return output[0].ToString().ToUpper() + output.Substring(1);
        }
    }
}
