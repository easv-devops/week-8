using Calculator;

namespace tests;

[TestFixture]
public class DatabaseIntegrationTest
{
    private Database _database;

    [SetUp]
    public void Setup()
    {
        _database = new Database();
    }

    [Test]
    public async Task CheckIntegration()
    {
        string operation = "add";
        double n1 = 1.0, n2 = 2.0, result = 3.0;
        
        await _database.Log(operation, n1, n2, result);
        
        var logEntry = await _database.GetLogEntry(operation, n1, n2, result);
        Assert.IsNotNull(logEntry);
        Assert.That(logEntry.Operation, Is.EqualTo(operation));
        Assert.That(logEntry.Number1, Is.EqualTo(n1));
        Assert.That(logEntry.Number2, Is.EqualTo(n2));
        Assert.That(logEntry.Result, Is.EqualTo(result));
    }
}