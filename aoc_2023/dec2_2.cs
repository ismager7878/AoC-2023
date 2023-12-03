class dec2_2
{
    int answer = 0;
    List<string> input;
    public dec2_2(List<string> input)
    {
        this.input = input;
    }

    public int run()
    {
        foreach (string g in input)
        {
            if (g == "")
            {
                continue;
            }
            Game game = new Game(g);
            answer += game.red * game.blue * game.green;
        }
        return answer;
    }
}