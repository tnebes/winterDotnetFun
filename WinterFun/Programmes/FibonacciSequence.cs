#region

using System.Numerics;

#endregion

namespace WinterFun.Programmes;

public sealed class FibonacciSequence : IProgramme
{
    private const string Instructions = "Enter the number of terms in the Fibonacci sequence to generate.";

    public void Run()
    {
        while (true)
        {
            Util.PrintInstructions(Instructions);

            string input = Console.ReadLine() ?? string.Empty;

            if (input == Constants.Constants.ExitCommand) return;

            if (!int.TryParse(input, out int terms))
            {
                Console.WriteLine("Invalid input. Please try again.");
                Thread.Sleep(1000);
                continue;
            }

            if (terms < 1)
            {
                Console.WriteLine("The number of terms must be greater than 0.");
                Thread.Sleep(1000);
                continue;
            }

            List<BigInteger> sequence = GenerateFibonacciSequence(terms);
            Console.WriteLine("The Fibonacci sequence with {0} terms is: {1}", terms, string.Join(", ", sequence));
            Util.WaitUntilKeyPress();
        }
    }

    private List<BigInteger> GenerateFibonacciSequence(int result)
    {
        List<BigInteger> sequence = new() { 0, 1 };
        for (int i = 2; i < result; i++) sequence.Add(sequence[i - 1] + sequence[i - 2]);

        return sequence;
    }
}