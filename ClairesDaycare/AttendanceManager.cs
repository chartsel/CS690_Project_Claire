using System;
using System.Collections.Generic;

public class AttendanceManager
{
    public void ManageAttendance(List<Child> db)
    {
        Console.Clear();
        Console.WriteLine("--- MANAGE ATTENDANCE ---");
        Console.Write("Enter Child ID: ");
        
        string? searchId = Console.ReadLine();
        
        Child? targetChild = null; 

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
            string? choice = Console.ReadLine();
            
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
}