#region

using System.Collections.Immutable;
using WinterFun.Programmes;

#endregion

namespace WinterFun.Constants;

public static class Constants
{
    public static readonly ImmutableDictionary<long, ProgrammeInfo> RunnableProgrammes =
        new Dictionary<long, ProgrammeInfo>
        {
            {
                1,
                new ProgrammeInfo(typeof(RectangleArea),
                    "Rectangle area calculation - Calculate the area of a rectangle")
            },
            {
                2,
                new ProgrammeInfo(typeof(PositiveNegativeZero),
                    "Positive, negative or zero - Check if a number is positive, negative or zero")
            },
            {
                3,
                new ProgrammeInfo(typeof(SumOfArrayElements),
                    "Sum of array elements - Calculate the sum of the elements of an array")
            },
            {
                4,
                new ProgrammeInfo(typeof(AverageGrades),
                    "Average grades - Calculate the average of the grades of students")
            },
            {
                5,
                new ProgrammeInfo(typeof(FibonacciSequence),
                    "Fibonacci sequence - Calculate the Fibonacci sequence up to a given number")
            }
        }.ToImmutableDictionary();

    public static readonly string ExitCommand = "exit";
    public static readonly string InvalidInputMessage = "Invalid input. Please try again.";
    public static readonly string ExitProgrammeInstructions = "Enter 'exit' to quit the programme.";
    public static readonly string HorizontalLine = "-".PadRight(49, '-');
    public static readonly string StrongHorizontalLine = "=".PadRight(49, '=');
}