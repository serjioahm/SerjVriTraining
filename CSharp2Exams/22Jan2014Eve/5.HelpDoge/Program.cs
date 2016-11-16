using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _5.HelpDoge
{
    public class HelpDoge
    {
        static void Main(string[] args)
        {
            int enemyValue = -1;
            int foodX, foodY;

            string line = Console.ReadLine();
            string[] numbersAsStrings = line.Split(' ');
            int n = int.Parse(numbersAsStrings[0]);
            int m = int.Parse(numbersAsStrings[1]);

            line = Console.ReadLine();
            numbersAsStrings = line.Split(' ');
            foodX = int.Parse(numbersAsStrings[0]);
            foodY = int.Parse(numbersAsStrings[1]);

            int k = int.Parse(Console.ReadLine()); // number of enemies

            BigInteger[,] field = new BigInteger[n, m]; 
            for (int i = 0; i < k; i++)
            {
                line = Console.ReadLine();
                numbersAsStrings = line.Split(' ');
                int x = int.Parse(numbersAsStrings[0]);
                int y = int.Parse(numbersAsStrings[1]);

                field[x, y] = enemyValue;
            }

            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    if (i == 0 && j == 0)
                    {
                        field[0, 0] = 1;
                        continue;
                    }

                    //zero number of paths to the dangerous cells
                    if (field[i,j] == enemyValue)
                    {
                        field[i, j] = 0;
                        continue;
                    }

                    //moving on the first line
                    if (i == 0)
                    {
                        field[0, j] = field[0, j - 1];
                        continue;
                    }

                    //moving on the first column
                    if (j == 0)
                    {
                        field[i, 0] = field[i - 1, 0];
                        continue;
                    }

                    //each sell is equal to the sum of paths of two cells : the one left of it and the cell above it
                    field[i, j] = field[i - 1, j] + field[i, j - 1];
                }
            }

            Console.WriteLine(field[foodX,foodY]);

        }
    }
}
