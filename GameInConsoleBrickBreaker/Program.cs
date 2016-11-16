using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace GameInConsole
{
    class Program
    {
        static int ballPositionX = 0;
        static int ballPositionY = 0;
        static int ballTwoPositionX = 0;
        static int ballTwoPositionY = 0;
        static int ballThreePositionX = 0;
        static int ballThreePositionY = 0;
        static int PlayerPositionX = 0;
        static int PlayerPositionY = 25;
        static int PlayerTwoPositionX = 0;
        static int PlayerTwoPositionY = 3;
        static int StopperSize = 10;
        static int numberOfFails = 0;
        static List<string> brickHealth = new List<string>();//hopefully 150


        static int brickWallWidth = 30;
        static int brickWallHeight = 15;

        static int brickWallVertWidth = 1;
        static int brickWallVertHeight = 3;

        static int wallStartXPosition = 20;//(Console.WindowWidth / 2) - (brickWallWidth / 2);
        static int wallStartYPosition = 5;//(Console.WindowHeight / 2) - (brickWallHeight / 2);
        static int wallVertStartXPosition = 25;
        static int wallVertStartYPosition = 3;
        static int brickVertXPosition = wallVertStartXPosition;
        static int brickVertYPosition = wallVertStartYPosition;
        static string brickVert = "[*]";
        static int brickVertLastYPosition = brickVertYPosition + brickVert.Length;
        //static char[,] brickWall = new char[200, 200];
        static char[,] brickWallVert = new char[brickWallVertWidth, brickWallVertHeight];
        static char[,] brickWall = new char[brickWallWidth, brickWallHeight];
        static string brick = "{&}";

        static bool vertBrickDirectionUp = true;
        static bool ballDirectionUp = true;
        static bool ballDirectionRight = true;
        static bool ballTwoDirectionUp = false;
        static bool ballTwoDirectionRight = false;
        static bool ballThreeDirectionUp = true;
        static bool ballThreeDirectionRight = false;

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            // Console.ForegroundColor = ConsoleColor.;
            Console.BufferHeight = Console.WindowHeight;
            Console.BufferWidth = Console.WindowWidth;
            Console.SetWindowSize(70, 30);

            Console.CursorVisible = false;

            SetStarterPositions();




            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo pressedButton = Console.ReadKey();

                    //mesti  igra4
                    if (pressedButton.Key == ConsoleKey.LeftArrow)
                    {
                        if (PlayerPositionX > 0)
                        {
                            PlayerPositionX = PlayerPositionX - 5;
                            //MovePlayerLeft();
                        }
                    }
                    if (pressedButton.Key == ConsoleKey.RightArrow)
                    {
                        if (PlayerPositionX + StopperSize < Console.WindowWidth)
                        {
                            PlayerPositionX = PlayerPositionX + 5;
                        }
                        // MovePlayerRight();
                    }
                }

                MoveBall();
                // MoveSecondBall();
                //MoveThirdBall();
                //mesti topka v pravilna posoka

                Console.Clear();//iz4isti 4e da moje6 da na4ertae6 new positions

                DrawBall();
                DrawPlayer();
                DrawSecondPlayer();
                MoveVertBrick();
                //if (ballPositionX > wallStartXPosition - 1 && ballPositionX <= brickWallWidth + 1 && ballPositionY > wallStartYPosition - 1 && ballPositionY <= brickWallHeight + 1)
                //{
                //    Thread.Sleep(500);
                //}
                DrawBrickWall();

                ShowScore();
                Thread.Sleep(60);
            }
        }

        private static void MoveVertBrick()
        {
            if (brickVertYPosition == 0)
            {
                vertBrickDirectionUp = false;
            }
            if (brickVertYPosition == Console.WindowHeight - 3)
            {
                vertBrickDirectionUp = true;
            }


            if (brickVertYPosition == PlayerPositionY - 1)
            {
                if (brickVertXPosition >= PlayerPositionX && brickVertXPosition < PlayerPositionX + StopperSize)
                {
                    vertBrickDirectionUp = true;
                }
                else if (ballDirectionUp == false)
                {
                    //numberOfFails++;
                }
            }
            if (brickVertYPosition == PlayerPositionY + 1)
            {
                if (brickVertXPosition >= PlayerPositionX && brickVertXPosition < PlayerPositionX + StopperSize)
                {
                    vertBrickDirectionUp = false;
                }

            }

            if (brickVertXPosition >= wallStartXPosition && brickVertXPosition <= wallStartXPosition + brickWallWidth)
            {
                for (int i = 0; i < brickWallWidth; i++)
                {
                    for (int j = 0; j < brickWallHeight; j++)
                    {
                        if (wallStartXPosition + i == brickVertXPosition && brickVertYPosition == wallStartYPosition + j)
                        {
                            if (brickWall[i, j] != ' ')
                            {
                                if (vertBrickDirectionUp)
                                {
                                    vertBrickDirectionUp = false;
                                }
                                else
                                {
                                    vertBrickDirectionUp = true;
                                }
                            }
                        }
                    }
                }
            }



            if (vertBrickDirectionUp)
            {
                brickVertYPosition--;
            }
            else
            {
                brickVertYPosition++;
            }

        }

        private static void ShowScore()
        {
            Console.SetCursorPosition((Console.WindowWidth / 2 - StopperSize / 2), PlayerPositionY + 2);
            Console.Write("Number Of Fails : " + numberOfFails);
        }

        private static void DrawBrickWall()
        {
            for (int i = 0; i < brickWallWidth; i++)
            {
                for (int j = 0; j < brickWallHeight; j++)
                {
                    // PrintStringAtCordinates(i, j, brickWall[i, j]);
                    PrintSymbolAtCordinates(wallStartXPosition + i, wallStartYPosition + j, brickWall[i, j]);
                }
            }



            for (int j = 0; j < brickWallVertHeight; j++)
            {
                // PrintStringAtCordinates(i, j, brickWall[i, j]);
                PrintSymbolAtCordinates(brickVertXPosition, brickVertYPosition + j, brickWallVert[0, j]);
            }

        }


        static void SetStarterPositions()
        {
            PlayerTwoPositionX = Console.WindowWidth / 2 - StopperSize / 2; ;
            PlayerPositionX = Console.WindowWidth / 2 - StopperSize / 2;

            ballPositionX = Console.WindowWidth / 2;
            ballPositionY = PlayerPositionY - 1;
            //ballPositionX = 20;
            //ballPositionY = 19;
            //ballTwoPositionX = (Console.WindowWidth / 2) - 1;
            //ballTwoPositionY = PlayerPositionY - 1;
            //ballThreePositionX = (Console.WindowWidth / 2) - 2;
            //ballThreePositionY = PlayerPositionY - 1;


            int n = 0;
            for (int i = 0; i < brickWallWidth; i++)
            {
                for (int j = 0; j < brickWallHeight; j++)
                {

                    if (n == 0)
                    {
                        brickWall[i, j] = brick[n];
                    }
                    if (n == 1)
                    {
                        brickWall[i, j] = brick[n];
                    }
                    if (n == 2)
                    {
                        brickWall[i, j] = brick[n];
                        //n = 0;
                    }

                }
                if (n < 2)
                {
                    n++;
                }
                else
                {
                    n = 0;
                }

            }
            n = 0;
            for (int i = 0; i < brickWallVertWidth; i++)
            {
                for (int j = 0; j < brickWallVertHeight; j++)
                {

                    if (n == 0)
                    {
                        brickWallVert[i, j] = brickVert[n];
                    }
                    if (n == 1)
                    {
                        brickWallVert[i, j] = brickVert[n];
                    }
                    if (n == 2)
                    {
                        brickWallVert[i, j] = brickVert[n];
                        //n = 0;
                    }

                    if (n < 2)
                    {
                        n++;
                    }
                    else
                    {
                        n = 0;
                    }
                }

            }
        }

        private static void MoveBall()
        {


            if (ballPositionY == 0)
            {
                ballDirectionUp = false;
            }
            if (ballPositionY == Console.WindowHeight - 1)
            {
                ballDirectionUp = true;
            }
            if (ballPositionX == Console.WindowWidth - 1)
            {
                ballDirectionRight = false;
            }
            if (ballPositionX == 0)
            {
                ballDirectionRight = true;
            }

            if (ballPositionX == brickVertXPosition)
            {
                if (ballPositionY >= brickVertYPosition && ballPositionY <= brickVertYPosition + brickVert.Length)
                {
                    if (ballDirectionRight)
                    {
                        ballDirectionRight = false;
                    }
                    else
                    {
                        ballDirectionRight = true;
                    }

                }
            }


            if (ballPositionY == PlayerPositionY - 1)
            {
                if (ballPositionX >= PlayerPositionX && ballPositionX < PlayerPositionX + StopperSize)
                {
                    ballDirectionUp = true;
                }
                else if (ballDirectionUp == false)
                {
                    numberOfFails++;
                }
            }
            if (ballPositionY == PlayerPositionY + 1)
            {
                if (ballPositionX >= PlayerPositionX && ballPositionX < PlayerPositionX + StopperSize)
                {
                    ballDirectionUp = false;
                }

            }
            //..
            if (ballPositionY == PlayerTwoPositionY - 1)
            {
                if (ballPositionX >= PlayerTwoPositionX && ballPositionX < PlayerTwoPositionX + StopperSize)
                {
                    ballDirectionUp = true;
                }
                else if (ballDirectionUp == false)
                {
                    // numberOfFails++;
                }
            }
            if (ballPositionY == PlayerTwoPositionY + 1)
            {
                if (ballPositionX >= PlayerTwoPositionX && ballPositionX < PlayerTwoPositionX + StopperSize)
                {
                    ballDirectionUp = false;
                }

            }


            for (int i = 0; i < brickWallWidth; i++)
            {
                for (int j = 0; j < brickWallHeight; j++)
                {
                    if (wallStartXPosition + i == ballPositionX && ballPositionY == wallStartYPosition + j)
                    {
                        string currentWord = "";
                        string brickPartOne = "";
                        string brickPartTwo = "";
                        string brickPartThree = "";
                        //bool wasFirstLetter = false;

                        if (brickWall[i, j] == brick[0] || brickWall[i, j] == '[')
                        {

                            brickPartOne = "" + i + j;
                            brickPartTwo = "" + (i + 1) + j;
                            brickPartThree = "" + (i + 2) + j;



                        }
                        if (brickWall[i, j] == brick[1] || brickWall[i, j] == '+')
                        {
                            brickPartOne = "" + (i - 1) + j;
                            brickPartTwo = "" + i + j;
                            brickPartThree = "" + (i + 1) + j;
                            //currentWord = "" + brickPartOne + brickPartTwo + brickPartThree;
                        }
                        if (brickWall[i, j] == brick[2] || brickWall[i, j] == ']')
                        {
                            brickPartOne = "" + (i - 2) + j;
                            brickPartTwo = "" + (i - 1) + j;
                            brickPartThree = "" + i + j;
                            //currentWord = "" + brickPartOne + brickPartTwo + brickPartThree;
                        }

                        currentWord = "" + brickPartOne + brickPartTwo + brickPartThree;
                        brickHealth.Add(currentWord);
                        // brickHealth.Add(currentWord);
                        int countOfAppearence = 0;

                        foreach (string brickCords in brickHealth)
                        {
                            if (brickCords == currentWord)
                            {
                                countOfAppearence++;
                            }
                        }

                        int caseNumber = 0;
                        //wasFirstLetter = false;
                        //if (brickWall[i, j] == '|')
                        //{
                        //    if (brickWall[i + 1, j] == '+')
                        //    {
                        //        wasFirstLetter = true;
                        //    }
                        //    else
                        //    {
                        //        wasFirstLetter = false;
                        //    }
                        //}

                        if (brickWall[i, j] == brick[0] || brickWall[i, j] == '[')
                        {


                            if (ballPositionY == (brickWallHeight + wallStartYPosition) - 1)
                            {
                                if (countOfAppearence == 1)
                                {
                                    brickWall[i, j] = '[';
                                    brickWall[i + 1, j] = '+';
                                    brickWall[i + 2, j] = ']';
                                    caseNumber = 1;

                                }
                                if (countOfAppearence == 2)
                                {
                                    brickWall[i, j] = ' ';
                                    brickWall[i + 1, j] = ' ';
                                    brickWall[i + 2, j] = ' ';
                                }
                            }
                            else
                            {
                                brickWall[i, j] = ' ';
                                brickWall[i + 1, j] = ' ';
                                brickWall[i + 2, j] = ' ';
                                caseNumber = 1;
                            }


                        }
                        if (brickWall[i, j] == brick[1] || brickWall[i, j] == '+')
                        {
                            if (ballPositionY == (brickWallHeight + wallStartYPosition) - 1)
                            {
                                if (countOfAppearence == 1)
                                {
                                    brickWall[i, j] = '+';
                                    brickWall[i + 1, j] = ']';
                                    brickWall[i - 1, j] = '[';
                                    caseNumber = 1;
                                }
                                if (countOfAppearence == 2)
                                {
                                    brickWall[i, j] = ' ';
                                    brickWall[i + 1, j] = ' ';
                                    brickWall[i - 1, j] = ' ';
                                }
                            }
                            else
                            {
                                brickWall[i, j] = ' ';
                                brickWall[i + 1, j] = ' ';
                                brickWall[i - 1, j] = ' ';
                                caseNumber = 1;
                            }
                        }
                        if (brickWall[i, j] == brick[2] || brickWall[i, j] == ']')
                        {

                            if (ballPositionY == (brickWallHeight + wallStartYPosition) - 1)
                            {

                                if (countOfAppearence == 1)
                                {
                                    brickWall[i, j] = ']';
                                    brickWall[i - 1, j] = '+';
                                    brickWall[i - 2, j] = '[';
                                    caseNumber = 1;
                                }
                                if (countOfAppearence == 2)
                                {
                                    brickWall[i, j] = ' ';
                                    brickWall[i - 1, j] = ' ';
                                    brickWall[i - 2, j] = ' ';
                                }
                            }
                            else
                            {
                                brickWall[i, j] = ' ';
                                brickWall[i - 1, j] = ' ';
                                brickWall[i - 2, j] = ' ';
                                caseNumber = 1;
                            }
                        }

                        if (caseNumber == 1)
                        {

                            if (ballDirectionUp && ballDirectionRight)
                            {

                                // ballDirectionRight = false;
                                caseNumber = 2;

                            }
                            if (!ballDirectionUp && ballDirectionRight)
                            {

                                // ballDirectionRight = false;
                                caseNumber = 4;
                            }
                            if (ballDirectionUp && !ballDirectionRight)
                            {
                                // ballDirectionRight = true;
                                caseNumber = 6;
                            }
                            if (!ballDirectionUp && !ballDirectionRight)
                            {
                                // ballDirectionRight = true;
                                caseNumber = 8;
                            }
                            switch (caseNumber)
                            {

                                case 2:
                                    ballDirectionUp = false;

                                    break;
                                case 4:
                                    ballDirectionUp = true;

                                    break;
                                case 6:
                                    ballDirectionUp = false;

                                    break;
                                case 8:
                                    ballDirectionUp = true;

                                    break;
                                default:
                                    break;
                            }
                        }

                    }
                }
            }
            //mesti  igra42
            if (!ballDirectionRight && ballPositionY == 5 && PlayerTwoPositionX > ballPositionX)
            {
                if (PlayerTwoPositionX > 0)
                {
                    PlayerTwoPositionX = PlayerTwoPositionX - 5;
                    //MovePlayerLeft();
                }
            }
            else if (!ballDirectionRight && ballPositionY == 5)
            {
                if (PlayerTwoPositionX + StopperSize < Console.WindowWidth)
                {
                    PlayerTwoPositionX = PlayerTwoPositionX + 5;
                }
                // MovePlayerRight();
            }

            if (ballDirectionRight && ballPositionY == 5 && PlayerTwoPositionX < ballPositionX)
            {
                if (PlayerTwoPositionX + StopperSize < Console.WindowWidth)
                {
                    PlayerTwoPositionX = PlayerTwoPositionX + 5;
                }
                // MovePlayerRight();
            }
            else if (ballDirectionRight && ballPositionY == 5)
            {
                if (PlayerTwoPositionX > 0)
                {
                    PlayerTwoPositionX = PlayerTwoPositionX - 5;
                    //MovePlayerLeft();
                }
            }



            if (ballDirectionUp)
            {
                ballPositionY--;
            }
            else
            {
                ballPositionY++;
            }
            if (ballDirectionRight)
            {
                ballPositionX++;
            }
            else
            {
                ballPositionX--;
            }
        }

        //private static void MoveSecondBall()
        //{


        //    if (ballTwoPositionY == 0)
        //    {
        //        ballTwoDirectionUp = false;
        //    }
        //    if (ballTwoPositionY == Console.WindowHeight - 1)
        //    {
        //        ballTwoDirectionUp = true;
        //    }
        //    if (ballTwoPositionX == Console.WindowWidth - 1)
        //    {
        //        ballTwoDirectionRight = false;
        //    }
        //    if (ballTwoPositionX == 0)
        //    {
        //        ballTwoDirectionRight = true;
        //    }

        //    if (ballTwoPositionY == PlayerPositionY - 1)
        //    {
        //        if (ballTwoPositionX >= PlayerPositionX && ballTwoPositionX < PlayerPositionX + StopperSize)
        //        {
        //            ballTwoDirectionUp = true;
        //        }
        //        else if (ballTwoDirectionUp == false)
        //        {
        //            numberOfFails++;
        //        }
        //    }
        //    if (ballTwoPositionY == PlayerPositionY + 1)
        //    {
        //        if (ballTwoPositionX >= PlayerPositionX && ballTwoPositionX < PlayerPositionX + StopperSize)
        //        {
        //            ballTwoDirectionUp = false;
        //        }

        //    }

        //    if (ballTwoPositionY == PlayerTwoPositionY - 1)
        //    {
        //        if (ballTwoPositionX >= PlayerTwoPositionX && ballTwoPositionX < PlayerTwoPositionX + StopperSize)
        //        {
        //            ballTwoDirectionUp = true;
        //        }
        //        else if (ballTwoDirectionUp == false)
        //        {
        //            // numberOfFails++;
        //        }
        //    }
        //    if (ballTwoPositionY == PlayerTwoPositionY + 1)
        //    {
        //        if (ballTwoPositionX >= PlayerTwoPositionX && ballTwoPositionX < PlayerTwoPositionX + StopperSize)
        //        {
        //            ballTwoDirectionUp = false;
        //        }

        //    }

        //    for (int i = 0; i < brickWallWidth; i++)
        //    {
        //        for (int j = 0; j < brickWallHeight; j++)
        //        {
        //            if (wallStartXPosition + i == ballTwoPositionX && ballTwoPositionY == wallStartYPosition + j)
        //            {
        //                int caseNumber = 0;
        //                if (brickWall[i, j] == brick[0])
        //                {
        //                    brickWall[i, j] = ' ';
        //                    brickWall[i + 1, j] = ' ';
        //                    brickWall[i + 2, j] = ' ';
        //                    caseNumber = 1;
        //                }
        //                if (brickWall[i, j] == brick[1])
        //                {
        //                    brickWall[i, j] = ' ';
        //                    brickWall[i + 1, j] = ' ';
        //                    brickWall[i - 1, j] = ' ';
        //                    caseNumber = 1;
        //                }
        //                if (brickWall[i, j] == brick[2])
        //                {
        //                    brickWall[i, j] = ' ';
        //                    brickWall[i - 1, j] = ' ';
        //                    brickWall[i - 2, j] = ' ';
        //                    caseNumber = 1;
        //                }

        //                if (caseNumber == 1)
        //                {

        //                    if (ballTwoDirectionUp && ballTwoDirectionRight)
        //                    {

        //                        // ballDirectionRight = false;
        //                        caseNumber = 2;
        //                    }
        //                    if (!ballTwoDirectionUp && ballTwoDirectionRight)
        //                    {

        //                        // ballDirectionRight = false;
        //                        caseNumber = 4;
        //                    }
        //                    if (ballTwoDirectionUp && !ballTwoDirectionRight)
        //                    {
        //                        // ballDirectionRight = true;
        //                        caseNumber = 6;
        //                    }
        //                    if (!ballTwoDirectionUp && !ballTwoDirectionRight)
        //                    {
        //                        // ballDirectionRight = true;
        //                        caseNumber = 8;
        //                    }
        //                    switch (caseNumber)
        //                    {

        //                        case 2:
        //                            ballTwoDirectionUp = false;
        //                            break;
        //                        case 4:
        //                            ballTwoDirectionUp = true;
        //                            break;
        //                        case 6:
        //                            ballTwoDirectionUp = false;
        //                            break;
        //                        case 8:
        //                            ballTwoDirectionUp = true;
        //                            break;
        //                        default:
        //                            break;
        //                    }
        //                }

        //            }
        //        }
        //    }
        //    //mesti  igra42
        //    if (!ballTwoDirectionRight && ballTwoPositionY == 5 && PlayerTwoPositionX > ballTwoPositionX)
        //    {
        //        if (PlayerTwoPositionX > 0)
        //        {
        //            PlayerTwoPositionX = PlayerTwoPositionX - 5;
        //            //MovePlayerLeft();
        //        }
        //    }
        //    else if (!ballTwoDirectionRight && ballTwoPositionY == 5)
        //    {
        //        if (PlayerTwoPositionX + StopperSize < Console.WindowWidth)
        //        {
        //            PlayerTwoPositionX = PlayerTwoPositionX + 5;
        //        }
        //        // MovePlayerRight();
        //    }

        //    if (ballTwoDirectionRight && ballTwoPositionY == 5 && PlayerTwoPositionX < ballTwoPositionX)
        //    {
        //        if (PlayerTwoPositionX + StopperSize < Console.WindowWidth)
        //        {
        //            PlayerTwoPositionX = PlayerTwoPositionX + 5;
        //        }
        //        // MovePlayerRight();
        //    }
        //    else if (ballTwoDirectionRight && ballTwoPositionY == 5)
        //    {
        //        if (PlayerTwoPositionX > 0)
        //        {
        //            PlayerTwoPositionX = PlayerTwoPositionX - 5;
        //            //MovePlayerLeft();
        //        }
        //    }



        //    if (ballTwoDirectionUp)
        //    {
        //        ballTwoPositionY--;
        //    }
        //    else
        //    {
        //        ballTwoPositionY++;
        //    }
        //    if (ballTwoDirectionRight)
        //    {
        //        ballTwoPositionX++;
        //    }
        //    else
        //    {
        //        ballTwoPositionX--;
        //    }
        //}

        //private static void MoveThirdBall()
        //{


        //    if (ballThreePositionY == 0)
        //    {
        //        ballThreeDirectionUp = false;
        //    }
        //    if (ballThreePositionY == Console.WindowHeight - 1)
        //    {
        //        ballThreeDirectionUp = true;
        //    }
        //    if (ballThreePositionX == Console.WindowWidth - 1)
        //    {
        //        ballThreeDirectionRight = false;
        //    }
        //    if (ballThreePositionX == 0)
        //    {
        //        ballThreeDirectionRight = true;
        //    }

        //    if (ballThreePositionY == PlayerPositionY - 1)
        //    {
        //        if (ballThreePositionX >= PlayerPositionX && ballThreePositionX < PlayerPositionX + StopperSize)
        //        {
        //            ballThreeDirectionUp = true;
        //        }
        //        else if (ballThreeDirectionUp == false)
        //        {
        //            numberOfFails++;
        //        }
        //    }
        //    if (ballThreePositionY == PlayerPositionY + 1)
        //    {
        //        if (ballThreePositionX >= PlayerPositionX && ballThreePositionX < PlayerPositionX + StopperSize)
        //        {
        //            ballThreeDirectionUp = false;
        //        }

        //    }
        //    //..
        //    if (ballThreePositionY == PlayerTwoPositionY - 1)
        //    {
        //        if (ballThreePositionX >= PlayerTwoPositionX && ballThreePositionX < PlayerTwoPositionX + StopperSize)
        //        {
        //            ballThreeDirectionUp = true;
        //        }
        //        else if (ballThreeDirectionUp == false)
        //        {
        //            // numberOfFails++;
        //        }
        //    }
        //    if (ballThreePositionY == PlayerTwoPositionY + 1)
        //    {
        //        if (ballThreePositionX >= PlayerTwoPositionX && ballThreePositionX < PlayerTwoPositionX + StopperSize)
        //        {
        //            ballThreeDirectionUp = false;
        //        }

        //    }


        //    for (int i = 0; i < brickWallWidth; i++)
        //    {
        //        for (int j = 0; j < brickWallHeight; j++)
        //        {
        //            if (wallStartXPosition + i == ballThreePositionX && ballThreePositionY == wallStartYPosition + j)
        //            {
        //                int caseNumber = 0;
        //                if (brickWall[i, j] == brick[0])
        //                {
        //                    brickWall[i, j] = ' ';
        //                    brickWall[i + 1, j] = ' ';
        //                    brickWall[i + 2, j] = ' ';
        //                    caseNumber = 1;
        //                }
        //                if (brickWall[i, j] == brick[1])
        //                {
        //                    brickWall[i, j] = ' ';
        //                    brickWall[i + 1, j] = ' ';
        //                    brickWall[i - 1, j] = ' ';
        //                    caseNumber = 1;
        //                }
        //                if (brickWall[i, j] == brick[2])
        //                {
        //                    brickWall[i, j] = ' ';
        //                    brickWall[i - 1, j] = ' ';
        //                    brickWall[i - 2, j] = ' ';
        //                    caseNumber = 1;
        //                }

        //                if (caseNumber == 1)
        //                {

        //                    if (ballThreeDirectionUp && ballThreeDirectionRight)
        //                    {

        //                        // ballDirectionRight = false;
        //                        caseNumber = 2;
        //                    }
        //                    if (!ballThreeDirectionUp && ballThreeDirectionRight)
        //                    {

        //                        // ballDirectionRight = false;
        //                        caseNumber = 4;
        //                    }
        //                    if (ballThreeDirectionUp && !ballThreeDirectionRight)
        //                    {
        //                        // ballDirectionRight = true;
        //                        caseNumber = 6;
        //                    }
        //                    if (!ballThreeDirectionUp && !ballThreeDirectionRight)
        //                    {
        //                        // ballDirectionRight = true;
        //                        caseNumber = 8;
        //                    }
        //                    switch (caseNumber)
        //                    {

        //                        case 2:
        //                            ballThreeDirectionUp = false;
        //                            break;
        //                        case 4:
        //                            ballThreeDirectionUp = true;
        //                            break;
        //                        case 6:
        //                            ballThreeDirectionUp = false;
        //                            break;
        //                        case 8:
        //                            ballThreeDirectionUp = true;
        //                            break;
        //                        default:
        //                            break;
        //                    }
        //                }

        //            }
        //        }
        //    }
        //    //mesti  igra42
        //    if (!ballThreeDirectionRight && ballThreePositionY == 5 && PlayerTwoPositionX > ballThreePositionX)
        //    {
        //        if (PlayerTwoPositionX > 0)
        //        {
        //            PlayerTwoPositionX = PlayerTwoPositionX - 5;
        //            //MovePlayerLeft();
        //        }
        //    }
        //    else if (!ballThreeDirectionRight && ballThreePositionY == 5)
        //    {
        //        if (PlayerTwoPositionX + StopperSize < Console.WindowWidth)
        //        {
        //            PlayerTwoPositionX = PlayerTwoPositionX + 5;
        //        }
        //        // MovePlayerRight();
        //    }

        //    if (ballThreeDirectionRight && ballThreePositionY == 5 && PlayerTwoPositionX < ballThreePositionX)
        //    {
        //        if (PlayerTwoPositionX + StopperSize < Console.WindowWidth)
        //        {
        //            PlayerTwoPositionX = PlayerTwoPositionX + 5;
        //        }
        //        // MovePlayerRight();
        //    }
        //    else if (ballThreeDirectionRight && ballThreePositionY == 5)
        //    {
        //        if (PlayerTwoPositionX > 0)
        //        {
        //            PlayerTwoPositionX = PlayerTwoPositionX - 5;
        //            //MovePlayerLeft();
        //        }
        //    }



        //    if (ballThreeDirectionUp)
        //    {
        //        ballThreePositionY--;
        //    }
        //    else
        //    {
        //        ballThreePositionY++;
        //    }
        //    if (ballThreeDirectionRight)
        //    {
        //        ballThreePositionX++;
        //    }
        //    else
        //    {
        //        ballThreePositionX--;
        //    }
        //}

        private static void DrawBall()
        {
            PrintSymbolAtCordinates(ballPositionX, ballPositionY, '\u25CF');
            //PrintSymbolAtCordinates(ballTwoPositionX, ballTwoPositionY, '*');
            //PrintSymbolAtCordinates(ballThreePositionX, ballThreePositionY, 'O');
        }



        static void DrawPlayer()
        {
            for (int i = PlayerPositionX; i < PlayerPositionX + StopperSize; i++)
            {
                //printirai to4ka v poziciq x,y
                PrintSymbolAtCordinates(i, PlayerPositionY, '=');
            }
        }
        static void DrawSecondPlayer()
        {
            for (int i = PlayerTwoPositionX; i < PlayerTwoPositionX + StopperSize; i++)
            {
                //printirai to4ka v poziciq x,y
                PrintSymbolAtCordinates(i, PlayerTwoPositionY, '=');
            }
        }
        static void PrintSymbolAtCordinates(int x, int y, char symbol)
        {

            Console.SetCursorPosition(x, y);
            Console.Write(symbol);

        }
        static void PrintStringAtCordinates(int x, int y, string symbol)
        {

            Console.SetCursorPosition(x, y);
            Console.Write(symbol);

        }
        //public void SomeConsoleCommands()
        //{
        //    Console.SetCursorPosition(5, 5);
        //    Console.Write("SOMETHING");

        //    Console.OutputEncoding = System.Text.Encoding.Unicode;
        //    Console.CursorVisible = false;

        //    Console.SetWindowSize(100, 50);

        //    Thread.Sleep(1000);
        //}
    }
}
