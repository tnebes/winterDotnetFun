namespace WinterFun.Programmes;

public sealed class VowelCounter : IProgramme
{
    private const string Instructions = "Enter a string to count the number of vowels.";
    private static readonly char[] Vowels = new[] { '\u0061', '\u0065', '\u0069', '\u006f', '\u0075' };

    public void Run()
    {
        while (true)
        {
            Util.ClearScreen();
            Util.PrintInstructions(Instructions);
            Console.WriteLine("Enter a string: ");
            string input = Console.ReadLine() ?? string.Empty;

            if (input == Constants.Constants.ExitCommand) return;

            List<char> foundVowels = CountVowels(input);
            Util.ClearScreen();
            Console.WriteLine("String: {0}\nVowels: [{1}]\nCount: {2}", input, string.Join(", ", foundVowels),
                foundVowels.Count);
            Util.WaitUntilKeyPress();
        }
    }

    private static List<char> CountVowels(string input)
    {
        return input.Where(character => Vowels.Contains(char.ToLower(character))).ToList();
    }
}