namespace TranslatingStuffs;

public class NormalTranslation(string language)
{
    private readonly DictionaryProvider provider = new(language);

    public void Execute()
    {
        Console.WriteLine(provider.GetText("welcome"));
        Console.WriteLine(provider.GetText("selectedLanguage"));

        var userOption = ListAndSelectOptions();

        while (true)
        {
            switch (userOption)
            {
                case 1:
                {
                    Console.WriteLine(provider.GetText("welcome"));
                    Console.WriteLine(provider.GetText("selectedLanguage"));
                    Console.WriteLine(provider.GetText("userState"));
                    Console.WriteLine(provider.GetText("rate"));
                    goto default;
                }
                case 2:
                {
                    CustomUserTranslation();
                    goto default;
                }

                default:
                {
                    userOption = ListAndSelectOptions();
                    break;
                }
            }
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
            Console.WriteLine(provider.GetText("optionsPlease"));
        }
    }

    private void CustomUserTranslation()
    {
        do
        {
            var userKey = GetCustomUserTranslation();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            //Console.WriteLine(DictionaryProvider.DeDic[userKey]);
            //Console.WriteLine(DictionaryProvider.EnDic[userKey]);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine(provider.GetText("leaveInfo"), provider.GetText("continueInfo"));
        } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
    }

    private string GetCustomUserTranslation()
    {
        PrintKeyPlease();
        while (true)
        {
            var userKey = Console.ReadLine();
            if (!string.IsNullOrEmpty(userKey) && provider.ContainsKeyPair(userKey))
            {
                return userKey;
            }
            PrintAskValidKey();
        }
    }

    private int ListAndSelectOptions()
    {
        Console.WriteLine();
        Console.WriteLine(provider.GetText("options"));
        Console.WriteLine(provider.GetText("option1"));
        Console.WriteLine(provider.GetText("option2"));
        Console.WriteLine();
        return GetUserOption();
    }

    private void PrintKeyPlease()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(provider.GetText("keyPlease"));
        Console.ForegroundColor = ConsoleColor.White;
    }

    private void PrintAskValidKey()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(provider.GetText("askValidKey"));
        Console.ForegroundColor = ConsoleColor.White;
    }
}
