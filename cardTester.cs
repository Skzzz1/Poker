// CardTester.cs
using System;

public class CardTester
{
    public static void RunAllTests()
    {
        Console.WriteLine("=== CARD CLASS TESTS ===\n");
        
        TestCardCreation();
        TestCardProperties();
        TestCardToString();
        TestCardComparison();
        
        Console.WriteLine("\n=== ALL CARD TESTS PASSED ===\n");
    }
    
    private static void TestCardCreation()
    {
        Console.WriteLine("Test 1: Card Creation");
        
        // Create different cards
        Card aceOfSpades = new Card(Card.Suit.Spade, Card.Rank.Ace);
        Card kingOfHearts = new Card(Card.Suit.Heart, Card.Rank.King);
        Card twoOfClubs = new Card(Card.Suit.Club, Card.Rank.Two);
        
        Console.WriteLine("  ✓ Created Ace of Spades");
        Console.WriteLine("  ✓ Created King of Hearts");
        Console.WriteLine("  ✓ Created Two of Clubs");
        Console.WriteLine();
    }
    
    private static void TestCardProperties()
    {
        Console.WriteLine("Test 2: Card Properties");
        
        Card card = new Card(Card.Suit.Diamond, Card.Rank.Queen);
        
        // Test getting suit
        if (card.CardSuit == Card.Suit.Diamond)
        {
            Console.WriteLine("  ✓ CardSuit property returns correct suit");
        }
        else
        {
            Console.WriteLine("  ✗ FAILED: CardSuit is wrong!");
        }
        
        // Test getting rank
        if (card.CardRank == Card.Rank.Queen)
        {
            Console.WriteLine("  ✓ CardRank property returns correct rank");
        }
        else
        {
            Console.WriteLine("  ✗ FAILED: CardRank is wrong!");
        }
        
        // Test rank values
        if ((int)card.CardRank == 12)
        {
            Console.WriteLine("  ✓ Queen has correct numeric value (12)");
        }
        else
        {
            Console.WriteLine("  ✗ FAILED: Queen value is wrong!");
        }
        
        Console.WriteLine();
    }
    
    private static void TestCardToString()
    {
        Console.WriteLine("Test 3: Card ToString Method");
        
        Card card1 = new Card(Card.Suit.Heart, Card.Rank.Ace);
        Card card2 = new Card(Card.Suit.Club, Card.Rank.Ten);
        
        string result1 = card1.ToString();
        string result2 = card2.ToString();
        
        Console.WriteLine($"  Ace of Hearts: {result1}");
        Console.WriteLine($"  Ten of Clubs: {result2}");
        
        if (result1.Contains("Ace") && result1.Contains("Hearts"))
        {
            Console.WriteLine("  ✓ ToString works correctly");
        }
        else
        {
            Console.WriteLine("  ✗ FAILED: ToString format is wrong!");
        }
        
        Console.WriteLine();
    }
    
    private static void TestCardComparison()
    {
        Console.WriteLine("Test 4: Card Rank Comparison");
        
        Card ace = new Card(Card.Suit.Spade, Card.Rank.Ace);
        Card king = new Card(Card.Suit.Heart, Card.Rank.King);
        Card two = new Card(Card.Suit.Diamond, Card.Rank.Two);
        
        // Test rank comparison
        if (ace.CardRank > king.CardRank)
        {
            Console.WriteLine("  ✓ Ace is higher than King");
        }
        else
        {
            Console.WriteLine("  ✗ FAILED: Ace should be higher than King!");
        }
        
        if (king.CardRank > two.CardRank)
        {
            Console.WriteLine("  ✓ King is higher than Two");
        }
        else
        {
            Console.WriteLine("  ✗ FAILED: King should be higher than Two!");
        }
        
        // Test numeric values
        Console.WriteLine($"  Ace value: {(int)ace.CardRank} (should be 14)");
        Console.WriteLine($"  King value: {(int)king.CardRank} (should be 13)");
        Console.WriteLine($"  Two value: {(int)two.CardRank} (should be 2)");
        
        Console.WriteLine();
    }
}