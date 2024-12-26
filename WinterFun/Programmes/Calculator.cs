namespace WinterFun.Programmes;

public sealed class Calculator : IProgramme
{
    private const string Instructions = "Enter two numbers and an operation (+, -, *, /), "
                                        + "then calculates and prints the result.";

    public void Run()
    {
        while (true)
        {
            Util.ClearScreen();
            Console.WriteLine(Instructions);

            if (TryGetNumber("Enter the first number:", out double firstNumber).IsExit) return;
            if (TryGetNumber("Enter the second number:", out double secondNumber).IsExit) return;

            Console.WriteLine("Enter the operation (+, -, *, /):");
            string operation = Console.ReadLine() ?? string.Empty;

            if (operation == Constants.Constants.ExitCommand) return;

            double result = operation switch
            {
                "+" => firstNumber + secondNumber,
                "-" => firstNumber - secondNumber,
                "*" => firstNumber * secondNumber,
                "/" when Math.Abs(secondNumber) > 1e-10 => firstNumber / secondNumber,
                _ => double.NaN
            };

            Console.WriteLine(double.IsNaN(result)
                ? "Invalid operation or division by zero"
                : $"{firstNumber} {operation} {secondNumber} = {result}");

            Util.WaitUntilKeyPress();
        }
    }

    private static CalculatorResult TryGetNumber(string prompt, out double number)
    {
        Console.WriteLine(prompt);
        string input = Console.ReadLine() ?? string.Empty;

        if (input == Constants.Constants.ExitCommand)
        {
            number = 0;
            return new CalculatorResult(number, true);
        }

        if (!double.TryParse(input, out number))
        {
            Console.WriteLine("Invalid number");
            Thread.Sleep(2000);
            return new CalculatorResult(number, false);
        }

        return new CalculatorResult(number, false);
    }
}

public sealed record CalculatorResult(double Result, bool IsExit);