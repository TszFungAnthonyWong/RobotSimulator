using System.Text.RegularExpressions;
public class Reader:IReader
{
    public string readCommand(string text)
    {
        Regex pertten = new Regex(@"[A-za-z]+");
        Match match = pertten.Match(text);
        string word = match.ToString();
        return word;
    }

    public string[] getPos(string text)
    {
        string[] word = new string[3];
        Regex pertten = new Regex(@" (\d+),(\d+),([A-Z]+)");
        Match match = pertten.Match(text);
        word[0] = match.Groups[1].ToString();
        word[1] = match.Groups[2].ToString();
        word[2] = match.Groups[3].ToString();
        return word;
    }
}