using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._7SegmentDisplay
{
    public class SevenSegmentDisplay
    {
        static StringBuilder sb = new StringBuilder();
        static void Main()
        {
            int n = int.Parse(Console.ReadLine()); // number of displays
            //int n = 1;
            int[,] inputDigits = new int[n, 7];
            //int[,] inputDigits = { { 1011111 } };
            List<string> result = new List<string>();
            SevenSegmentDisplay p = new SevenSegmentDisplay();

            for (int row = 0; row < n; row++)
            {
                string currentLine = Console.ReadLine().Trim();
                for (int col = 0; col < 7; col++)
                {
                    inputDigits[row, col] = int.Parse(currentLine[col].ToString());
                }
            }

            int overallNumberOfResults = 0;
            int lastResult = 0;
            for (int i = n - 1; i >= 0; i--)
            {
                if (result.Count != 0)
                {
                    p.CombiningResults(inputDigits, result, i, overallNumberOfResults, lastResult);
                    lastResult = overallNumberOfResults;
                    overallNumberOfResults = result.Count;
                }
                else
                {
                    p.ChecksForPosibleDigits(inputDigits, result, i);
                    overallNumberOfResults = result.Count;

                }
            }

            Console.WriteLine(overallNumberOfResults - lastResult);
            for (int i = lastResult; i < overallNumberOfResults; i++)
            {
                Console.WriteLine(result[i]);
            }
        }

        public void ChecksForPosibleDigits(int[,] digits, List<string> result, int displayNumber)
        {
            if (digits[displayNumber, 6] == 0)
            {
                result.Add("0");
            }
            if (digits[displayNumber, 0] == 0 && digits[displayNumber, 3] == 0 && digits[displayNumber, 4] == 0 && digits[displayNumber, 5] == 0 && digits[displayNumber, 6] == 0)
            {
                result.Add("1");
            }
            if (digits[displayNumber, 2] == 0 && digits[displayNumber, 5] == 0)
            {
                result.Add("2");
            }
            if (digits[displayNumber, 4] == 0 && digits[displayNumber, 5] == 0)
            {
                result.Add("3");
            }
            if (digits[displayNumber, 0] == 0 && digits[displayNumber, 3] == 0 && digits[displayNumber, 4] == 0)
            {
                result.Add("4");
            }
            if (digits[displayNumber, 1] == 0 && digits[displayNumber, 4] == 0)
            {
                result.Add("5");
            }
            if (digits[displayNumber, 1] == 0)
            {
                result.Add("6");
            }
            if (digits[displayNumber, 3] == 0 && digits[displayNumber, 4] == 0 && digits[displayNumber, 5] == 0 && digits[displayNumber, 6] == 0)
            {
                result.Add("7");
            }
            result.Add("8");
            if (digits[displayNumber, 4] == 0)
            {
                result.Add("9");
            }




        }
        public void CombiningResults(int[,] digits, List<string> result, int displayNumber, int overallNumberOfResults, int startIndex)
        {
            if (digits[displayNumber, 6] == 0)
            {
                AddToResult("0", result, overallNumberOfResults, startIndex);
            }
            if (digits[displayNumber, 0] == 0 && digits[displayNumber, 3] == 0 && digits[displayNumber, 4] == 0 && digits[displayNumber, 5] == 0 && digits[displayNumber, 6] == 0)
            {
                AddToResult("1", result, overallNumberOfResults, startIndex);
            }
            if (digits[displayNumber, 2] == 0 && digits[displayNumber, 5] == 0)
            {
                AddToResult("2", result, overallNumberOfResults, startIndex);
            }
            if (digits[displayNumber, 4] == 0 && digits[displayNumber, 5] == 0)
            {
                AddToResult("3", result, overallNumberOfResults, startIndex);
            }
            if (digits[displayNumber, 0] == 0 && digits[displayNumber, 3] == 0 && digits[displayNumber, 4] == 0)
            {
                AddToResult("4", result, overallNumberOfResults, startIndex);
            }
            if (digits[displayNumber, 1] == 0 && digits[displayNumber, 4] == 0)
            {
                AddToResult("5", result, overallNumberOfResults, startIndex);
            }
            if (digits[displayNumber, 1] == 0)
            {
                AddToResult("6", result, overallNumberOfResults, startIndex);
            }
            if (digits[displayNumber, 3] == 0 && digits[displayNumber, 4] == 0 && digits[displayNumber, 5] == 0 && digits[displayNumber, 6] == 0)
            {
                AddToResult("7", result, overallNumberOfResults, startIndex);
            }
            AddToResult("8", result, overallNumberOfResults, startIndex);
            if (digits[displayNumber, 4] == 0)
            {
                AddToResult("9", result, overallNumberOfResults, startIndex);
            }




        }

        public void AddToResult(string currentSymbol, List<string> result, int overallNumberOfResults, int startIndex)
        {
            for (int i = startIndex; i < overallNumberOfResults; i++)
            {
                sb.Clear();
                sb.Append(currentSymbol);
                sb.Append(result[i]);
                result.Add(sb.ToString());

            }
        }


    }
}
