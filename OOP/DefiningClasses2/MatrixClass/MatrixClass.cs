using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixClass
{
    public class Matrix<T>
        where T : struct
    {
        public int Rows { get; set; }
        public int Cols { get; set; }
        private T[,] matrix;

        public Matrix(int rows, int cols)
        {
            this.Rows = rows;
            this.Cols = cols;
            this.matrix = new T[rows, cols];
        }

        public T this[int row, int col]
        {
            get
            {
                if ((row < 0 || this.Rows < row) ||
                    (col < 0 || this.Cols < col))
                {
                    throw new IndexOutOfRangeException();
                }
                return this.matrix[row, col];
            }
            set
            {
                if ((row < 0 || this.Rows < row) ||
                       (col < 0 || this.Cols < col))
                {
                    throw new IndexOutOfRangeException();
                }
                this.matrix[row, col] = value;
            }
        }

        public static Matrix<T> operator +(Matrix<T> matrixOne, Matrix<T> matrixTwo)
        {
            if (matrixOne.Cols != matrixTwo.Cols ||
                matrixOne.Rows != matrixTwo.Rows)
            {
                throw new Exception("The matrixes aren't the same size.");
            }

            for (int i = 0; i < matrixOne.Rows; i++)
            {
                for (int j = 0; j < matrixOne.Cols; j++)
                {
                    matrixOne[i, j] += (dynamic)matrixTwo[i, j];
                }
            }
            return matrixOne;
        }

        public static Matrix<T> operator -(Matrix<T> matrixOne, Matrix<T> matrixTwo)
        {
            if (matrixOne.Cols != matrixTwo.Cols ||
                matrixOne.Rows != matrixTwo.Rows)
            {
                throw new Exception("The matrixes aren't the same size.");
            }
            for (int i = 0; i < matrixOne.Rows; i++)
            {
                for (int j = 0; j < matrixOne.Cols; j++)
                {
                    matrixOne[i, j] -= (dynamic)matrixTwo[i, j];
                }
            }
            return matrixOne;
        }
        
        public static Matrix<T> operator *(Matrix<T> matrixOne, Matrix<T> matrixTwo)
        {
            if (matrixOne.Cols != matrixTwo.Rows)
            {
                throw new Exception("The matrices cannot be multiplied.");
            }

            T temp;
            for (int matrixRow = 0; matrixRow < matrixOne.Rows; matrixRow++)
            {
                for (int matrixCol = 0; matrixCol < matrixOne.Cols; matrixCol++)
                {
                    temp = (dynamic)0;
                    for (int index = 0; index < matrixOne.Cols; index++)
                    {
                        temp += (dynamic)matrixOne[matrixRow, index] * matrixTwo[index, matrixCol];
                    }
                    matrixOne[matrixRow, matrixCol] = (dynamic)temp;
                }
            }

            return matrixOne;
        }

        public static bool operator true(Matrix<T> matrix)
        {
            for (int row = 0; row < matrix.Rows; row++)
            {
                for (int col = 0; col < matrix.Cols; col++)
                {
                    if (matrix[row, col].Equals(default(T)))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static bool operator false(Matrix<T> matrix)
        {
            for (int row = 0; row < matrix.Rows; row++)
            {
                for (int col = 0; col < matrix.Cols; col++)
                {
                    if (!matrix[row, col].Equals(default(T)))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public override string ToString()
        {
            string printer = "";
            printer = printer + Environment.NewLine;
            for (int row = 0; row < this.Rows; row++)
            {
                for (int col = 0; col < this.Cols; col++)
                {
                    printer = printer + this.matrix[row, col] + " ";
                }
                printer = printer + Environment.NewLine;
            }

            return printer;
        }

    }
}
