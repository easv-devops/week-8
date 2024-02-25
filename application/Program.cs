namespace Calculator;

class Program
{
    static async Task Main(string[] args)
    {
        ICalculator calculator = new Calculator();
        var db = new Database();

        await PerformCalculation(calculator, db);
        Console.WriteLine("Exiting...");
    }

    static async Task PerformCalculation(ICalculator calculator, Database logger)
    {
        try
        {
            Console.WriteLine("Enter the first number:");
            double num1 = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter the operation (+, -, x, /):");
            string operation = Console.ReadLine();

            Console.WriteLine("Enter the second number:");
            double num2 = double.Parse(Console.ReadLine());

            double result = operation switch
            {
                "+" => calculator.Add(num1, num2),
                "-" => calculator.Subtract(num1, num2),
                "x" => calculator.Multiply(num1, num2),
                "/" => calculator.Divide(num1, num2),
                _ => throw new InvalidOperationException("Invalid operation.")
            };

            Console.WriteLine($"Result: {result}");
            await logger.Log(operation, num1, num2, result);
        }
        catch (FormatException)
        {
            Console.WriteLine("Error: Invalid number format.");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}