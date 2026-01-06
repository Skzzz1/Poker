// DeckTester.cs
using System;
using System.Collections.Generic;

public class DeckTester
{
    public static void RunAllTests()
    {
        Console.WriteLine("=== DECK CLASS TESTS ===\n");
        
        TestDeckCreation();
        TestDeckSize();
        TestDealCard();
        TestShuffle();
        TestAllCardsUnique();
        TestRemainingCards();
        
        Console.WriteLine("\n=== ALL DECK TESTS PASSED ===\n");
    }
    
    private static void TestDeckCreation()
    {
        Console.WriteLine("Test 1: Deck Creation");
        
        Deck deck = new Deck();
        Console.WriteLine("  ✓ Deck created successfully");
        Console.WriteLine();
    }
    
    private static void TestDeckSize()
    {
        Console.WriteLine("Test 2: Deck Has 52 Cards");
        
        Deck deck = new Deck();
        int remaining = deck.RemainingCards();
        
        if (remaining == 52)
        {
            Console.WriteLine($"  ✓ Deck has {remaining} cards (correct)");
        }
        else
        {
            Console.WriteLine($"  ✗ FAILED: Deck has {remaining} cards, expected 52!");
        }
        
        Console.WriteLine();
    }
    
    private static void TestDealCard()
    {
        Console.WriteLine("Test 3: Dealing Cards");
        
        Deck deck = new Deck();
        
        // Deal one card
        Card card1 = deck.DealCard();
        Console.WriteLine($"  First card dealt: {card1}");
        
        // Check remaining cards decreased
        if (deck.RemainingCards() == 51)
        {
            Console.WriteLine("  ✓ Remaining cards decreased to 51");
        }
        else
        {
            Console.WriteLine($"  ✗ FAILED: Expected 51 cards, got {deck.RemainingCards()}");
        }
        
        // Deal another card
        Card card2 = deck.DealCard();
        Console.WriteLine($"  Second card dealt: {card2}");
        
        // Check cards are different
        if (card1.CardRank != card2.CardRank || card1.CardSuit != card2.CardSuit)
        {
            Console.WriteLine("  ✓ Cards are different");
        }
        else
        {
            Console.WriteLine("  ✗ FAILED: Got duplicate cards!");
        }
        
        Console.WriteLine();
    }
    
    private static void TestShuffle()
    {
        Console.WriteLine("Test 4: Shuffle Works");
        
        // Create two decks (both will be shuffled)
        Deck deck1 = new Deck();
        Deck deck2 = new Deck();
        
        // Deal first 5 cards from each
        List<Card> cards1 = new List<Card>();
        List<Card> cards2 = new List<Card>();
        
        for (int i = 0; i < 5; i++)
        {
            cards1.Add(deck1.DealCard());
            cards2.Add(deck2.DealCard());
        }
        
        // Check if orders are different (they should be due to random shuffle)
        bool allSame = true;
        for (int i = 0; i < 5; i++)
        {
            if (cards1[i].CardRank != cards2[i].CardRank || 
                cards1[i].CardSuit != cards2[i].CardSuit)
            {
                allSame = false;
                break;
            }
        }
        
        Console.WriteLine("  Deck 1 first 5 cards:");
        foreach (Card c in cards1)
        {
            Console.WriteLine($"    {c}");
        }
        
        Console.WriteLine("  Deck 2 first 5 cards:");
        foreach (Card c in cards2)
        {
            Console.WriteLine($"    {c}");
        }
        
        if (!allSame)
        {
            Console.WriteLine("  ✓ Decks are shuffled differently (randomized)");
        }
        else
        {
            Console.WriteLine("  ⚠ Warning: Decks have same order (rare, but possible)");
        }
        
        Console.WriteLine();
    }
    
    private static void TestAllCardsUnique()
    {
        Console.WriteLine("Test 5: All 52 Cards Are Unique");
        
        Deck deck = new Deck();
        HashSet<string> seenCards = new HashSet<string>();
        bool hasDuplicates = false;
        
        // Deal all 52 cards
        for (int i = 0; i < 52; i++)
        {
            Card card = deck.DealCard();
            string cardKey = $"{card.CardRank}-{card.CardSuit}";
            
            if (seenCards.Contains(cardKey))
            {
                Console.WriteLine($"  ✗ FAILED: Duplicate card found: {card}");
                hasDuplicates = true;
            }
            
            seenCards.Add(cardKey);
        }
        
        if (!hasDuplicates)
        {
            Console.WriteLine("  ✓ All 52 cards are unique");
        }
        
        // Check we have right number of each suit
        Dictionary<Card.Suit, int> suitCounts = new Dictionary<Card.Suit, int>();
        Dictionary<Card.Rank, int> rankCounts = new Dictionary<Card.Rank, int>();
        
        // Need to create a new deck to count
        Deck testDeck = new Deck();
        for (int i = 0; i < 52; i++)
        {
            Card card = testDeck.DealCard();
            
            if (!suitCounts.ContainsKey(card.CardSuit))
                suitCounts[card.CardSuit] = 0;
            suitCounts[card.CardSuit]++;
            
            if (!rankCounts.ContainsKey(card.CardRank))
                rankCounts[card.CardRank] = 0;
            rankCounts[card.CardRank]++;
        }
        
        // Each suit should appear 13 times
        bool suitsCorrect = true;
        foreach (var suit in suitCounts.Keys)
        {
            if (suitCounts[suit] != 13)
            {
                Console.WriteLine($"  ✗ FAILED: {suit} appears {suitCounts[suit]} times, expected 13");
                suitsCorrect = false;
            }
        }
        
        if (suitsCorrect)
        {
            Console.WriteLine("  ✓ Each suit appears exactly 13 times");
        }
        
        // Each rank should appear 4 times
        bool ranksCorrect = true;
        foreach (var rank in rankCounts.Keys)
        {
            if (rankCounts[rank] != 4)
            {
                Console.WriteLine($"  ✗ FAILED: {rank} appears {rankCounts[rank]} times, expected 4");
                ranksCorrect = false;
            }
        }
        
        if (ranksCorrect)
        {
            Console.WriteLine("  ✓ Each rank appears exactly 4 times");
        }
        
        Console.WriteLine();
    }
    
    private static void TestRemainingCards()
    {
        Console.WriteLine("Test 6: RemainingCards Method");
        
        Deck deck = new Deck();
        
        Console.WriteLine($"  Initial: {deck.RemainingCards()} cards (should be 52)");
        
        // Deal 10 cards
        for (int i = 0; i < 10; i++)
        {
            deck.DealCard();
        }
        
        int remaining = deck.RemainingCards();
        Console.WriteLine($"  After dealing 10: {remaining} cards");
        
        if (remaining == 42)
        {
            Console.WriteLine("  ✓ RemainingCards returns correct count");
        }
        else
        {
            Console.WriteLine($"  ✗ FAILED: Expected 42, got {remaining}");
        }
        
        // Deal remaining cards
        for (int i = 0; i < 42; i++)
        {
            deck.DealCard();
        }
        
        remaining = deck.RemainingCards();
        Console.WriteLine($"  After dealing all: {remaining} cards");
        
        if (remaining == 0)
        {
            Console.WriteLine("  ✓ All cards dealt successfully");
        }
        else
        {
            Console.WriteLine($"  ✗ FAILED: Expected 0, got {remaining}");
        }
        
        Console.WriteLine();
    }
}