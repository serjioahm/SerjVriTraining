using System;
using System.Numerics;

class SubsetSum
{
    static void Main()
    {
        BigInteger sum = BigInteger.Parse(Console.ReadLine());
        int n = int.Parse(Console.ReadLine());
        BigInteger[] numbers = new BigInteger[n];
        BigInteger subsets = 0;
        for (int i = 0; i < n; i++)
        {
            numbers[i] = BigInteger.Parse(Console.ReadLine());
        }
        for (int i = 1; i < Math.Pow(2, n); i++)
        {
            string currentNumber = Convert.ToString(i, 2).PadLeft(n, '0');
            BigInteger currentSum = 0;
            for (int k = 0; k < currentNumber.Length; k++)
            {
                if (currentNumber[k] == '1')
                {
                    currentSum += numbers[k];
                }
            }
            if (currentSum == sum)
            {
                subsets++;
            }
        }
        Console.WriteLine(subsets);
    }
}

