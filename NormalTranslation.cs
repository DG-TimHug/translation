namespace TranslatingStuffs;

public static class NormalTranslation
{
    public static void Execute(string language)
    {
        var active = language == "en" ? DictionaryProvider.EnDic : DictionaryProvider.DeDic;
        Console.WriteLine(active["welcome"]);
        Console.WriteLine(active["selectedLanguage"]);
        
        Console.WriteLine(active["options"]);
        Console.WriteLine(active["option1"]);
        Console.WriteLine(active["option2"]);
        var userOption = GetUserOption(active);
        switch (userOption)
        {
            case 1:
            {
                Console.WriteLine(active["welcome"]);
                Console.WriteLine(active["selectedLanguage"]);
                Console.WriteLine(active["userState"]);
                Console.WriteLine(active["rate"]);
                break;
            }
            case 2:
            {
                GetCustomUserTranslation(active);
                break;
            }
        }
    }
    
    private static int GetUserOption(Dictionary<string,string> active)
    {
        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out var userOption) && userOption > 0)
            {
                return userOption;
            }
            Console.WriteLine(active["optionsPlease"]);
        }
    }
    
    private static void GetCustomUserTranslation(Dictionary<string,string> active)
    {
        while (true)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(active["keyPlease"]);
            Console.ForegroundColor = ConsoleColor.White;
            var userKey = Console.ReadLine();
            if (!string.IsNullOrEmpty(userKey))
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(active[userKey]);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
            }
        }
    }
}