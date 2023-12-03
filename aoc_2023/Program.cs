// See https://aka.ms/new-console-template for more information

string inputString = File.ReadAllText("puzzle_inputs/1dec.txt");

List<string> input = inputString.Split("\r\n").ToList();

dec1_1 dec1_1 = new dec1_1(input);
dec1_2 dec1_2 = new dec1_2(input);

int answer = dec1_2.run();

Console.WriteLine(answer);
