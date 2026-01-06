using System;
using System.ComponentModel.DataAnnotations;
using System.Net.Security;

public class Deck
{
    private List<Card> cards;
    private int currCard;
    public Deck()
    {
        cards = new List<Card>();
        Reset();
        Shuffle();
    }

    public void Shuffle()
    {
        Random random = new Random();
        int n = cards.Count;
        //Fisher- Yates
        while(n > 1)
        {
            int j = random.Next(0,n);
            n--;
            Card temp = cards[j];
            cards[j] = cards[n];
            cards[n] = temp;
        }
    }

    public Card DealCard()
    {
        if(currCard >= cards.Count)
        {
            throw new Exception("Deck is empty! This shouldn't happen in poker.");
        }
        return cards[currCard++];
    }

    public void Reset()
    {
        cards.Clear();
        foreach(Card.Suit s in Enum.GetValues(typeof(Card.Suit)))
        {
            foreach (Card.Rank r in Enum.GetValues(typeof(Card.Rank)))
            {
                cards.Add(new Card(s,r));
            }
        }
        currCard = 0;
    }

    public int RemainingCards()
    {
        return cards.Count - currCard;
    }
}