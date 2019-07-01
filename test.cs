using Xunit;

public class test
{
    [Fact]
    public void READCOMMAND_TEST()
    {
        Reader reader = new Reader();
        string input = "PLACE 0,0,NORTH";
        string expected = "PLACE";
        string actual = reader.readCommand(input);
        Assert.Equal(expected,actual);
    }

    [Fact]
    public void GETPOS_TEST()
    {
        Reader reader = new Reader();
        string input = "PLACE 0,0,NORTH";
        string[] expected = {"0","0","NORTH"};
        string[] actual = reader.getPos(input);
        Assert.Equal(expected,actual);
    }


    [Fact]
    public void Test_A()
    {
        Robot rob = new Robot();

        string[] input = {"0","0","NORTH"};
        rob.place(input);
        rob.move();
        int expectedX = 0;
        int expectedY = 1;
        int expectedDir = (int)DirEnum.NORTH;

        int actualX =rob.getPX();
        int actualY =rob.getPY();
        int actualDir =rob.getDI();
        Assert.Equal(expectedX,actualX);
        Assert.Equal(expectedY,actualY);
        Assert.Equal(expectedDir,actualDir);
    }

    [Fact]
    public void Test_B()
    {
        Robot rob = new Robot();

        string[] input = {"0","0","NORTH"};
        rob.place(input);
        rob.turn("LEFT");
        int expectedX = 0;
        int expectedY = 0;
        int expectedDir = (int)DirEnum.WEST;

        int actualX =rob.getPX();
        int actualY =rob.getPY();
        int actualDir =rob.getDI();
        Assert.Equal(expectedX,actualX);
        Assert.Equal(expectedY,actualY);
        Assert.Equal(expectedDir,actualDir);
    }

    [Fact]
    public void Test_C()
    {
        Robot rob = new Robot();

        string[] input = {"1","2","EAST"};
        rob.place(input);
        rob.move();
        rob.move();
        rob.turn("LEFT");
        rob.move();
        int expectedX = 3;
        int expectedY = 3;
        int expectedDir = (int)DirEnum.NORTH;

        int actualX =rob.getPX();
        int actualY =rob.getPY();
        int actualDir =rob.getDI();
        Assert.Equal(expectedX,actualX);
        Assert.Equal(expectedY,actualY);
        Assert.Equal(expectedDir,actualDir);
    }
}