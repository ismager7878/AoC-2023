class PartNumber
{
    public int number;
    public List<string> gears = [];
    public PartNumber(int number, List<string> gears)
    {
        this.number = number;
        this.gears = gears;
    }
}
class dec3_1
{
    int answer = 0;
    List<string> input;
    public dec3_1(List<string> input)
    {
        this.input = input;
    }

    public List<PartNumber> run()
    {
        List<PartNumber> partNumbers = [];
        foreach (string line in input)
        {
            if (line == "")
            {
                continue;
            }
            for (int i = 0; i < line.Length; i++)
            {
                int num;
                if (!int.TryParse(line[i].ToString(), out num))
                {
                    continue;
                }

                int index = i;
                bool end = false;
                int offset = 1;
                List<char> border = [];
                while (!end)
                {
                    int digit;
                    if (i + offset < line.Length && int.TryParse(line[i + offset].ToString(), out digit))
                    {
                        num = num * 10 + digit;
                        offset++;
                    }
                    else
                    {
                        i += offset;
                        end = true;
                    }
                }
                //Get above border
                int aboveIndex = input.IndexOf(line) - 1;
                int underIndex = aboveIndex + 2;

                int borderStart = index - 1 < 0 ? 0 : index - 1;
                int borderLenght = offset + (index - 1 < 0 ? 0 : 1) + (index + offset == input[0].Length ? 0 : 1);
                List<string> gears = [];

                if (aboveIndex > -1)
                {
                    char[] topBorder = input[aboveIndex].Substring(borderStart, borderLenght).ToCharArray();
                    int cor = 0;
                    topBorder.Where(x => x.Equals('*')).ToList().ForEach(x =>
                    {
                        gears.Add($"{aboveIndex},{topBorder.ToList().IndexOf(x) + index - (index == 0 ? 0 : 1)}");
                        cor++;
                    });
                    border.AddRange(topBorder);
                }
                if (underIndex < input.Count && underIndex != 140)
                {
                    char[] bottomBorder = input[underIndex].Substring(borderStart, borderLenght).ToCharArray();
                    int cor = 0;
                    bottomBorder.Where(x => x.Equals('*')).ToList().ForEach(x =>
                    {
                        gears.Add($"{underIndex},{bottomBorder.ToList().IndexOf(x) + index - (index == 0 ? 0 : 1)}");
                        cor++;
                    });
                    border.AddRange(bottomBorder);
                }
                if (index - 1 > -1)
                {
                    char borderLeft = line[index - 1];
                    if (borderLeft == '*')
                    {
                        gears.Add($"{input.IndexOf(line)},{index - 1}");
                    }
                    border.Add(borderLeft);
                }
                if (i < line.Length)
                {
                    char borderLeft = line[i];
                    if (borderLeft == '*')
                    {
                        gears.Add($"{input.IndexOf(line)},{i}");
                    }
                    border.Add(borderLeft);
                }
                int hey;
                if (border.Any(x => !int.TryParse(x.ToString(), out hey) && x != '.'))
                {
                    partNumbers.Add(new PartNumber(num, gears));
                }
            }
        }
        List<string> usedGears = [];
        foreach (PartNumber part in partNumbers)
        {
            answer += part.number;
            // List<PartNumber> inRatio = partNumbers.Where(x => x.gears.Intersect(part.gears).Any()).ToList();
            // List<string> gears = [];
            // foreach (string gear in part.gears)
            // {
            //     if (inRatio.Where(x => x.gears.Contains(gear)).Count() == 2)
            //     {
            //         if (!usedGears.Contains(gear))
            //         {
            //             answer += part.number * inRatio.Where(y => y.gears.Contains(gear) && y != part).First().number;
            //             usedGears.Add(gear);
            //         }
            //     }
            // }
        }
        return partNumbers;
    }
}