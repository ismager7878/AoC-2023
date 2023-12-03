// See https://aka.ms/new-console-template for more information

string inputString = File.ReadAllText("puzzle_inputs/3dec.txt");

List<string> input = inputString.Split("\r\n").ToList();

//dec1_1 dec1_1 = new dec1_1(input);
//dec1_2 dec1_2 = new dec1_2(input);
//dec2_1 dec2_1 = new dec2_1(input);
//dec2_2 dec2_2 = new dec2_2(input);
//dec3_1 dec3_1 = new dec3_1(input);
dec3_2 dec3_2 = new dec3_2(input);

int answer = dec3_2.run();

Console.WriteLine(answer);
