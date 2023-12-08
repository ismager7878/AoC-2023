class dec8_2{
    long answer = 0;
    List<string> input;

    public dec8_2(List<string> input){
        this.input = input;
    }

    public long run(){
        string instructions = input[0];
        List<Node> nodes = input.GetRange(2, input.Count - 2).ConvertAll<Node>(x => {
            string cleaned = x.Replace('=', ' ').Replace('(',' ').Replace(')', ' ').Replace(',', ' ');
            List<string> listed = cleaned.Split(" ").Where(y => y != "").ToList();
            return new Node(listed[0], listed[1], listed[2]);
        });

        bool done = false;
        List<Node> currentNodes = nodes.Where(x => x.Name.EndsWith('A')).ToList();
        while(!done){
            foreach(char i in instructions){
                for(int n = 0; n < currentNodes.Count; n++){
                    if(i == 'R'){
                        currentNodes[n] = nodes.Where(x => x.Name == currentNodes[n].Right).First();
                    }else{
                        currentNodes[n] = nodes.Where(x => x.Name == currentNodes[n].Left).First();
                    }
                }
                answer++;
                if(currentNodes.All(x => x.Name.EndsWith('Z'))){
                    done = true;
                    break;
                }
            }
        }
        return answer;
    }
}
