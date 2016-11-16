using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Patterns
{
    public class Patterns
    {
        static void Main(string[] args)
        {
            int[,] matrix = Input();

            bool hasCorrectPattern = false;

            bool[,] successfullPattern = new bool[3, 5];
           
            int successfullPatternHeigh = successfullPattern.GetLength(0);
            int successfullPatternWidth = successfullPattern.GetLength(1);

            long maxSum = 0;

            for (int patternStartX = 0; patternStartX <= matrix.GetLength(0) - successfullPatternHeigh; patternStartX++)
            {
                for (int patternStartY = 0; patternStartY <= matrix.GetLength(1) - successfullPatternWidth; patternStartY++)
                {
                    List<int> numbersInPattern = new List<int>();

                    for (int patternX = 0; patternX < successfullPatternHeigh; patternX++)
                    {
                        for (int patternY = 0; patternY < successfullPatternWidth; patternY++)
                        {
                            // X-position, on which we start to search + the current X on pattern
                            int x = patternStartX + patternX;
                            int y = patternStartY + patternY;

                            if ((patternX == 0 && patternY <= 2) || (patternX == 1 && patternY == 2) || (patternX == 2 && patternY >= 2))
                            {
                                numbersInPattern.Add(matrix[x, y]);
                            }
                        }
                    }

                    bool foundCorrectPattern = true;
                    for (int i = 1; i < numbersInPattern.Count; i++)
                    {
                        if (numbersInPattern[i - 1] != numbersInPattern[i] - 1)
                        {
                            foundCorrectPattern = false;
                            break;
                        }
                    }

                    if (foundCorrectPattern)
                    {
                        hasCorrectPattern = true;
                        long sum = 0;
                        foreach (var item in numbersInPattern)
                        {
                            sum += item;
                        }

                        maxSum = Math.Max(maxSum, sum);
                    }
                }
            }

            if (hasCorrectPattern)
            {
                Console.WriteLine("YES {0}", maxSum);
            }
            else
            {
                Console.WriteLine("NO {0}", SumDiagonal(matrix));
            }
        }
        public static int[,] Input()
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();
                string[] numbersAsString = line.Split(' ');

                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = int.Parse(numbersAsString[j]);
                }
            }

            return matrix;
        }
        public static long SumDiagonal(int[,] matrix)
        {
            long sum = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                sum += matrix[i, i];
            }

            return sum;
        }


    }
}
