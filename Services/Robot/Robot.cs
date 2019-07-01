using System;

public class Robot : IRobot
{
    int positionX;
    int positionY;
    int dirIndex;

    public int getPX(){
        return this.positionX;
    }

    public int getPY(){
        return this.positionY;
    }

    public int getDI(){
        return this.dirIndex;
    }

    public bool canMove(int[,] board)
    {
        int newPos;
        bool possible = true;
        switch (dirIndex)
        {
            case (int)DirEnum.NORTH:
                newPos = positionY + 1;
                if (newPos > board.GetLength(0) - 1)
                {
                    possible = false;
                }
                break;

            case (int)DirEnum.EAST:
                newPos = positionX + 1;
                if (newPos > board.GetLength(1) - 1)
                {
                    possible = false;
                }
                break;

            case (int)DirEnum.SOUTH:
                newPos = positionY - 1;
                if (newPos < 0)
                {
                    possible = false;
                }
                break;

            case (int)DirEnum.WEST:
                newPos = positionX - 1;
                if (newPos < 0)
                {
                    possible = false;
                }
                break;
        }
        return possible;

    }

    public bool canPlace(int[,] board, string[] word)
    {
        if (word[0] != "")
        {
            if (Int32.Parse(word[0]) > board.GetLength(0) - 1)
            {
                return false;
            }
            else
            if (Int32.Parse(word[1]) > board.GetLength(1) - 1)
            {
                return false;
            }
            else
            if (word[2] != "NORTH" && word[2] != "EAST" && word[2] != "SOUTH" && word[2] != "WEST")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        else
        {
            return false;
        }


    }
    public void place(string[] word)
    {
        positionX = Int32.Parse(word[0]);
        positionY = Int32.Parse(word[1]);
        string direction = word[2];

        switch (direction)
        {
            case "NORTH":
                dirIndex = (int)DirEnum.NORTH;
                break;
            case "EAST":
                dirIndex = (int)DirEnum.EAST;
                break;
            case "SOUTH":
                dirIndex = (int)DirEnum.SOUTH;
                break;
            case "WEST":
                dirIndex = (int)DirEnum.WEST;
                break;
        }
    }
    public void report()
    {
        Console.WriteLine("Output: " + positionX + "," + positionY + "," + Enum.GetName(typeof(DirEnum), dirIndex));
    }
    public void move()
    {
        switch (dirIndex)
        {
            case (int)DirEnum.NORTH:
                positionY++;
                break;

            case (int)DirEnum.EAST:
                positionX++;
                break;

            case (int)DirEnum.SOUTH:
                positionY--;
                break;

            case (int)DirEnum.WEST:
                positionX--;
                break;
            default:
                Console.WriteLine("Please place a robot first");
                break;
        }
    }
    public void turn(string dir)
    {
        if (dir == "LEFT")
        {
            dirIndex--;
        }
        else if (dir == "RIGHT")
        {
            dirIndex++;
        }

        if (dirIndex < 0)
        {
            dirIndex = dirIndex + 4;
        }
        if (dirIndex > 3)
        {
            dirIndex = dirIndex - 4;
        }
    }

}