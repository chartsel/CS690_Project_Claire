using System.IO;
using Xunit;

public class DatabaseManagerTests
{
    [Fact]
    public void LoadDatabase_ValidCsv_ReturnsPopulatedList()
    {
        // Arrange
        // `GetTempFileName` finds a place in directory to safely store data without overwriting something
        string tempPath = Path.GetTempFileName();
        File.WriteAllText(tempPath, "8812,Tiffany Camden,true,false,None");
        var manager = new DatabaseManager();

        // Act
        var db = manager.LoadDatabase(tempPath);

        // Assert
        Assert.Single(db);
        Assert.Equal("Tiffany Camden", db[0].Name);

        // Cleanup
        File.Delete(tempPath);
    }cd ../ClairesDaycare
}