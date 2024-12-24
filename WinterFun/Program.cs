﻿#region

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
            Console.WriteLine("Select one of the following programmes to run:");
            Console.WriteLine();
            PrintProgrammes();
            Console.WriteLine();

            string input = Console.ReadLine() ?? string.Empty;

            if (!TryRunProgramme(input))
            {
                Util.ClearScreen();
                Console.WriteLine("Invalid programme selection");
                Console.WriteLine();
                Thread.Sleep(1000);
            }
        }
    }

    private static bool TryRunProgramme(string input)
    {
        if (!long.TryParse(input, out long programmeId) ||
            !RunnableProgrammes.TryGetValue(programmeId, out var programme))
            return false;

        if (Activator.CreateInstance(programme.ProgrammeType) is not IProgramme programmeInstance) return false;

        Util.ClearScreen();
        programmeInstance.Run();
        Console.WriteLine("Programme executed. Returning to main menu...");
        Thread.Sleep(2000);
        return true;
    }

    private static void PrintProgrammes()
    {
        foreach (var (id, info) in RunnableProgrammes) Console.WriteLine($"{id}: {info.Description}");
    }
}