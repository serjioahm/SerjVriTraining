using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;

namespace HoursSpentWorking
{
    public class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"../../workingHours.txt";
            Program p = new Program();
            string[] hours = p.ReadLinesFromTextFile(filePath);
            string[] answer = p.CalculateWorkingHoursFromTextFileLines(hours);

            if (answer.Length > 1)
            {
                for (int i = 0; i < answer.Length; i++)
                {
                    Console.WriteLine(answer[i]);
                }
            }
            else
            {
                Console.WriteLine(answer[0]);
            }

        }
        public string[] ReadLinesFromTextFile(string filepath)
        {
            bool fileExist = File.Exists(filepath);
            if (fileExist == false)
            {
                throw new System.IO.FileNotFoundException("The file doesnt exist!");
            }

            string[] lines = File.ReadAllLines(filepath);

            return lines;
        }

        public string[] CalculateWorkingHoursFromTextFileLines(string[] lines)
        {
            if (lines.Length == 0)
            {
                throw new ArgumentException("The array containing the lines of the file is empty");
            }
            string[] wordsOfCurrentLine;
            string[] devNames = new string[lines.Length];
            string[] charsOfCurrentWord;
            double[] numbersOfCurrentWord = new double[100];
            double currentHoursMarto = 0.0;
            double currentHoursJoro = 0.0;

            for (int i = 0; i < lines.Length; i++)
            {
                wordsOfCurrentLine = lines[i].Split(';');
                devNames[i] = wordsOfCurrentLine[0];
            }
            devNames = devNames.Distinct().ToArray();
            if (devNames[0] != "Marto" && devNames[0] != "Joro")
            {
                devNames = new string[1];
                devNames[0] = "Input invalid";
                return devNames;
            }
            if (devNames[1] != "Marto" && devNames[1] != "Joro")
            {
                devNames = new string[1];
                devNames[0] = "Input invalid";
                return devNames;
            }

            for (int i = 0; i < lines.Length; i++)
            {
                wordsOfCurrentLine = lines[i].Split(';');
                if (wordsOfCurrentLine.Length != 3)
                {
                    devNames = new string[1];
                    devNames[0] = "Input invalid";
                    return devNames;
                }
                if (wordsOfCurrentLine[0] == "" || wordsOfCurrentLine[1] == "" || wordsOfCurrentLine[2] == "")
                {
                    devNames = new string[1];
                    devNames[0] = "Input invalid";
                    return devNames;
                }
                charsOfCurrentWord = wordsOfCurrentLine[2].Split('+', '-');

                if (charsOfCurrentWord.Length > 1)
                {
                    if (wordsOfCurrentLine[0].Equals("Marto"))
                    {
                        currentHoursMarto += CalculateSimpleExpression(wordsOfCurrentLine[2]);
                    }

                    if (wordsOfCurrentLine[0].Equals("Joro"))
                    {
                        currentHoursJoro += CalculateSimpleExpression(wordsOfCurrentLine[2]);
                    }
                }
                else
                {
                    numbersOfCurrentWord[0] = double.Parse(charsOfCurrentWord[0]);

                    if (wordsOfCurrentLine[0].Equals("Marto"))
                    {
                        currentHoursMarto += numbersOfCurrentWord[0];
                    }

                    if (wordsOfCurrentLine[0].Equals("Joro"))
                    {
                        currentHoursJoro += numbersOfCurrentWord[0];

                    }
                }
            }
            if (currentHoursMarto < 0 || currentHoursJoro < 0)
            {
                devNames = new string[1];
                devNames[0] = "Input invalid";
                return devNames;
            }

            var stringOfMartosHours = string.Format("{0:0.00}", currentHoursMarto / 60);
            var stringOfJorosHours = string.Format("{0:0.00}", currentHoursJoro / 60);

            for (int i = 0; i < devNames.Length; i++)
            {
                if (devNames[i] == "Marto")
                {
                    devNames[i] = devNames[i] + "-" + stringOfMartosHours;
                }
                if (devNames[i] == "Joro")
                {
                    devNames[i] = devNames[i] + "-" + stringOfJorosHours;
                }
            }

            return devNames;
        }

        public double CalculateSimpleExpression(string expression)
        {
            double result = 0.0;

            string[] stringsOfNumbers = expression.Split('+', '-');
            string[] operators = expression.Split(new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" }, StringSplitOptions.RemoveEmptyEntries);
            double[] numbers = new double[stringsOfNumbers.Length];

            int indexOfFirstSubstraction = expression.IndexOf('-');
            int indexOfFirstPlus = expression.IndexOf('+');
            int indexOfFirstNumber = expression.IndexOfAny(new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' });
            if (indexOfFirstPlus==-1)
            {
                indexOfFirstPlus = indexOfFirstNumber;
            }
            if (indexOfFirstSubstraction==-1)
            {
                indexOfFirstSubstraction = indexOfFirstNumber;
            }

            if (stringsOfNumbers.Length==1)
            {
                numbers[0] = int.Parse(stringsOfNumbers[0]);
                result += numbers[0];
                return result;
            }

            if (indexOfFirstSubstraction < indexOfFirstNumber)
            {
                numbers[0] = int.Parse(stringsOfNumbers[1]);
                result = -numbers[0];

                for (int i = 1; i < operators.Length; i++)
                {

                    numbers[i] = int.Parse(stringsOfNumbers[i + 1]);
                    if (operators[i].Equals("+"))
                    {
                        result += numbers[i];
                    }

                    if (operators[i] == "-")
                    {
                        result = result - numbers[i];
                    }
                }
            }
            else if (indexOfFirstPlus < indexOfFirstNumber)
            {
                numbers[0] = int.Parse(stringsOfNumbers[1]);
                result = numbers[0];

                for (int i = 1; i < operators.Length; i++)
                {
                    numbers[i] = int.Parse(stringsOfNumbers[i]);
                    if (operators[i].Equals("+"))
                    {
                        result += numbers[i];
                    }

                    if (operators[i] == "-")
                    {
                        result -= numbers[i];
                    }
                }
            }
            else
            {
            numbers[0] = int.Parse(stringsOfNumbers[0]);
            result = numbers[0];

            for (int i = 1; i <= operators.Length; i++)
            {
                numbers[i] = int.Parse(stringsOfNumbers[i]);
                if (operators[i - 1].Equals("+"))
                {
                    result += numbers[i];
                }

                if (operators[i - 1] == "-")
                {
                    result -= numbers[i];
                }
            }

            }
            return result;
        }


    }
}
