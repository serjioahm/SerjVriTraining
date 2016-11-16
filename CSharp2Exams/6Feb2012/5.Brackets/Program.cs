using _5.Brackets;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

class Program
{
    static void Main()
    {
        string input = Console.ReadLine();

        BracketsHandler handler = new BracketsHandler();
        var result = handler.CalculateSolutions(input);

        Console.WriteLine(result);


        //string input = Console.ReadLine();
        ////string input = "";
        ////for (int i = 0; i < 16; i++)
        ////{
        ////    input = input + '?';
        ////}
        //int openBracketCounter = 0;
        //int closingBracketCounter = 0;

        //if (input.Length % 2 != 0)
        //{
        //    throw new ArgumentException();
        //}

        //StringBuilder sb = new StringBuilder();
        //List<string> currentAllAnswers = new List<string>();
        //// List<string> answers2 = new List<string>();
        //List<string> cutAnswer = new List<string>();
        //bool knownCharacter = false;
        //cutAnswer.Add("");

        //string currentWord = "";

        //for (int i = 0; i < input.Length; i++)
        //{
        //    if (input[i] == '(' || input[i] == ')')
        //    {
        //        char currentBracket = input[i];
        //        knownCharacter = true;
        //        for (int z = 0; z < cutAnswer.Count; z++)
        //        {
        //            cutAnswer[z] = cutAnswer[z] + currentBracket;
        //        }
        //    }
        //    else
        //    {
        //        currentAllAnswers = new List<string>();
        //        knownCharacter = false;
        //        for (int j = 0; j < 2; j++)
        //        {
        //            foreach (var item in cutAnswer)
        //            {
        //                sb = new StringBuilder();
        //                sb.Append(item);
        //                if (j == 0)
        //                {
        //                    sb.Append('(');
        //                }
        //                else
        //                {
        //                    sb.Append(')');
        //                }
        //                currentWord = sb.ToString();
        //                currentAllAnswers.Add(currentWord);
        //            }
        //        }
        //    }

        //    if (knownCharacter == false)
        //    {
        //        cutAnswer = new List<string>();
        //        cutAnswer.AddRange(currentAllAnswers);

        //    }
        //    for (int index = 0; index < cutAnswer.Count; index++)
        //    {
        //        openBracketCounter = cutAnswer[index].Split('(').Length - 1;
        //        closingBracketCounter = cutAnswer[index].Split(')').Length - 1;
        //        int difference = openBracketCounter - closingBracketCounter;
        //        if (difference < 0)
        //        {
        //            cutAnswer.RemoveAt(index);
        //            index--;
        //        }
        //    }

        //}


        //for (int i = 0; i < cutAnswer.Count; i++)
        //{
        //    openBracketCounter = cutAnswer[i].Split('(').Length - 1;
        //    closingBracketCounter = cutAnswer[i].Split(')').Length - 1;
        //    if (openBracketCounter != closingBracketCounter)
        //    {
        //        cutAnswer.RemoveAt(i);
        //        i--;
        //    }
        //}

        //Console.WriteLine(cutAnswer.Count);

    }
}

