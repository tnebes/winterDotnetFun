namespace WinterFun.Programmes;

public sealed class TemperatureConversion : IProgramme
{
    private const string Instructions = "Enter a temperature to convert between Celsius and Fahrenheit.";

    public void Run()
    {
        while (true)
        {
            Util.ClearScreen();
            Util.PrintInstructions(Instructions);
            Console.WriteLine("Enter temperature with unit (e.g. 32C or 100F): ");
            string input = Console.ReadLine()?.Trim() ?? string.Empty;

            if (input == Constants.Constants.ExitCommand) return;

            if (input.Length < 2 || !double.TryParse(input[..^1], out double temperature))
            {
                Console.WriteLine(Constants.Constants.InvalidInputMessage);
                Thread.Sleep(1000);
                continue;
            }

            char unit = char.ToUpper(input[^1]);
            double converted;
            string result;

            if (unit == 'C')
            {
                converted = temperature * 9 / 5 + 32;
                result = $"{temperature}°C = {converted:F1}°F";
            }
            else if (unit == 'F')
            {
                converted = (temperature - 32) * 5 / 9;
                result = $"{temperature}°F = {converted:F1}°C";
            }
            else
            {
                Console.WriteLine(Constants.Constants.InvalidInputMessage);
                Thread.Sleep(1000);
                continue;
            }

            Util.ClearScreen();
            Console.WriteLine(result);
            Util.WaitUntilKeyPress();
        }
    }
}