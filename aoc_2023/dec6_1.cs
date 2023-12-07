class Race{
    public int time;
    public double distance;

    public Race(int time, double distance){
        this.distance = distance;
        this.time = time;
    }
}

class dec6_1{
    double answer = 1; 
    List<string> input;

    public dec6_1(List<string> input){
        this.input = input;
    }

    public double run(){
        int[] times = input[0].Split(' ').Where(x => int.TryParse(x, out int value)).Select(x => Convert.ToInt32(x)).ToArray();
        long[] distances = input[1].Split(' ').Where(x => double.TryParse(x, out double value)).Select(x => Convert.ToInt64(x)).ToArray();

        List<Race> races = new List<Race>();

        for(int i = 0; i < times.Length; i++){
            races.Add(new Race(times[i], distances[i]));
        }

        foreach(Race race in races){
            int a = 1;
            double c = race.distance;
            int b = race.time;

            double min = Math.Abs(((-b) + Math.Sqrt(Math.Pow(b, 2) - 4 * a * c)) / (2 * a));
            double max = Math.Abs(((-b) - Math.Sqrt(Math.Pow(b, 2) - 4 * a * c)) / (2 * a));

            answer = answer * (Math.Floor(max) - Math.Ceiling(min) + 1);
        }
        return answer;
    }

}