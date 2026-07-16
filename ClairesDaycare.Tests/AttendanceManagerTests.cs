using System;
using System.IO;
using System.Collections.Generic;
using Xunit;

public class AttendanceManagerTests
{
    [Fact]
    public void ManageAttendance_ValidId_UpdatesStatus()
    {
        // Arrange
        var db = new List<Child>
        {
            new Child { Id = "8812", Name = "Tiffany Camden", IsScheduled = true, IsPresent = false, AllergyInfo = "None" }
        };
        var manager = new AttendanceManager();

        var simulatedInput = new StringReader("8812\nY\n\n");
        Console.SetIn(simulatedInput);

        var simulatedOutput = new StringWriter();
        Console.SetOut(simulatedOutput);

        // Act
        manager.ManageAttendance(db);

        // Assert
        Assert.True(db[0].IsPresent);
    }
}