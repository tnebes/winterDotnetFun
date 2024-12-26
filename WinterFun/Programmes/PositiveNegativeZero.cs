namespace WinterFun.Programmes;

public sealed class PositiveNegativeZero : IProgramme
{
    private const string Instructions = "Enter a number to check if it is positive, negative, or zero.";

    public void Run()
    {
        while (true)
        {
            Util.ClearScreen();
            PrintInstructions();
            Console.WriteLine("Enter a number: ");
            string input = Console.ReadLine() ?? string.Empty;

            if (input == Constants.Constants.ExitCommand) return;

            if (!long.TryParse(input, out long number))
            {
                Console.WriteLine("Invalid input. Please try again.");
                Thread.Sleep(1000);
                continue;
            }

            switch (number)
            {
                case > 0:
                    Console.WriteLine("The number is positive.");
                    break;
                case < 0:
                    Console.WriteLine("The number is negative.");
                    break;
                default:
                    Console.WriteLine("The number is zero.");
                    break;
            }

            Thread.Sleep(1000);
        }
    }

    private static void PrintInstructions()
    {
        Util.PrintInstructions(Instructions);
    }
}