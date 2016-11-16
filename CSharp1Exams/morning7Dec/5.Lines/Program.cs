using System;
using System.Linq;

namespace _5.Lines
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfLines = 8;
            int[] numbers = new int[numberOfLines];

            for (int i = 0; i < numberOfLines; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }

            string[] binaryOfNumbers = new string[numberOfLines];

            for (int i = 0; i < numberOfLines; i++)
            {
                binaryOfNumbers[i] = Convert.ToString(numbers[i], 2).PadLeft(8, '0');
            }

            string[,] eachElement = new string[8, 8];
            char[] line = new char[8];

            for (int i = 0; i < 8; i++)
            {
                line = binaryOfNumbers[i].ToArray();

                for (int j = 0; j < 8; j++)
                {
                    eachElement[i, j] = line[j].ToString();
                }
            }

            int sequenceLength = 0;
            int longestLength = 0;
            int appearanceCounterOfLongest = 0;

            for (int row = 0; row < 8; row++)
            {
                sequenceLength = 0;
                for (int col = 0; col < 8; col++)
                {
                    if (eachElement[row, col] == "1")
                    {
                        sequenceLength++;
                        if (sequenceLength > longestLength)
                        {
                            longestLength = sequenceLength;
                            appearanceCounterOfLongest = 0;
                        }
                        if (sequenceLength == longestLength)
                        {
                            appearanceCounterOfLongest++;
                        }
                    }
                    else
                    {
                        sequenceLength = 0;
                    }
                }
                
            }

            for (int row = 0; row < 8; row++)
            {
                sequenceLength = 0;
                for (int col = 0; col < 8; col++)
                {
                    if (eachElement[col, row] == "1")
                    {
                        sequenceLength++;
                        if (sequenceLength > longestLength)
                        {
                            longestLength = sequenceLength;
                            appearanceCounterOfLongest = 0;
                        }
                        if (sequenceLength == longestLength)
                        {
                            appearanceCounterOfLongest++;
                        }
                    }
                    else
                    {
                        sequenceLength = 0;
                    }
                }
            }

            if (longestLength == 1)
            {
                appearanceCounterOfLongest = appearanceCounterOfLongest / 2;
            }

            Console.WriteLine(longestLength);
            Console.WriteLine(appearanceCounterOfLongest);
        }
    }
}
