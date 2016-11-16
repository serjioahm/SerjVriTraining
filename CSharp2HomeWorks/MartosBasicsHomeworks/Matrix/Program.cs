using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;

namespace Matrix
{
    public class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"../../fileWithNegativeOnTheFirstLine.txt";

            Program p = new Program();

            int[,] matrix = p.ReadMatrixFromTextFile(filePath);

            List<int> byRow = p.GetRowElements(matrix);
            List<int> byColumn = p.GetElementsByColumn(matrix);
            List<int> byTriangle = p.ByTriangle(matrix);
            List<int> bySpiral = p.BySpiral(matrix);

            int rowLength = matrix.GetLength(0);
            int colLength = matrix.GetLength(1);

            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {
                    Console.Write(string.Format("{0} ", matrix[i, j]));
                }
                Console.WriteLine();
            }

            Console.WriteLine("RowElements :");
            Console.WriteLine(string.Join(" ", byRow));
            Console.WriteLine("Elements by column :");
            Console.WriteLine(string.Join(" ", byColumn));
            Console.WriteLine("Elements by triangle :");
            Console.WriteLine(string.Join(" ", byTriangle));
            Console.WriteLine("Elements by spiral :");
            Console.WriteLine(string.Join(" ", bySpiral));
            Console.ReadLine();
        }

        public int[,] ReadMatrixFromTextFile(string input)
        {
            bool fileExist = File.Exists(input);
            if (fileExist == false)
            {
                throw new System.IO.FileNotFoundException("The file doesnt exist!");
            }

            int possiblePath = input.IndexOfAny(Path.GetInvalidPathChars());


            if (possiblePath != -1)
            {
                throw new FormatException("The path name consists of invalid characters!The number of invalid characters is" + possiblePath);
            }


            string tekst = File.ReadAllText(input);
            string firstLine = File.ReadLines(input).First();
            int length = int.Parse(firstLine);

            if (length == 0)
            {
                throw new IndexOutOfRangeException("The length of the 2d array is zero!");
            }

            int[,] result = new int[length, length];

            int i = 0, j = 0;
            foreach (var row in tekst.Split('\n').Skip(1))
            {
                j = 0;
                foreach (var col in row.Trim().Split(' '))
                {
                    result[i, j] = int.Parse(col.Trim());
                    j++;
                }
                i++;
            }

            return result;
        }

        public List<int> GetRowElements(int[,] matrix)
        {
            List<int> elementsInRows = new List<int>(matrix.GetLength(0) * matrix.GetLength(1));

            int element = 0;
            int row = matrix.GetLength(0);
            int col = matrix.GetLength(1);
            bool kvadratna = row.Equals(col);
            if (!kvadratna)
            {
                throw new ArgumentOutOfRangeException("The matrix is not square!");
            }

            for (row = 0; row < matrix.GetLength(0); row++)
            {
                for (col = 0; col < matrix.GetLength(1); col++)
                {
                    element = matrix[row, col];
                    elementsInRows.Add(element);
                }
            }

            return elementsInRows;
        }

        public List<int> GetElementsByColumn(int[,] matrix)
        {
            List<int> elementsByColumns = new List<int>(matrix.GetLength(0) * matrix.GetLength(1));
            int element = 0;
            int row = matrix.GetLength(0);
            int col = matrix.GetLength(1);
            bool kvadratna = row.Equals(col);
            if (!kvadratna)
            {
                throw new ArgumentOutOfRangeException("The matrix is not square!");
            }
            for (col = 0; col < matrix.GetLength(1); col++)
            {
                for (row = 0; row < matrix.GetLength(0); row++)
                {
                    element = matrix[row, col];
                    elementsByColumns.Add(element);
                }
            }

            return elementsByColumns;
        }

        public List<int> ByTriangle(int[,] matrix)
        {
            List<int> topTriangle = new List<int>(matrix.GetLength(0) * matrix.GetLength(1));

            int element = 0;
            int row = matrix.GetLength(0);
            int col = matrix.GetLength(1);
            bool kvadratna = row.Equals(col);
            if (!kvadratna)
            {
                throw new ArgumentOutOfRangeException("The matrix is not square!");
            }
            int decreasingCol = 0;

            for (col = 0; col < matrix.GetLength(1); col++)
            {
                decreasingCol = col;
                for (row = 0; row <= col; row++)
                {
                    element = matrix[row, decreasingCol];
                    topTriangle.Add(element);
                    decreasingCol--;
                }
            }

            int increasingCol = 0;
            List<int> bottomTriangle = new List<int>();

            for (col = matrix.GetLength(1) - 1; col > 0; col--)
            {
                increasingCol = col;
                for (row = matrix.GetLength(0) - 1; row >= col; row--)
                {
                    element = matrix[row, increasingCol];
                    bottomTriangle.Add(element);

                    increasingCol++;
                }
            }

            bottomTriangle.Reverse();
            topTriangle.AddRange(bottomTriangle);

            return topTriangle;
        }

        public List<int> BySpiral(int[,] matrix)
        {
            List<int> elementsBySpiral = new List<int>();

            int startOfRow = 0;
            int endOfRow = matrix.GetLength(0);
            int startOfColumn = 0;
            int endOfColumn = matrix.GetLength(1);
            int element = 0;
            bool kvadratna = endOfRow.Equals(endOfColumn);

            if (!kvadratna)
            {
                throw new ArgumentOutOfRangeException("The matrix is not square!");
            }

            while (startOfRow < endOfRow && startOfColumn < endOfColumn)
            {
                for (int i = startOfColumn; i < endOfColumn; i++)
                {
                    element = matrix[startOfRow, i];
                    elementsBySpiral.Add(element);
                }
                startOfRow++;

                for (int i = startOfRow; i < endOfRow; i++)
                {
                    element = matrix[i, endOfColumn - 1];
                    elementsBySpiral.Add(element);
                }
                endOfColumn--;

                if (startOfRow < endOfRow)
                {
                    for (int i = endOfColumn - 1; i > startOfColumn - 1; i--)
                    {
                        element = matrix[endOfRow - 1, i];
                        elementsBySpiral.Add(element);
                    }
                    endOfRow--;
                }

                if (startOfColumn < endOfColumn)
                {
                    for (int i = endOfRow - 1; i >= startOfRow; i--)
                    {
                        element = matrix[i, startOfColumn];
                        elementsBySpiral.Add(element);
                    }
                    startOfColumn++;
                }
            }

            return elementsBySpiral;
        }


    }
}
