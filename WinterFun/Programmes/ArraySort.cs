namespace WinterFun.Programmes;

public sealed class ArraySort : IProgramme
{
    private const string Instructions = "Enter the sorting algorithm (bubble, selection, insertion, merge) " +
                                        "and then enter the array to sort.";

    private const int Delay = 50;

    public void Run()
    {
        while (true)
        {
            Util.ClearScreen();
            Util.PrintInstructions(Instructions);

            Console.WriteLine("Enter the sorting algorithm: ");
            string algorithm = Console.ReadLine() ?? string.Empty;

            if (algorithm == Constants.Constants.ExitCommand) return;

            Console.WriteLine("Enter the array to sort: ");
            Util.ListResult listResult = GetArray();

            if (listResult.IsExit) return;

            List<long> array = listResult.Elements;

            (List<long> sortedArray, int steps) = SortArray(array, algorithm);
            Console.WriteLine(Constants.Constants.StrongHorizontalLine);
            Console.WriteLine($"Original array: [{string.Join(", ", array)}]");
            Console.WriteLine($"Sorted array: [{string.Join(", ", sortedArray)}]");
            Console.WriteLine($"Steps taken: {steps}");
            Util.WaitUntilKeyPress();
        }
    }

    private (List<long>, int) SortArray(List<long> array, string algorithm)
    {
        if (algorithm.ToLower().StartsWith('b')) return BubbleSort(array);

        if (algorithm.ToLower().StartsWith('s')) return SelectionSort(array);

        if (algorithm.ToLower().StartsWith('i')) return InsertionSort(array);

        if (algorithm.ToLower().StartsWith('m')) return MergeSort(array);

        Console.WriteLine("Invalid sorting algorithm");
        Thread.Sleep(2000);
        return (array, 0);
    }

    private (List<long>, int) MergeSort(List<long> array)
    {
        int steps = 0;
        MergeSortHelper(array, 0, array.Count - 1, ref steps);
        return (array, steps);
    }

    private void MergeSortHelper(List<long> array, int left, int right, ref int steps)
    {
        if (left < right)
        {
            int mid = (left + right) / 2;
            MergeSortHelper(array, left, mid, ref steps);
            MergeSortHelper(array, mid + 1, right, ref steps);
            Merge(array, left, mid, right, ref steps);
        }
    }

    private void Merge(List<long> array, int left, int mid, int right, ref int steps)
    {
        int n1 = mid - left + 1;
        int n2 = right - mid;
        List<long> leftArray = new();
        List<long> rightArray = new();

        for (int i = 0; i < n1; i++)
            leftArray.Add(array[left + i]);
        for (int j = 0; j < n2; j++)
            rightArray.Add(array[mid + 1 + j]);

        int leftIndex = 0, rightIndex = 0, mergeIndex = left;

        while (leftIndex < n1 && rightIndex < n2)
        {
            steps++;
            if (leftArray[leftIndex] <= rightArray[rightIndex])
            {
                array[mergeIndex] = leftArray[leftIndex];
                leftIndex++;
            }
            else
            {
                array[mergeIndex] = rightArray[rightIndex];
                rightIndex++;
            }

            mergeIndex++;
            Console.WriteLine($"Current array: [{string.Join(", ", array)}]");
            Thread.Sleep(Delay);
        }

        while (leftIndex < n1)
        {
            steps++;
            array[mergeIndex] = leftArray[leftIndex];
            leftIndex++;
            mergeIndex++;
            Console.WriteLine($"Current array: [{string.Join(", ", array)}]");
            Thread.Sleep(Delay);
        }

        while (rightIndex < n2)
        {
            steps++;
            array[mergeIndex] = rightArray[rightIndex];
            rightIndex++;
            mergeIndex++;
            Console.WriteLine($"Current array: [{string.Join(", ", array)}]");
            Thread.Sleep(Delay);
        }
    }

    private (List<long>, int) InsertionSort(List<long> array)
    {
        int steps = 0;
        for (int i = 1; i < array.Count; i++)
        {
            long key = array[i];
            int j = i - 1;

            while (j >= 0 && array[j] > key)
            {
                steps++;
                array[j + 1] = array[j];
                j--;
            }

            array[j + 1] = key;
            Console.WriteLine($"Current array: [{string.Join(", ", array)}]");
            Thread.Sleep(Delay);
        }

        return (array, steps);
    }

    private (List<long>, int) SelectionSort(List<long> array)
    {
        int steps = 0;
        for (int i = 0; i < array.Count - 1; i++)
        {
            int minIndex = i;
            for (int j = i + 1; j < array.Count; j++)
            {
                steps++;
                if (array[j] < array[minIndex]) minIndex = j;
            }

            if (minIndex != i)
            {
                (array[i], array[minIndex]) = (array[minIndex], array[i]);
                Console.WriteLine($"Current array: [{string.Join(", ", array)}]");
                Thread.Sleep(Delay);
            }
        }

        return (array, steps);
    }

    private (List<long>, int) BubbleSort(List<long> array)
    {
        int steps = 0;
        for (int i = 0; i < array.Count - 1; i++)
        {
            bool swapped = false;
            for (int j = 0; j < array.Count - i - 1; j++)
            {
                steps++;
                if (array[j] > array[j + 1])
                {
                    (array[j], array[j + 1]) = (array[j + 1], array[j]);
                    swapped = true;
                    Console.WriteLine($"Current array: [{string.Join(", ", array)}]");
                    Thread.Sleep(Delay);
                }
            }

            if (!swapped) break;
        }

        return (array, steps);
    }

    private static Util.ListResult GetArray()
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
}