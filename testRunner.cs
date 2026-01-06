// TestRunner.cs (Main Program)
using System;

public class TestRunner
{
    public static void Main()
    {
        Console.WriteLine("╔══════════════════════════════════════╗");
        Console.WriteLine("║   POKER GAME - UNIT TESTS           ║");
        Console.WriteLine("╔══════════════════════════════════════╗");
        Console.WriteLine();
        
        try
        {
            // Run Card tests
            CardTester.RunAllTests();
            
            // Run Deck tests
            DeckTester.RunAllTests();
            
            Console.WriteLine("╔══════════════════════════════════════╗");
            Console.WriteLine("║   ALL TESTS COMPLETED SUCCESSFULLY   ║");
            Console.WriteLine("╔══════════════════════════════════════╗");
        }
        catch (Exception e)
        {
            Console.WriteLine("\n✗✗✗ TEST FAILED WITH EXCEPTION ✗✗✗");
            Console.WriteLine(e.Message);
            Console.WriteLine(e.StackTrace);
        }
        
        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}