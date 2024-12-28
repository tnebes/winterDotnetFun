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
                    "Rectangle area calculation",
                    "Calculate the area of a rectangle")
            },
            {
                2,
                new ProgrammeInfo(typeof(PositiveNegativeZero),
                    "Positive, negative or zero",
                    "Check if a number is positive, negative or zero")
            },
            {
                3,
                new ProgrammeInfo(typeof(SumOfArrayElements),
                    "Sum of array elements",
                    "Calculate the sum of the elements of an array")
            },
            {
                4,
                new ProgrammeInfo(typeof(AverageGrades),
                    "Average grades",
                    "Calculate the average of the grades of students")
            },
            {
                5,
                new ProgrammeInfo(typeof(FibonacciSequence),
                    "Fibonacci sequence",
                    "Calculate the Fibonacci sequence up to a given number")
            },
            {
                6,
                new ProgrammeInfo(typeof(ReverseString),
                    "Reverse string",
                    "Reverse a given string")
            },
            {
                7,
                new ProgrammeInfo(typeof(VowelCounter),
                    "Vowel counter",
                    "Count the number of vowels in a given string")
            },
            {
                8,
                new ProgrammeInfo(typeof(TemperatureConversion),
                    "Temperature conversion",
                    "Convert a temperature between Celsius and Fahrenheit")
            },
            {
                9,
                new ProgrammeInfo(typeof(ArraySort),
                    "Sort array",
                    "Sort an array of integers in ascending order")
            },
            {
                10,
                new ProgrammeInfo(typeof(Calculator),
                    "Calculator",
                    "Perform basic arithmetic operations")
            },
            {
                11,
                new ProgrammeInfo(typeof(PasswordGenerator),
                    "Password generator",
                    "Generate a password of a given length")
            }
        }.ToImmutableDictionary();

    public static readonly string ExitCommand = "exit";
    public static readonly string InvalidInputMessage = "Invalid input. Please try again.";
    public static readonly string ExitProgrammeInstructions = "Enter 'exit' to quit the programme.";
    public static readonly string HorizontalLine = "-".PadRight(49, '-');
    public static readonly string StrongHorizontalLine = "=".PadRight(49, '=');

    public static class Characters
    {
        public const string UpperCase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public const string LowerCase = "abcdefghijklmnopqrstuvwxyz";
        public const string Numbers = "0123456789";
        public const string Punctuation = "!@#$%^&*()_+-=[]{}|;:,.<>?";
    }

    public static class ConsoleKeys
    {
        public const ConsoleKey Generate = ConsoleKey.Enter;
        public const ConsoleKey ToggleOption = ConsoleKey.Spacebar;
        public const ConsoleKey Exit = ConsoleKey.Q;
        public const ConsoleKey SaveToFile = ConsoleKey.S;
        public const ConsoleKey CopyToClipboard = ConsoleKey.C;
    }
}