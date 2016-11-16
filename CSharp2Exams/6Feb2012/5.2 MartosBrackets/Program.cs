using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5._2_MartosBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            bool hasQuestions = input.Contains('?');

            if (!hasQuestions)
            {
                Console.WriteLine(0);
            }
            else
            {
                var result = CalculateSolutions(input);
                Console.WriteLine(result);
            }
        }

        public static int CalculateSolutions(string input)
        {
            int solutions = 0;

            List<StringBuilder> elements = new List<StringBuilder>(200000);
            elements.Add(new StringBuilder(input));

            while (elements.Count > 0)
            {
                StringBuilder element = elements[elements.Count - 1];
                elements.RemoveAt(elements.Count - 1);
                int nextQuestionMark = element.ToString().IndexOf('?');

                if (nextQuestionMark >= 0)
                {
                    element[nextQuestionMark] = '(';

                    //if (IsCorrect(element))
                    //{
                        elements.Add(new StringBuilder(element.ToString()));
                    //}

                    element[nextQuestionMark] = ')';

                    //if (IsCorrect(element))
                    //{
                        elements.Add(new StringBuilder(element.ToString()));
                    //}
                }
                else
                {
                    if (IsCorrect(element))
                    {
                        solutions++;
                    }
                }
            }

            return solutions;
        }

        public static bool IsCorrect(StringBuilder template)
        {
            int openingBracketsCount = 0;

            for (int i = 0; i < template.Length; i++)
            {
                var character = template[i];

                if (character == '(')
                {
                    openingBracketsCount++;
                }
                else if (character == ')')
                {
                    openingBracketsCount--;

                    if (openingBracketsCount < 0)
                    {
                        return false;
                    }
                }
            }

            return openingBracketsCount == 0;
        }
    }
}
