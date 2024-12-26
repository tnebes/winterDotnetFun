using System.Runtime.ExceptionServices;

namespace WinterFun.Programmes;

public class SumOfArrayElements : IProgramme
{
    private static readonly string Instructions =
        "Enter the elements of an array and calculate the sum of the elements.\n" +
        "When you are done entering the elements, hit enter on a blank line to calculate the sum.";

    public void Run()
    {
        while (true)
        {
            Util.PrintInstructions(Instructions);
            ListResult listResult = GetElements();

            if (listResult.IsExit)
            {
                return;
            }

            List<long> elements = listResult.Elements;
            long sum = Sum(elements); // alternatively, elements.Sum();
            Console.WriteLine("The sum of [{0}] is: {1}", string.Join(", ", elements), sum);
            Thread.Sleep(2000);
        }
    }

    private static ListResult GetElements()
    {
        List<long> elements = new();
        bool isExit = false;
        int elementCount = 1;

        while (true)
        {
            if (elementCount > 1) Console.WriteLine("Current numbers [{0}]", string.Join(", ", elements));

            Console.WriteLine("Enter element {0} of the array: ", elementCount);
            string input = Console.ReadLine() ?? string.Empty;

            if (input == Constants.Constants.ExitCommand)
            {
                isExit = true;
                break;
            }

            if (string.IsNullOrWhiteSpace(input)) break;

            if (!long.TryParse(input, out long element)) continue;

            elements.Add(element);
            elementCount++;
        }

        return new ListResult(elements, isExit);
    }

    private static long Sum(IEnumerable<long> elements)
    {
        long sum = 0;

        foreach (long element in elements)
        {
            sum += element;
        }

        return sum;
    }

    private sealed record ListResult(List<long> Elements, bool IsExit);
}