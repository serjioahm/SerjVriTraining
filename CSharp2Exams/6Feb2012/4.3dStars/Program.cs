using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace _4._3dStars
{
    public class Stars
    {
        static void Main(string[] args)
        {
            Stopwatch timeForPlus = new Stopwatch();
            Stopwatch timeForListAdd = new Stopwatch();
            Stopwatch timeForAppend = new Stopwatch();
            string s0 = "";
            string s1 = "asdd";
            string s2 = "asdd";
            string s3 = "asdd";
            string s4 = "asdd";
            string s5 = "asdd";
            string s6 = "asdd";

            timeForPlus.Start();
            for (int i = 0; i < 100000; i++)
            {
                s0 = s0 + s1;// + s3 + s4;
                //s1 = string.Concat(s1,s3,s4,s5);
                //s1 = s1 + s2;
                //s1 = s1 + s3;
                //s1 = s1 + s4;
                //s1 = s1 + s5;
                //s1 = s1 + s6;
            }
            timeForPlus.Stop();
            long wtime = timeForPlus.ElapsedMilliseconds;
            Console.WriteLine(wtime);


            timeForAppend.Start();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 100000; i++)
            {
                //sb.Append(s1).Append(s2).Append(s3).Append(s4);
                sb.Append(s1);
            
            }
            timeForAppend.Stop();
            long wtime3 = timeForAppend.ElapsedMilliseconds;
            Console.WriteLine(wtime3);

            //string[] sizes = Console.ReadLine().Split(' ');
            //int widthOfWord = int.Parse(sizes[0]);
            //int height = int.Parse(sizes[1]); // number of lines
            //int depth = int.Parse(sizes[2]); //number of words
            //List<string> allElements = new List<string>();

            //char[,,] cuboid = new char[widthOfWord, height, depth];

            //for (int i = 0; i < height; i++)
            //{
            //    string elements = Console.ReadLine().ToUpper();

            //    for (int j = 0, symbolOfLine = 0; j < depth; j++, symbolOfLine++/*between words*/)
            //        for (int k = 0; k < widthOfWord; k++)
            //        {
            //            cuboid[k, i, j] = elements[symbolOfLine];

            //            if (!allElements.Contains(elements[symbolOfLine].ToString()))
            //            {
            //                allElements.Add(elements[symbolOfLine].ToString());
            //            }

            //            symbolOfLine++;//current char's number of the line
            //        }
            //}
            //Stars p = new Stars();

            //List<string> results = p.FindStars(widthOfWord, height, depth, cuboid, allElements);
            //int starsCount = 0;

            //for (int i = 0; i < results.Count; i++)
            //{
            //    if (results[i].Length == 1)
            //    {
            //        results.Remove(results[i]);
            //        i--;
            //        continue;
            //    }
            //    else
            //    {
            //        starsCount = starsCount + (results[i].Length - 1);
            //    }
            //}

            //results.Sort();

            //Console.WriteLine(starsCount);
            //for (int i = 0; i < results.Count; i++)
            //{
            //    Console.WriteLine(results[i][0] + " " + (results[i].Length - 1));
            //}

            Console.ReadLine();
        }

        public List<string> FindStars(int widthOfWord, int height, int depth, char[,,] cuboid, List<string> allElements)
        {
            List<string> copyOfAllElements = new List<string>();
            //if (widthOfWord <= 2 || height <= 2 || depth <= 2)
            //{
            //    return copyOfAllElements;
            //}
            copyOfAllElements.AddRange(allElements);

            for (int i = 1; i < height - 1; i++)
            {
                for (int j = 1; j < depth - 1; j++)
                {
                    for (int k = 1; k < widthOfWord - 1; k++)
                    {
                        char star = cuboid[k, i, j];

                        if (cuboid[k - 1, i, j] == star && cuboid[k + 1, i, j] == star &&
                            cuboid[k, i - 1, j] == star && cuboid[k, i + 1, j] == star &&
                            cuboid[k, i, j - 1] == star && cuboid[k, i, j + 1] == star)
                        {
                            int indexOfCurrentCharInList = allElements.IndexOf(star.ToString());
                            copyOfAllElements[indexOfCurrentCharInList] = copyOfAllElements[indexOfCurrentCharInList] + ' ';
                        }
                    }
                }
            }

            return copyOfAllElements;
        }
    }
}
