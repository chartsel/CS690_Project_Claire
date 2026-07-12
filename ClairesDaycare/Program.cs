using System;
using System.Collections.Generic;

public class Child
{
    public string Id { get; set; }
    public string Name { get; set; }
    public bool IsScheduled { get; set; }
    public bool IsPresent { get; set; }
    public string AllergyInfo { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        // Move this to a file or database in iteration 2
        // Hardcoding seed data for testing
        List<Child> database = new List<Child>
        {
            new Child { Id = "8812", Name = "Tiffany Camden", IsScheduled = true, IsPresent = false, AllergyInfo = "None" },
            new Child { Id = "1024", Name = "Timmy Miller", IsScheduled = true, IsPresent = true, AllergyInfo = "SEVERE PEANUT ALLERGY" }
        };

        bool running = true;
        while (running)
        {
            // Trying to match the UI prototypes on the wiki
            Console.Clear();
            Console.WriteLine("================================");
            Console.WriteLine("    CLAIRE'S DAYCARE MANAGER    ");
            Console.WriteLine("================================");
            Console.WriteLine("[1] Manage daily attendance");
            Console.WriteLine("[2] Track allergies");
            
            // Implement UC-2 and UC-4 in the next phase:
            // Console.WriteLine("[3] Verify staff-to-child ratios");
            // Console.WriteLine("[4] Check authorized pickups");
            
            Console.WriteLine("================================");
            Console.Write("TYPE CHOICE AND HIT ENTER > ");

            string input = Console.ReadLine();

            if (input == "1")
            {
                ManageAttendance(database);
            }
            else if (input == "2")
            {
                TrackAllergies(database);
            }
            
            else
            {
                Console.WriteLine("Invalid option. Press any key to try again.");
                Console.ReadKey();
            }
        }
    }

    static void ManageAttendance(List<Child> db)
    {
        Console.Clear();
        Console.WriteLine("--- MANAGE ATTENDANCE ---");
        Console.Write("Enter Child ID: ");
        string searchId = Console.ReadLine();

        Child targetChild = null;
        foreach (var c in db)
        {
            if (c.Id == searchId)
            {
                targetChild = c;
                break;
            }
        }

        if (targetChild != null)
        {
            Console.WriteLine("\nRECORD RETRIEVED!");
            Console.WriteLine("* Name: " + targetChild.Name);
            Console.WriteLine("* Scheduled: " + targetChild.IsScheduled);
            Console.WriteLine("* Status: " + (targetChild.IsPresent ? "CHECKED IN" : "Not checked in"));
            
            Console.Write("\n[Z] Change status to CHECKED IN? (Y/N): ");
            string choice = Console.ReadLine();
            
            // Handle imperfect user entry
            if (choice == "Y" || choice == "y")
            {
                targetChild.IsPresent = true;
                Console.WriteLine("Status updated successfully.");
            }
            else
            {
                Console.WriteLine("Update cancelled.");
            }
        }
        else
        {
            Console.WriteLine("Child ID not found.");
        }
        
        Console.WriteLine("\nPress Enter to return to main menu...");
        Console.ReadLine();
    }

    static void TrackAllergies(List<Child> db)
    {
        Console.Clear();
        Console.WriteLine("--- TRACK ALLERGIES ---");
        Console.Write("Enter Child's Full Name: ");
        string searchName = Console.ReadLine();

        Child targetChild = null;
        foreach (var c in db)
        {
            // Case-insensitive check that a student would write manually
            if (c.Name.ToLower() == searchName.ToLower())
            {
                targetChild = c;
                break;
            }
        }

        if (targetChild != null)
        {
            Console.WriteLine("\nMATCH FOUND: " + targetChild.Name);
            
            // Checking string empty or "None" to catch edge cases
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
        }

        Console.WriteLine("\nPress Enter to return to main menu...");
        Console.ReadLine();
    }
}