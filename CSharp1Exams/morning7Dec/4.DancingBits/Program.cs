using System;

namespace _4.DancingBits
{
    class Program
    {
        static void Main(string[] args)
        {
            int k = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            int[] numbers = new int[n];

            int sequenceCounter = 0;
            string[] binaryOfNumbers = new string[n];
            string sentence = "";

            for (int i = 0; i < n; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
                binaryOfNumbers[i] = Convert.ToString(numbers[i], 2);
                sentence = sentence + binaryOfNumbers[i];
            }

            int length = 0;
            char lastBit = ' ';

            for (int i = 0; i < sentence.Length; i++)
            {
                if (sentence[i] == lastBit)
                {
                    length++;
                }
                else
                {
                    if (length == k)
                    {
                        sequenceCounter++;
                    }
                    length = 1;
                }
                lastBit = sentence[i];
            }

            if (k == length)
            {
                sequenceCounter++;
            }

            Console.WriteLine(sequenceCounter);

        }
    }
}
