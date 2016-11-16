using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixClass
{
    class Program
    {
        static void Main(string[] args)
        {
            //int rows = 4;
            //int cols = 4;
            //Matrix<int> matrixOne = new Matrix<int>(rows, cols);
            //for (int i = 0; i < matrixOne.Rows; i++)
            //{
            //    for (int j = 0; j < matrixOne.Cols; j++)
            //    {
            //        matrixOne[i, j] += i;
            //    }
            //}
            //Console.WriteLine("Matrix one is :" + matrixOne);
            //Matrix<int> matrixTwo = new Matrix<int>(rows, cols);
            //for (int i = 0; i < matrixTwo.Rows; i++)
            //{
            //    for (int j = 0; j < matrixTwo.Cols; j++)
            //    {
            //        matrixTwo[i, j] += i;
            //    }
            //}
            //Console.WriteLine("Matrix two is :" + matrixTwo);
            //Console.WriteLine("Adding results : " + (matrixOne + matrixTwo));
            //Console.WriteLine("Subtraction results : " + (matrixOne - matrixTwo));
            //Console.WriteLine("Multiplication results : " + (matrixOne * matrixTwo));

            Matrix<float> matrix = new Matrix<float>(2, 2);
            matrix[0, 0] = 0.0f;
            matrix[1, 0] = 0.0f;
            matrix[0, 1] = 0.0f;
            matrix[1, 1] = 0.0f;

            if (matrix)
            {
                Console.WriteLine("its true!");
            }
            else
            {
                Console.WriteLine("its not!");
            }

            Matrix<float> matrixFalse = new Matrix<float>(2, 2);
            matrixFalse[0, 0] = 1.0f;
            matrixFalse[1, 0] = 2.0f;
            matrixFalse[0, 1] = 3.0f;
            matrixFalse[1, 1] = 4.0f;

            if (matrixFalse)
            {
                Console.WriteLine("its true!");
            }
            else
            {
                Console.WriteLine("its not!");
            }
        }
    }
}
