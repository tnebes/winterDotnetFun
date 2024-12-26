namespace WinterFun.Programmes;

public sealed class SumOfArrayElements : IProgramme
{
    private const string Instructions =
        "Enter the elements of an array and calculate the sum of the elements.\n" +
        "When you are done entering the elements, hit enter on a blank line to calculate the sum.";

    public void Run()
    {
        while (true)
        {
            Util.PrintInstructions(Instructions);
            Util.WaitUntilKeyPress();
            Util.ListResult listResult = GetElements();

            if (listResult.IsExit) return;

            List<long> elements = listResult.Elements;
            long sum = Sum(elements); // alternatively, elements.Sum();
            Console.WriteLine("The sum of [{0}] is: {1}", string.Join(", ", elements), sum);
            Util.WaitUntilKeyPress();
        }
    }

    private static Util.ListResult GetElements()
    {
        List<long> elements = new();
        bool isExit = false;
        int elementCount = 1;

        while (true)
        {
            Util.ClearScreen();
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

        return new Util.ListResult(elements, isExit);
    }

    private static long Sum(IEnumerable<long> elements)
    {
        long sum = 0;

        foreach (long element in elements) sum += element;

        return sum;
    }
}