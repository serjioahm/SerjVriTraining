using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LargerThanNeighbours
{
    public class Program
    {
        static void Main(string[] args)
        {
            //read the numbers from the console
            string input = Console.ReadLine();

            Program p = new Program();
            int result = p.CountLargerThanNeighbours(input);

            Console.WriteLine("The count of numbers that are larger than their neighbours is: " + result);
        }
        
        public int CountLargerThanNeighbours(string input)
        {
            string[] stringNumbers = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            //get all numbers as integers
            int[] numbers = ConvertStringArrayToIntegerArray(stringNumbers);

            //create a counter
            int counter = 0;

            //foreach number increment counter if larger
            for (int i = 0; i < numbers.Length; i++)
            {
                bool isLargerThanNeighbours = IsLargerThanNeighbours(i, numbers);

                if (isLargerThanNeighbours)
                {
                    counter++;
                }
            }

            return counter;
        }

        public int[] ConvertStringArrayToIntegerArray(string[] stringNumbers)
        {
            if (stringNumbers == null)
            {
                throw new NullReferenceException("The string array can not be null!");
            }

            int[] numbers = new int[stringNumbers.Length];

            for(int i = 0; i < stringNumbers.Length; i++)
            {
                numbers[i] = int.Parse(stringNumbers[i]);
            }

            return numbers;
        }

        public bool IsLargerThanNeighbours(int index, int[] array)
        {
            if (array == null || array.Length < 1)
            {
                throw new ArgumentException("Array is null or empty!");
            }

            if (index > array.Length || index < 0)
            {
                throw new IndexOutOfRangeException("The index is not a valid number!");
            }

            if (index == 0)
            {
                return array[0] > array[1];
            }

            if (index == array.Length - 1)
            {
                return array[index] > array[index - 1];
            }

            bool isLarger = array[index] > array[index - 1];
            isLarger = isLarger && array[index] > array[index + 1];

            return isLarger;
        }

        


    }
}
