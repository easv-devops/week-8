using Calculator;

namespace tests;

public class CalculatorTests
{
    private ICalculator _calculator;

    [SetUp]
    public void Setup()
    {
        _calculator = new Calculator.Calculator();
    }

    [Test]
    public void AddTest()
    {
        var result = _calculator.Add(5, 3);
        Assert.That(result, Is.EqualTo(8));
    }

    [Test]
    public void SubtractTest()
    {
        var result = _calculator.Subtract(5, 3);
        Assert.That(result, Is.EqualTo(2));
    }

    [Test]
    public void MultiplyTest()
    {
        var result = _calculator.Multiply(5, 3);
        Assert.That(result, Is.EqualTo(15));
    }

    [Test]
    public void DivideTest()
    {
        var result = _calculator.Divide(6, 3);
        Assert.That(result, Is.EqualTo(2));
    }

    [Test]
    public void DivideByZeroTest()
    {
        Assert.Throws<System.DivideByZeroException>(() => _calculator.Divide(5, 0));
    }
    
    [Test]
    public void AddNegativeNumbersTest()
    {
        var result = _calculator.Add(-5, -3);
        Assert.That(result, Is.EqualTo(-8));
    }

    [Test]
    public void DivideZeroByZeroTest()
    {
        Assert.Throws<System.DivideByZeroException>(() => _calculator.Divide(0, 0));
    }
    
    [Test]
    public void MultiplyLargeNumbersTest()
    {
        var result = _calculator.Multiply(1e300, 2);
        Assert.That(result, Is.EqualTo(2e300));
    }
}