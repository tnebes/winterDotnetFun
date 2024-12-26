namespace WinterFun.Programmes;

public sealed class ReverseString : IProgramme
{
    private const string Instructions = "Enter a string to reverse.";

    public void Run()
    {
        while (true)
        {
            Util.ClearScreen();
            Util.PrintInstructions(Instructions);
            Console.WriteLine("Enter a string: ");
            string input = Console.ReadLine() ?? string.Empty;

            if (input == Constants.Constants.ExitCommand) return;

            char[] characters = input.ToCharArray();
            Array.Reverse(characters);
            string reversed = new string(characters);

            Console.WriteLine("The reversed string is: {0}", reversed);
            Util.WaitUntilKeyPress();
        }
    }
}