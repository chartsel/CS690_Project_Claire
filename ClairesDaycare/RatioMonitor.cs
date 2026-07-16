using System;
using System.Collections.Generic;

public class RatioMonitor
{
    public void VerifyRatio(List<Child> db)
    {
        Console.Clear();
        Console.WriteLine("--- VERIFY STAFF-TO-CHILD RATIO ---");
        
        // Initialize counter variable and increase if child checks in
        int presentChildren = 0;
        foreach (var c in db)
        {
            if (c.IsPresent)
            {
                presentChildren++;
            }
        }

        Console.WriteLine("[STATUS LOG] System Query Active...");
        Console.WriteLine("\nCURRENT HEADCOUNT:");
        Console.WriteLine($"* Total Present Children: [{presentChildren}]");
        
        Console.Write("* Enter Total Active Staff: ");
        string? staffInput = Console.ReadLine();
        
        if (int.TryParse(staffInput, out int activeStaff) && activeStaff > 0)
        {
            double ratio = (double)presentChildren / activeStaff;
            Console.WriteLine("\nFINAL METRIC:");
            Console.WriteLine($"* CURRENT RATIO: {Math.Round(ratio, 1)}:1");

            // Assume daycare ratio limit of 8:1
            if (ratio > 8.0)
            {
                Console.WriteLine("\n[!] [WARNING] [!]");
                Console.WriteLine("RATIO EXCEEDS LEGAL LIMITS!");
                Console.WriteLine("YOU MUST CALL IN ADDITIONAL STAFF");
            }
            else
            {
                Console.WriteLine("\nRatio is within safe legal limits.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Staff count must be a number greater than zero.");
        }

        Console.WriteLine("\n[M] Press Enter to return to Menu...");
        Console.ReadLine();
    }
}