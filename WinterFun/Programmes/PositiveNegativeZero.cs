using Microsoft.VisualBasic;
using WinterFun.Constants;
using WinterFun.Programmes;
using Constants = WinterFun.Constants.Constants;

namespace WinterFun.Programmes;

public sealed class PositiveNegativeZero : IProgramme
{
    public void Run()
    {
        while (true)
        {
            Util.ClearScreen();
            PrintInstructions();
            Console.WriteLine("Enter a number: ");
            string input = Console.ReadLine();

            if (input == Constants.Constants.ExitCommand) return;

            if (!long.TryParse(input, out long number))
            {
                Console.WriteLine("Invalid input. Please try again.");
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

            Thread.Sleep(2000);
        }
    }

    private static void PrintInstructions()
    {
        Util.ClearScreen();
        Console.WriteLine("Enter a number to check if it is positive, negative, or zero.");
        Console.WriteLine("Enter 'exit' to quit the programme.");
        Console.WriteLine(Constants.Constants.HorizontalLine);
    }
}