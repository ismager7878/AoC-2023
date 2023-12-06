class Race{
    int time;
    int distance;

    public Race(int time, int distance){
        this.distance = distance;
        this.time = time;
    }
}

class dec6_1{
    int answer = 0; 
    List<string> input;

    public dec6_1(List<string> input){
        this.input = input;
    }

    public int run(){
        int[] times = input[0].Split(' ').Where(x => int.TryParse(x, out int value)).Select(x => Convert.ToInt32(x)).ToArray();
        int[] distances = input[1].Split(' ').Where(x => int.TryParse(x, out int value)).Select(x => Convert.ToInt32(x)).ToArray();

        List<Race> races = new List<Race>();

        for(int i = 0; i < times.Length; i++){
            races.Add(new Race(times[i], distances[i]));
        }
        return answer;
    }

}