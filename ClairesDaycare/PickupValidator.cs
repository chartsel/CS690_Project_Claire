using System;
using System.Collections.Generic;

public class PickupValidator
{
    public void VerifyPickup(List<Child> db)
    {
        Console.Clear();
        Console.WriteLine("--- CHECK AND AUTHORIZE PICKUPS ---");
        
        Console.Write("[STEP 1] Enter Child's Name: ");
        string? childName = Console.ReadLine();
        
        Console.Write("[STEP 2] Enter Name of Adult Attempting Pickup: ");
        string? adultName = Console.ReadLine();

        Child? targetChild = null;

        foreach (var c in db)
        {
            if (childName != null && c.Name != null && c.Name.ToLower() == childName.ToLower())
            {
                targetChild = c;
                break;
            }
        }

        Console.WriteLine("\nDATABASE SEARCH:");
        Console.WriteLine($"* Child name entered: {childName}");
        Console.WriteLine($"* Adult name entered: {adultName}");

        if (targetChild != null && adultName != null && targetChild.AuthorizedGuardians != null)
        {
            bool isAuthorized = targetChild.AuthorizedGuardians.ToLower().Contains(adultName.ToLower());
            
            Console.WriteLine($"*** PICKUP ALLOWANCE STATUS: {isAuthorized.ToString().ToUpper()} ***");
            
            if (isAuthorized)
            {
                Console.WriteLine("\n[✓] SECURITY CLEARANCE GRANTED [✓]");
                Console.WriteLine("You may safely release the child.");
            }
            else
            {
                Console.WriteLine("\n[!] SECURITY ALERT [!]");
                Console.WriteLine("PICKUP ALLOWANCE: DENIED");
                Console.WriteLine($"SYSTEM NOTE: Do not release {targetChild.Name} to {adultName}.");
            }
        }
        else
        {
            Console.WriteLine("\n[!] ERROR: Child record not found.");
        }

        Console.WriteLine("\n[M] Press Enter to return to Menu.");
        Console.ReadLine();
    }
}