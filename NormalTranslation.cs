namespace TranslatingStuffs;

public class NormalTranslation(string language) : ITranslator
{
    private readonly Translator translator = new(language);

    public void Execute()
    {
        Console.WriteLine(translator["welcome"]);
        Console.WriteLine(translator["selectedLanguage"]);

        var userOption = ListAndSelectOptions();

        while (true)
        {
            switch (userOption)
            {
                case 1:
                {
                    Console.WriteLine(translator["welcome"]);
                    Console.WriteLine(translator["selectedLanguage"]);
                    Console.WriteLine(translator["userState"]);
                    Console.WriteLine(translator["rate"]);
                    break;
                }
                case 2:
                {
                    CustomUserTranslation();
                    break;
                }
            }

            userOption = ListAndSelectOptions();
        }
    }

    private int GetUserOption()
    {
        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out var userOption) && userOption is 1 or 2)
            {
                return userOption;
            }
            Console.WriteLine(translator["optionsPlease"]);
        }
    }

    private void CustomUserTranslation()
    {
        do
        {
            var userKey = GetCustomUserTranslation();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            PrintCustomUserTranslation(userKey);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine(translator["leaveInfo"], translator["continueInfo"]);
        } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
    }

    private string GetCustomUserTranslation()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(translator["keyPlease"]);
        Console.ForegroundColor = ConsoleColor.White;

        while (true)
        {
            var userKey = Console.ReadLine();
            if (!string.IsNullOrEmpty(userKey) && translator.ContainsKeyPair(userKey))
            {
                return userKey;
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(translator["askValidKey"]);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }

    private int ListAndSelectOptions()
    {
        Console.WriteLine();
        Console.WriteLine(translator["options"]);
        Console.WriteLine(translator["optionDefaultTranslations"]);
        Console.WriteLine(translator["optionCustomTranslation"]);
        Console.WriteLine();
        return GetUserOption();
    }

    private void PrintCustomUserTranslation(string userKey)
    {
        Console.WriteLine();

        foreach (var possibleOutputs in translator.GetAllLanguages(userKey))
        {
            Console.WriteLine(possibleOutputs);
        }

        Console.WriteLine();
    }
}
