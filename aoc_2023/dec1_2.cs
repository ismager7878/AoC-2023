using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.ExceptionServices;
using System.Runtime.Intrinsics.Arm;

class dec1_2
{
    List<string> input;
    List<string> altDigits = ["one", "two", "three", "four", "five", "six", "seven", "eight", "nine"];

    public dec1_2(List<string> input)
    {
        this.input = input;
    }
    public int run()
    {
        int answer = 0;
        foreach (string i in input)
        {
            string inputString = i;
            int num = 0;
            if (altDigits.Any(i.Contains))
            {
                foreach (string digit in altDigits)
                {
                    char[] inputArray = inputString.ToCharArray();

                    int first = inputString.IndexOf(digit);
                    string revString = new string(inputString.Reverse().ToArray());
                    int last = revString.IndexOf(new string(digit.Reverse().ToArray()));

                    if (first > -1)
                    {
                        inputArray[first] = char.Parse((altDigits.IndexOf(digit) + 1).ToString());
                    }
                    if (last > -1)
                    {
                        last = inputString.Length - last - 1;
                        inputArray[last] = char.Parse((altDigits.IndexOf(digit) + 1).ToString());
                    }
                    inputString = new string(inputArray);
                }
            }
            char[] iArray = inputString.ToCharArray();
            char[] iArrayRev = inputString.ToCharArray().Reverse().ToArray();

            foreach (char c in iArray)
            {
                int charInt;
                if (int.TryParse(c.ToString(), out charInt))
                {
                    num = num * 10 + charInt;
                    break;
                }
            }
            foreach (char c in iArrayRev)
            {
                int charInt;
                if (int.TryParse(c.ToString(), out charInt))
                {
                    num = num * 10 + charInt;
                    break;
                }
            }
            answer += num;
            answer = answer;
        }
        return answer;
    }
}