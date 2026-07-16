using System;
using System.IO;
using System.Collections.Generic;
using Xunit;

public class AllergyTrackerTests
{
    [Fact]
    public void TrackAllergies_Allergy_Warning()
    {
        // Arrange
        var db = new List<Child>
        {
            new Child { Id = "1024", Name = "Timmy Miller", IsScheduled = true, IsPresent = true, AllergyInfo = "SEVERE PEANUT ALLERGY" }
        };
        var tracker = new AllergyTracker();

        // Simulate typing "Timmy Miller" and pressing Enter twice.
        var simulatedInput = new StringReader("Timmy Miller\n\n");
        Console.SetIn(simulatedInput);

        var simulatedOutput = new StringWriter();
        Console.SetOut(simulatedOutput);

        // Act
        tracker.TrackAllergies(db);

        // Assert
        string consoleText = simulatedOutput.ToString();
        Assert.Contains("!!! URGENT HEALTH ALERT !!!", consoleText);
    }
}