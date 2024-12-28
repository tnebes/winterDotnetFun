#region

using TextCopy;
using static WinterFun.Constants.Constants.Characters;
using static WinterFun.Constants.Constants.ConsoleKeys;

#endregion

namespace WinterFun.Programmes;

public sealed class PasswordGenerator : IProgramme
{
    private readonly List<string> _generatedPasswords = new();
    private int _currentOption;
    private string[] _menuItems = [];

    public void Run()
    {
        PasswordOptions options = new PasswordOptions(
            12,
            true,
            true,
            true,
            false,
            false,
            false,
            false,
            false,
            true,
            1
        );

        while (true)
        {
            Console.Clear();
            DisplayControls();
            DisplayMenu(options);
            DisplayGeneratedPasswords();

            ConsoleKeyInfo key = Console.ReadKey(true);

            if (key.Key == Exit) break;

            options = HandleInput(key, options);

            if (key.Key == Generate)
            {
                _generatedPasswords.Clear();
                _generatedPasswords.AddRange(GeneratePasswords(options));
            }
            else if (key.Key == SaveToFile)
            {
                File.WriteAllLines("out.txt", _generatedPasswords);
                Util.ClearScreen();
                Console.WriteLine("Passwords saved to out.txt");
                Thread.Sleep(2000);
            }
            else if (key.Key == CopyToClipboard && _generatedPasswords.Count > 0)
            {
                ClipboardService.SetText(string.Join(Environment.NewLine, _generatedPasswords));
                Util.ClearScreen();
                Console.WriteLine("Passwords copied to clipboard");
                Thread.Sleep(2000);
            }
        }
    }

    private void DisplayMenu(PasswordOptions options)
    {
        _menuItems = new[]
        {
            $"Password Length: {options.Length}",
            $"Use Uppercase Letters: {options.UseUpperCase}",
            $"Use Lowercase Letters: {options.UseLowerCase}",
            $"Use Numbers: {options.UseNumbers}",
            $"Use Punctuation: {options.UsePunctuation}",
            $"Start with Number: {options.StartWithNumber}",
            $"Start with Punctuation: {options.StartWithPunctuation}",
            $"End with Number: {options.EndWithNumber}",
            $"End with Punctuation: {options.EndWithPunctuation}",
            $"Allow Repeating Characters: {options.AllowRepeating}",
            $"Number of Passwords: {options.Count}\n",
            "Generate Passwords"
        };

        for (int i = 0; i < _menuItems.Length; i++)
        {
            if (i == _currentOption)
                Console.Write("> ");
            else
                Console.Write("  ");

            Console.WriteLine(_menuItems[i]);
        }
    }

    private void DisplayGeneratedPasswords()
    {
        if (_generatedPasswords.Count == 0) return;

        Console.WriteLine("\nGenerated Passwords:");
        foreach (string password in _generatedPasswords) Console.WriteLine(password);
    }

    private void DisplayControls()
    {
        Console.WriteLine(Constants.Constants.StrongHorizontalLine);
        Console.WriteLine(
            $"Controls: ↑↓ Navigate | {ToggleOption} Toggle/Modify | {Generate} Generate | {CopyToClipboard} Copy | {SaveToFile} Save | {Exit} Exit");
        Console.WriteLine(Constants.Constants.StrongHorizontalLine);
    }

    private PasswordOptions HandleInput(ConsoleKeyInfo key, PasswordOptions options)
    {
        int menuItemsLength = _menuItems.Length;
        switch (key.Key)
        {
            case ConsoleKey.UpArrow:
                _currentOption = (_currentOption - 1 + menuItemsLength) % menuItemsLength;
                break;
            case ConsoleKey.DownArrow:
                _currentOption = (_currentOption + 1) % menuItemsLength;
                break;
            case ConsoleKey.Spacebar:
                return ModifyOption(options);
        }

        return options;
    }

    private PasswordOptions ModifyOption(PasswordOptions options)
    {
        return _currentOption switch
        {
            0 => options with { Length = GetNumericInput("Enter password length: ", options.Length) },
            1 => options with { UseUpperCase = !options.UseUpperCase },
            2 => options with { UseLowerCase = !options.UseLowerCase },
            3 => options with { UseNumbers = !options.UseNumbers },
            4 => options with { UsePunctuation = !options.UsePunctuation },
            5 => options with { StartWithNumber = !options.StartWithNumber },
            6 => options with { StartWithPunctuation = !options.StartWithPunctuation },
            7 => options with { EndWithNumber = !options.EndWithNumber },
            8 => options with { EndWithPunctuation = !options.EndWithPunctuation },
            9 => options with { AllowRepeating = !options.AllowRepeating },
            10 => options with { Count = GetNumericInput("Enter number of passwords: ", options.Count) },
            _ => options
        };
    }

    private int GetNumericInput(string prompt, int currentValue)
    {
        Console.Write(prompt);
        if (int.TryParse(Console.ReadLine(), out int value))
            return Math.Max(value, 1);
        return currentValue;
    }

    private IEnumerable<string> GeneratePasswords(PasswordOptions options)
    {
        Random random = new Random();
        List<string> passwords = new();

        for (int i = 0; i < options.Count; i++)
        {
            string password = GeneratePassword(options, random);
            passwords.Add(password);
        }

        return passwords;
    }

    private string GeneratePassword(PasswordOptions options, Random random)
    {
        string availableChars = GetAvailableCharacters(options);
        if (availableChars.Length == 0) return string.Empty;

        char[] password = new char[options.Length];

        if (options.StartWithNumber && options.UseNumbers)
            password[0] = Numbers[random.Next(Numbers.Length)];
        else if (options.StartWithPunctuation && options.UsePunctuation)
            password[0] = Punctuation[random.Next(Punctuation.Length)];
        else
            password[0] = availableChars[random.Next(availableChars.Length)];

        if (options.EndWithNumber && options.UseNumbers)
            password[^1] = Numbers[random.Next(Numbers.Length)];
        else if (options.EndWithPunctuation && options.UsePunctuation)
            password[^1] = Punctuation[random.Next(Punctuation.Length)];
        else
            password[^1] = availableChars[random.Next(availableChars.Length)];

        for (int i = 1; i < options.Length - 1; i++)
        {
            char nextChar;
            do
            {
                nextChar = availableChars[random.Next(availableChars.Length)];
            } while (!options.AllowRepeating && password.Contains(nextChar));

            password[i] = nextChar;
        }

        return new string(password);
    }

    private string GetAvailableCharacters(PasswordOptions options)
    {
        string chars = string.Empty;
        if (options.UseUpperCase) chars += UpperCase;
        if (options.UseLowerCase) chars += LowerCase;
        if (options.UseNumbers) chars += Numbers;
        if (options.UsePunctuation) chars += Punctuation;
        return chars;
    }

    private readonly record struct PasswordOptions(
        int Length,
        bool UseUpperCase,
        bool UseLowerCase,
        bool UseNumbers,
        bool UsePunctuation,
        bool StartWithNumber,
        bool StartWithPunctuation,
        bool EndWithNumber,
        bool EndWithPunctuation,
        bool AllowRepeating,
        int Count
    );
}