using System;
using System.Collections.Generic;

public class AllergyTracker
{
    public void TrackAllergies(List<Child> db)
    {
        Console.Clear();
        Console.WriteLine("--- TRACK ALLERGIES ---");
        Console.Write("Enter Child's Full Name: ");
        
        string? searchName = Console.ReadLine();
        Child? targetChild = null;

        foreach (var c in db)
        {
            if (searchName != null && c.Name != null && c.Name.ToLower() == searchName.ToLower())
            {
                targetChild = c;
                break;
            }
        }

        if (targetChild != null)
        {
            Console.WriteLine("\nMATCH FOUND: " + targetChild.Name);
            
            if (targetChild.AllergyInfo != "None" && !string.IsNullOrEmpty(targetChild.AllergyInfo))
            {
                Console.WriteLine("!!! URGENT HEALTH ALERT !!!");
                Console.WriteLine(targetChild.AllergyInfo);
            }
            else
            {
                Console.WriteLine("\nNo known allergies.");
            }
        }
        else
        {
            Console.WriteLine("Child not found.");
            Console.ReadLine();
        }
        Console.WriteLine("\nPress Enter to return to main menu...");
        Console.ReadLine();
    }
}