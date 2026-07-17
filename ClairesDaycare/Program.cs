using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        DatabaseManager dbManager = new DatabaseManager();
        List<Child> database = dbManager.LoadDatabase("database.csv");
        
        AttendanceManager attendanceManager = new AttendanceManager();
        AllergyTracker allergyTracker = new AllergyTracker();
        RatioMonitor ratioMonitor = new RatioMonitor();
        PickupValidator pickupValidator = new PickupValidator();
        
        SummaryGenerator summaryGenerator = new SummaryGenerator();
        
        bool running = true;
        while (running)
        {
            Console.Clear();
            Console.WriteLine("================================");
            Console.WriteLine("    CLAIRE'S DAYCARE MANAGER    ");
            Console.WriteLine("================================");
            Console.WriteLine("[1] Manage daily attendance");
            Console.WriteLine("[2] Track allergies");
            Console.WriteLine("[3] Verify staff-to-child ratios");
            Console.WriteLine("[4] Check authorized pickups");
            Console.WriteLine("[5] Generate end-of-day summary");
            Console.WriteLine("================================");
            Console.Write("TYPE CHOICE AND HIT ENTER > ");
            
            string? input = Console.ReadLine();
            
            if (input == "1")
            {
                attendanceManager.ManageAttendance(database);
            }
            else if (input == "2")
            {
                allergyTracker.TrackAllergies(database);
            }
            else if (input == "3")
            {
                ratioMonitor.VerifyRatio(database);
            }
            else if (input == "4")
            {
                pickupValidator.VerifyPickup(database);
            }
            else if (input == "5")
            {
                summaryGenerator.GenerateSummary(database);
            }
            else
            {
                Console.WriteLine("Invalid option. Press any key to try again.");
                Console.ReadKey();
            }
        }
    }
}