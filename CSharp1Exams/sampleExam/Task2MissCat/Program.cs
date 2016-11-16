using System;

namespace Task2MissCat
{
    class Program
    {
        static void Main(string[] args)
        {
            int arrayLength = int.Parse(Console.ReadLine());
            int[] array = new int[arrayLength];

            for (int i = 0; i < arrayLength; i++)
            {
                array[i] = int.Parse(Console.ReadLine());
            }

            Array.Sort(array);

            int maxCounter = 1;
            int tempCounter = 1;
            int mostFrequentNumber = 0;

            //if (arrayLength == 1)
            //{
            //    mostFrequentNumber = array[0];
            //}

            for (int i = 0; i < arrayLength - 1; i++)
            {
                if (array[i] == array[i + 1])
                {
                    tempCounter++;
                }
                else
                {
                    if (tempCounter > maxCounter)
                    {
                        maxCounter = tempCounter;
                        mostFrequentNumber = array[i];
                        tempCounter = 1;
                    }
                    else
                    {
                        tempCounter = 1;
                    }
                }
            }

            if (tempCounter > maxCounter)
            {
                maxCounter = tempCounter;
                mostFrequentNumber = array[array.Length - 1];
            }

            Console.WriteLine(mostFrequentNumber);
        }
    }
}
