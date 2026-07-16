using System;
using System.Collections.Generic;
using System.IO;

public class DatabaseManager
{
    public List<Child> LoadDatabase(string filePath)
    {
        var db = new List<Child>();
        
        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);
            
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                
                if (parts.Length == 6) 
                {
                    db.Add(new Child
                    {
                        Id = parts[0],
                        Name = parts[1],
                        IsScheduled = bool.Parse(parts[2]),
                        IsPresent = bool.Parse(parts[3]),
                        AllergyInfo = parts[4],
                        AuthorizedGuardians = parts[5]
                    });
                }
            }
        }
        else
        {
            Console.WriteLine("Database file not found.");
        }
        return db;
    }
}