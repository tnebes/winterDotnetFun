#region

using static WinterFun.Constants.Constants;

#endregion

namespace WinterFun.Programmes;

public sealed class RectangleArea : IProgramme
{
    private const string Instructions = "Enter the length and width of the rectangle to calculate its area.";

    public void Run()
    {
        PrintInstructions();
        while (true)
        {
            DimensionResult lengthResult = TryGetDimension("length");
            if (lengthResult.IsValid)
            {
                DimensionResult widthResult = TryGetDimension("width");
                if (widthResult.IsValid)
                {
                    Console.WriteLine($"The area of the rectangle is {lengthResult.Dimension * widthResult.Dimension}");
                    Console.WriteLine(HorizontalLine);
                }

                if (widthResult.ShouldExit)
                    return;
            }

            if (lengthResult.ShouldExit)
                return;
        }
    }

    private static DimensionResult TryGetDimension(string dimensionName)
    {
        Console.Write($"Enter the {dimensionName}: ");
        string input = Console.ReadLine() ?? string.Empty;

        if (input == ExitCommand) return new DimensionResult(false, 0, true);

        if (!long.TryParse(input, out long dimension))
        {
            Console.WriteLine(InvalidInputMessage);
            return new DimensionResult(false, 0, false);
        }

        if (dimension <= 0)
        {
            Console.WriteLine("The dimension must be greater than 0.");
            return new DimensionResult(false, 0, false);
        }

        return new DimensionResult(true, dimension, false);
    }

    private static void PrintInstructions()
    {
        Util.PrintInstructions(Instructions);
    }

    private sealed record DimensionResult(bool IsValid, long Dimension, bool ShouldExit);
}