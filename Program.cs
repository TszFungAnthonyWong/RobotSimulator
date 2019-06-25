using System;

namespace RobotPuzzle
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] gameBoard = new int[5, 5];
            bool inGame = true;
            bool isRobot = false;
            string errMsg = "";
            IReader reader = new Reader();
            IRobot rob = new Robot();

            Console.WriteLine("Welcom to the Toy Robot Similator");
            Console.WriteLine("Please Enter your command:");

            while (inGame == true)
            {
                Console.Write("> ");
                string text = Console.ReadLine();
                switch (reader.readCommand(text))
                {
                    case "PLACE":
                        string[] position = reader.getPos(text);
                        if (rob.canPlace(gameBoard, position))
                        {
                            rob.place(reader.getPos(text));
                            isRobot = true;
                        } else{
                            errMsg = "Please enter a correct position";
                        }
                        break;

                    case "MOVE":
                        if (isRobot)
                        {
                            if (rob.canMove(gameBoard))
                            {
                                rob.move();
                            }
                            else
                            {
                                errMsg = "Move not avaible";
                            }
                        }
                        else
                        {
                            errMsg = "Please place a robot first";
                        }
                        break;

                    case "LEFT":
                        if (isRobot)
                        {
                            rob.turn("LEFT");
                        }
                        else
                        {
                            errMsg = "Please place a robot first";
                        }
                        break;

                    case "RIGHT":
                        if (isRobot)
                        {
                            rob.turn("RIGHT");
                        }
                        else
                        {
                            errMsg = "Please place a robot first";
                        }
                        break;

                    case "REPORT":
                        if (isRobot)
                        {
                            rob.report();
                        }
                        else
                        {
                            errMsg = "Please place a robot first";
                        }
                        break;

                    case "EXIT":
                        inGame = false;
                        break;
                        
                    default:
                        errMsg = "Invalid input";
                        break;
                }

                if (errMsg != "")
                {
                    Console.WriteLine(errMsg);
                    errMsg = "";
                }
            }
        }
    }
}