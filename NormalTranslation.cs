namespace TranslatingStuffs;

public static class NormalTranslation
{
    public static void Execute(string language)
    {
        var active = language == "en" ? DictionaryProvider.EnDic : DictionaryProvider.DeDic;
        Console.WriteLine(active["welcome"]);
        Console.WriteLine(active["selectedLanguage"]);
        
        var userOption = ListAndSelectOptions(active);

        while (true)
        {
            switch (userOption)
            {
                case 1:
                {
                    Console.WriteLine(active["welcome"]);
                    Console.WriteLine(active["selectedLanguage"]);
                    Console.WriteLine(active["userState"]);
                    Console.WriteLine(active["rate"]);
                    goto default;
                }
                case 2:
                {
                    CustomUserTranslation(active);
                    goto default;
                }

                default:
                {
                    userOption = ListAndSelectOptions(active);
                    break;
                }
            }
        }
    }
    
    private static int GetUserOption(Dictionary<string,string> active)
    {
        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out var userOption) && userOption is 1 or 2)
            {
                return userOption;
            }
            Console.WriteLine(active["optionsPlease"]);
        }
    }
    
    private static void CustomUserTranslation(Dictionary<string,string> active)
    {
        do
        {
            var userKey = GetCustomUserTranslation(active);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(DictionaryProvider.DeDic[userKey]);
            Console.WriteLine(DictionaryProvider.EnDic[userKey]);
            Console.WriteLine(active[userKey]);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine(active["leaveInfo"]);
        } while (Console.ReadKey().Key != ConsoleKey.Escape);
    }

    private static string GetCustomUserTranslation(Dictionary<string, string> active)
    {
        KeyPlease(active);
        while (true)
        {
            var userKey = Console.ReadLine();
            if (!string.IsNullOrEmpty(userKey) && active.ContainsKey(userKey))
            {
                return userKey;
            }
            KeyPlease(active);
        }
    }

    private static int ListAndSelectOptions(Dictionary<string,string> active)
    {
        Console.WriteLine();
        Console.WriteLine(active["options"]);
        Console.WriteLine(active["option1"]);
        Console.WriteLine(active["option2"]);
        Console.WriteLine();
        return GetUserOption(active);
    }

    private static void KeyPlease(Dictionary<string, string> active)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(active["keyPlease"]);
        Console.ForegroundColor = ConsoleColor.White;
    }
}