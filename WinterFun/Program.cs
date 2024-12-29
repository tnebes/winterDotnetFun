#region

using WinterFun.Programmes;
using static WinterFun.Constants.Constants;

#endregion

namespace WinterFun;

public static class Program
{
    public static void Main()
    {
        while (true)
        {
            Util.ClearScreen();
            Console.WriteLine(
                "Select one of the following programmes to run\nor type 'exit' to quit the application: ");
            Console.WriteLine(StrongHorizontalLine);
            PrintProgrammes();
            Console.WriteLine(StrongHorizontalLine);

            string input = Console.ReadLine() ?? string.Empty;

            if (input == ExitCommand)
            {
                Util.ClearScreen();
                Console.WriteLine("Exiting application...");
                Thread.Sleep(1000);
                Environment.Exit(0);
            }

            if (!long.TryParse(input, out long id) || !RunnableProgrammes.TryGetValue(id, out ProgrammeInfo? programme))
            {
                Util.ClearScreen();
                Console.WriteLine("Invalid programme selection\n");
                Thread.Sleep(1000);
                continue;
            }

            if (Activator.CreateInstance(programme.ProgrammeType) is IProgramme instance)
            {
                Util.ClearScreen();
                instance.Run();
                Console.WriteLine("Programme executed. Returning to main menu...");
                Thread.Sleep(2000);
            }
        }
    }

    private static void PrintProgrammes()
    {
        int padding = RunnableProgrammes.Max(p => p.Value.Name.Length) + 4;
        foreach ((long id, ProgrammeInfo info) in RunnableProgrammes)
            Console.WriteLine($"{id,2}: {info.Name}".PadRight(padding) + $" - {info.Description}");
    }
}