using System.IO.Compression;

class Node{
    public string Name {get;}
    public string Left {get;}
    public string Right {get;}

    public Node(string name, string left, string right){
        Name = name;
        Left = left;
        Right = right;
    }
}

class dec8_1{
    int answer = 0;
    List<string> input;

    public dec8_1(List<string> input){
        this.input = input;
    }

    public int run(){
        string instructions = input[0];
        List<Node> nodes = input.GetRange(2, input.Count - 2).ConvertAll<Node>(x => {
            string cleaned = x.Replace('=', ' ').Replace('(',' ').Replace(')', ' ').Replace(',', ' ');
            List<string> listed = cleaned.Split(" ").Where(y => y != "").ToList();
            return new Node(listed[0], listed[1], listed[2]);
        });

        bool done = false;
        Node currentNode = nodes.Where(x => x.Name == "AAA").First();
        while(!done){
            foreach(char i in instructions){
                if(i == 'R'){
                    currentNode = nodes.Where(x => x.Name == currentNode.Right).First();
                }else{
                    currentNode = nodes.Where(x => x.Name == currentNode.Left).First();
                }
                answer++;
                if(currentNode.Name == "ZZZ"){
                    done = true;
                    break;
                }
            }
        }
        return answer;
    }
}
