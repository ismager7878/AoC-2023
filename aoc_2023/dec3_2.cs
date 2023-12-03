using System.Numerics;

class Gear{
    public string id;
    int x;
    int y;
    bool isConnected;
    List<int> parts = [];
    public Gear(int x, int y){
        id = $"{y},{x}";

        this.x = x;
        this.y = y;
    }
}
class dec3_2
{
    int answer = 0;
    List<string> input;
    public dec3_2(List<string> input)
    {
        this.input = input;
    }

    List<Gear> gears = new List<Gear>();

    public int run()
    {
        for(int y  = 0; y < input.Count; y++){
            for(int x = 0; x < input[y].Length; x++){
                if(input[y][x] == '*'){
                    gears.Add(new Gear(x, y));
                }
            }
        }
        List<PartNumber> partNumbers = new dec3_1(input).run();

        foreach (Gear gear in gears)
        {
            List<PartNumber> inRatio = partNumbers.Where(part => part.gears.Contains(gear.id)).ToList();
            if(inRatio.Count == 2){
                answer += inRatio[0].number*inRatio[1].number;
            }
        }
        return answer;
    }
}