class Hand{
    public int score;
    public int bet;
    public string cards;

    public Hand(string cards, int bet)
    {
        Bet = bet;
        this.cards = cards;
        List<char> distinctCards = cards.ToCharArray().Distinct().ToList();
        int distinctCardsCount = distinctCards.Count;
        if (distinctCards.Contains('J') && distinctCardsCount != 1)
        {
            distinctCardsCount--;
        }
        if (distinctCardsCount == 5)
        {
            score = 1;
        }
        if (distinctCardsCount == 4)
        {
            score = 2;
        }
        if (distinctCardsCount == 3)
        {
            if (distinctCards.Any(dCard => cards.ToCharArray().ToList().ConvertAll<char>(x => x == 'J' ? dCard : x).Where(card => dCard == card).Count() == 3))
            {
                score = 4;
            }
            else
            {
                score = 3;
            }
        }
        if (distinctCardsCount == 2)
        {
            if (distinctCards.Any(dCard => cards.ToCharArray().ToList().ConvertAll<char>(x => x == 'J' ? dCard : x).Where(card => dCard == card).Count() == 4))
            {
                score = 6;
            }
            else
            {
                score = 5;
            }
        }
        if (distinctCardsCount == 1)
        {
            score = 7;
        }

    }
}
//distinctCards.Any(dCard => cards.ToCharArray().ToList().ConvertAll<char>(x => x == 'J' ? dCard : x).Where(card => dCard == card).Count() == 3)

class dec7_1
{
    int answer = 0;
    List<string> input = new List<string>();

    List<Hand> hands = new List<Hand>();
    List<char> cardOrder = ['J', '2', '3', '4', '5', '6', '7', '8', '9', 'T', 'Q', 'K', 'A'];
    public dec7_1(List<string> input)
    {
        this.input = input;
    }

    int compareHighcard(Hand a, Hand b)
    {
        for (int i = 0; i < a.cards.Length; i++)
        {
            int aVal = cardOrder.IndexOf(a.cards[i]);
            int bVal = cardOrder.IndexOf(b.cards[i]);
            if (aVal == bVal)
            {
                continue;
            }
            return aVal - bVal;
        }
        return 0;
    }

    public int run()
    {
        foreach (string line in input)
        {
            string[] cardsNbet = line.Split(' ');
            hands.Add(new Hand(cardsNbet[0], Convert.ToInt32(cardsNbet[1])));
        }
        hands.Sort(compareHighcard);
        hands = hands.OrderBy(hand => hand.Score).ToList();

        hands[0].Bet = 0;
        for (int i = 0; i < hands.Count; i++)
        {
            answer += (i + 1) * hands[i].bet;
        }
        return answer;
    }
}