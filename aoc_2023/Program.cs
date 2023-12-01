// See https://aka.ms/new-console-template for more information

string inputString = File.ReadAllText("puzzle_inputs/1dec.txt");

List<string> input = inputString.Split("\n").ToList();

dec1_1 dec1_1 = new dec1_1(input);

int answer = dec1_1.run();

Console.WriteLine(answer);
