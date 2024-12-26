#region

using static WinterFun.Programmes.Util;

#endregion

namespace WinterFun.Programmes;

public class AverageGrades : IProgramme
{
    private const string Instructions = "Enter the grades of students and calculate the average of the grades.\n" +
                                        "When you are done entering the grades, hit enter on a blank line to calculate the average.";

    public void Run()
    {
        while (true)
        {
            PrintInstructions(Instructions);
            WaitUntilKeyPress();
            ListResult listResult = GetGrades();

            if (listResult.IsExit) return;

            List<long> grades = listResult.Elements;
            double average = grades.Average();
            Console.WriteLine("The average of [{0}] is: {1} ({2})", string.Join(", ", grades), Math.Ceiling(average), Math.Round(average, 2));
            WaitUntilKeyPress();
        }
    }

    private ListResult GetGrades()
    {
        List<long> grades = new();
        bool isExit = false;
        int gradeCount = 1;

        while (true)
        {
            ClearScreen();
            if (gradeCount > 1) Console.WriteLine("Current grades [{0}]", string.Join(", ", grades));

            Console.WriteLine("Enter grade {0} of the students: ", gradeCount);
            string input = Console.ReadLine() ?? string.Empty;

            if (input == Constants.Constants.ExitCommand)
            {
                isExit = true;
                break;
            }

            if (string.IsNullOrWhiteSpace(input)) break;

            if (!long.TryParse(input, out long grade)) continue;
            
            if (grade is < 1 or > 5)
            {
                Console.WriteLine("Grade must be between 0 and 5");
                Thread.Sleep(2000);
                continue;
            }

            grades.Add(grade);
            gradeCount++;
        }

        return new ListResult(grades, isExit);
    }
}