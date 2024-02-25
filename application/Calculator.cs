namespace Calculator;

public class Calculator : ICalculator
{
    public double Add(double n1, double n2)
    {
        return n1 + n2;
    }

    public double Subtract(double n1, double n2)
    {
        return n1 - n2;
    }

    public double Multiply(double n1, double n2)
    {
        return n1 * n2;
    }

    public double Divide(double n1, double n2)
    {
        if (n2 == 0) { 
            throw new DivideByZeroException("Cannot divide by zero.");
        }

        return n1 / n2;
    }
}