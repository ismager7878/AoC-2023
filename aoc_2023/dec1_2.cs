using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Security;
using System.Runtime.ExceptionServices;
using System.Runtime.Intrinsics.Arm;

class AltDigit{
    static public List<string> altDigitsNames = ["one", "two", "three", "four", "five", "six", "seven", "eight", "nine"];
    public string name;
    public int index;
    public int number;
    public AltDigit(string name, int index){
        this.name = name;
        this.index = index;
        number = altDigitsNames.IndexOf(name) + 1;
    }
}
class dec1_2
{
    List<string> input;
    public dec1_2(List<string> input)
    {
        this.input = input;
    }
    public int run()
    {
        int answer = 0;
        foreach (string i in input)
        {
            List<AltDigit> altDigits = []; 
            int num = 0;
            if (AltDigit.altDigitsNames.Any(i.Contains))
            {
                foreach (string digit in AltDigit.altDigitsNames)
                {
                    char[] inputArray = i.ToCharArray();

                    int first = i.IndexOf(digit);
                    string revString = new string(i.Reverse().ToArray());
                    int last = revString.IndexOf(new string(digit.Reverse().ToArray()));

                    if (first > -1)
                    {
                        altDigits.Add(new AltDigit(digit, first));
                    }
                    if (last > -1)
                    {
                        last = i.Length - last - digit.Length;
                        altDigits.Add(new AltDigit(digit, last));
                    }
                }
            }
            altDigits.Sort((a,b)=> a.index - b.index);

            char[] iArray = i.ToCharArray();
            char[] iArrayRev = i.ToCharArray().Reverse().ToArray();

            for(int x = 0; x < iArray.Length; x++)
            {
                int charInt;
                if (int.TryParse(iArray[x].ToString(), out charInt))
                {

                    if(altDigits.Count > 0 && x > altDigits[0].index){
                        num = num * 10 + altDigits[0].number;
                        break;
                    }
                    num = num * 10 + charInt;
                    break;
                }
            }
            for(int x = 0; x < iArrayRev.Length; x++)
            {
                int charInt;
                if (int.TryParse(iArrayRev[x].ToString(), out charInt))
                {
                    if(altDigits.Count > 0 && (iArrayRev.Length - x - 1) < altDigits[altDigits.Count - 1].index){
                        num = num * 10 + altDigits[altDigits.Count - 1].number;
                        break;
                    }
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