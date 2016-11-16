using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.Brackets
{
    public class BracketsHandler
    {
        public int CalculateSolutions(string input)
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

                    if (IsCorrect(element, nextQuestionMark))
                    {
                        elements.Add(new StringBuilder(element.ToString()));
                    }

                    element[nextQuestionMark] = ')';

                    if (IsCorrect(element, nextQuestionMark))
                    {
                        elements.Add(new StringBuilder(element.ToString()));
                    }
                }
                else
                {
                    //if (IsCorrect(element, element.Length - 1))
                    //{
                        solutions++;
                    //}
                }
            }

            return solutions;
        }

        public bool IsCorrect(StringBuilder template, int position)
        {
            int openingBracketsCount = 0;
            int closingBracketsCount = 0;

            for (int i = 0; i <= position; i++)
            {
                var character = template[i];
                if (character == '(')
                {
                    openingBracketsCount++;
                }
                else if (character == ')')
                {
                    closingBracketsCount++;
                }
            }

            int questionMarksCount = 0;
            for (int i = position + 1; i < template.Length; i++)
            {
                var character = template[i];
                if (character == '?')
                {
                    questionMarksCount++;
                }
            }

            return openingBracketsCount >= closingBracketsCount &&
                openingBracketsCount <= closingBracketsCount + questionMarksCount;
        }
    }
}
