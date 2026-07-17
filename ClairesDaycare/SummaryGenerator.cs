using System;
using System.Collections.Generic;

public class SummaryGenerator
{
    public void GenerateSummary(List<Child> db)
    {
        Console.Clear();
        Console.WriteLine("--- END OF DAY SUMMARY ---");
        
        int totalPresent = 0;
        int missingSchedules = 0;
        int unresolvedAllergies = 0;

        foreach (var c in db)
        {
            if (c.IsPresent)
            {
                totalPresent++;
            }
            
            if (c.IsScheduled && !c.IsPresent)
            {
                missingSchedules++;
                Console.WriteLine($"[WARNING] {c.Name} was scheduled but never arrived.");
            }
            
            if (c.IsPresent && c.AllergyInfo != "None")
            {
                unresolvedAllergies++;
            }
        }

        // For FR-9: Generate Daily Summary 
        Console.WriteLine("\n--- DAILY METRICS ---");
        Console.WriteLine($"Total Children Supervised: {totalPresent}");
        Console.WriteLine($"Unresolved Absences: {missingSchedules}");
        Console.WriteLine($"High-Risk Allergies Managed: {unresolvedAllergies}");
        
        Console.WriteLine("\n[M] Press Enter to return to Menu.");
        Console.ReadLine();
    }
}