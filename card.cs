using System;
using System.Data;

public class Card
{
    public enum Suit
    {
        Heart, Diamond, Club, Spade
    }

    public enum Rank
    {
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        Ten = 10,
        Jack = 11,
        Queen = 12,
        King = 13,
        Ace = 1
    }
    public Suit CardSuit {get; private set;}
    public Rank CardRank {get; private set;}

    public Card (Suit s, Rank r)
    {
        CardSuit = s;
        CardRank = r;
    }

    public override string ToString()
    {
        return $"{CardSuit} - {CardRank} ";
    }
}