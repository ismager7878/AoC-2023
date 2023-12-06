using System.Dynamic;
using System.IO.Compression;

class SkratchCard{
    public int amount = 1;
    public int cardNumber;
    List<int> winningNumbers;
    List<int> myNumbers;
    public SkratchCard(string input){
        string[] nameNcard = input.Split(':');
        cardNumber = Convert.ToInt32(nameNcard[0].Split(' ').Last());
        winningNumbers = nameNcard[1].Split('|')[0].Split(' ').Where(x => int.TryParse(x, out int value)).Select(x => Convert.ToInt32(x)).ToList();
        myNumbers = nameNcard[1].Split('|')[1].Split(' ').Where(x => int.TryParse(x, out int value)).Select(x => Convert.ToInt32(x)).ToList();
    }
    public void add(int amount){
        this.amount += amount;
    }
    public int skratch(){
        int matches = 0;
        foreach(int num in myNumbers){
            if(winningNumbers.Contains(num)){
                matches++;
            }
        }
        return matches;
    }

}

class dec4_1{
    int answer = 0;
    List<string> input;
    List<SkratchCard> skratchCards = new List<SkratchCard>();
    public dec4_1(List<string> input){
        this.input = input;
    }

    public int run(){
        foreach(string line in input){
            skratchCards.Add(new SkratchCard(line));
        }

        List<int> results = new List<int>();
        for(int i = 0; i < skratchCards.Count; i++){
            SkratchCard card = skratchCards[i];
            if(results.Count < card.cardNumber){
                int result = card.skratch();
                results.Add(result);
            }
            for(int u = 0; u < results[card.cardNumber - 1]; u++){
                if(card.cardNumber + u < skratchCards.Count){
                    skratchCards[card.cardNumber + u].add(card.amount);
                }
            }
        }
        foreach(SkratchCard skratchCard in skratchCards){
            answer += skratchCard.amount;
        }
        return answer;
    }
}