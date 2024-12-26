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
            }
        }.ToImmutableDictionary();

    public static readonly string ExitCommand = "exit";
    public static readonly string InvalidInputMessage = "Invalid input. Please try again.";
    public static readonly string HorizontalLine = "-".PadRight(49, '-');
    public static readonly string StrongHorizontalLine = "=".PadRight(49, '=');
}