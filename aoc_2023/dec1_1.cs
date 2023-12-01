using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Intrinsics.Arm;

class dec1_1{
    List<string> input;

    public dec1_1(List<string> input){
        this.input = input;
    }
    public int run(){
        int answer = 0;
        foreach(string i in input){
            int num = 0;
            char[] iArray = i.ToCharArray();
            char[] iArrayRev = i.ToCharArray().Reverse().ToArray();

            foreach(char c in iArray){
                int charInt;
                if(int.TryParse(c.ToString(), out charInt)){
                    num = num * 10 + charInt;
                    break;
                }
            }
            foreach(char c in iArrayRev){
                int charInt;
                if(int.TryParse(c.ToString(), out charInt)){
                    num = num * 10 + charInt;
                    break;
                }
            }
            answer += num;
        }
        return answer;
    }
}