using System;
using System.Linq;

namespace _5.FallDown
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

            int counterOfOnes = 0;
            int[,] preOrderedMatrix = new int[8, 8];

            for (int i = 0; i < 8; i++)
            {
                counterOfOnes = 0;
                for (int j = 0; j < 8; j++)
                {
                    if (eachElement[j, i] == "1")
                    {
                        counterOfOnes++;
                    }
                }

                for (int j = 7; j > 7 - counterOfOnes; j--)
                {
                    if (counterOfOnes != 0)
                    {
                        preOrderedMatrix[j, i] = 1;
                    }
                }
            }

            binaryOfNumbers = new string[numberOfLines];

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    binaryOfNumbers[i] = binaryOfNumbers[i] + preOrderedMatrix[i, j];
                }
            }

            int[] resultDecimal = new int[8];

            for (int i = 0; i < numberOfLines; i++)
            {
                resultDecimal[i] = Convert.ToInt32(binaryOfNumbers[i], 2);
                //binaryOfNumbers[i] = Convert.ToString(resultDecimal[i]);
            }

            Console.WriteLine("");
            for (int i = 0; i < 8; i++)
            {
                Console.WriteLine(resultDecimal[i]);
            }


        }
    }
}
