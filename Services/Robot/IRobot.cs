
interface IRobot{
bool canMove(int[,] board);
bool canPlace(int[,] board, string[] word);
void place(string[] word);
void report();
void move();
void turn(string dir);
}