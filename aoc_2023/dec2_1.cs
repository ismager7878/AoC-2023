
using System.Collections.ObjectModel;

class Game
{
    public int id;
    public int red = 0;
    public int blue = 0;
    public int green = 0;

    public Game(string game)
    {
        string[] idNgame = game.Split(": ");
        id = Convert.ToInt32(idNgame[0].Split(" ")[1]);
        string[] results = idNgame[1].Replace(";", ",").Split(", ");
        foreach (string result in results)
        {
            int num = Convert.ToInt32(result.Split(" ")[0]);
            red = result.Contains("red") && num > red ? num : red;
            blue = result.Contains("blue") && num > blue ? num : blue;
            green = result.Contains("green") && num > green ? num : green;
        }

    }
}
class dec2_1
{
    int maxBlue = 14;
    int maxRed = 12;

    int maxGreen = 13;
    List<string> input;
    public dec2_1(List<string> input)
    {
        this.input = input;
    }

    public int run()
    {
        int answer = 0;
        foreach (string g in input)
        {
            if (g == "")
            {
                continue;
            }
            Game game = new Game(g);
            if (game.red > maxRed)
            {
                continue;
            }
            if (game.blue > maxBlue)
            {
                continue;
            }
            if (game.green > maxGreen)
            {
                continue;
            }
            answer += game.id;
        }
        return answer;
    }

}