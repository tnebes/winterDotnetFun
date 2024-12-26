namespace WinterFun.Programmes;

public static class Util
{
    public static void ClearScreen()
    {
        Console.Clear();
    }

    public static void PrintInstructions(string instructions)
    {
        ClearScreen();
        Console.WriteLine(instructions);
        Console.WriteLine(Constants.Constants.ExitProgrammeInstructions);
        Console.WriteLine(Constants.Constants.HorizontalLine);
    }

    public static void WaitUntilKeyPress()
    {
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    public sealed record ListResult(List<long> Elements, bool IsExit);
}