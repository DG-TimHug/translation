using System.Net.Security;

namespace TranslatingStuffs;

public static class NormalTranslation
{
    public static void Execute(string language)
    {
        var active = language == "en" ? DictionaryProvider.EnDic : DictionaryProvider.DeDic;
        Console.WriteLine(active["welcome"]);
        Console.WriteLine(active["selectedLanguage"]);
        
        ListOption(active);
        
        Console.WriteLine();
        var userOption = GetUserOption(active);
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
                ListOption(active);
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
    
    private static void CustomUserTranslation(Dictionary<string,string> active)
    {
        // idfk if ts works, goal was to be able to press esc and then it would bring you back to the main menu
        // it works but only in external console because rider doing rider stuffs
        // also just causes program to exit not return to menu
        //var input = Console.ReadKey();
        while (true)
        {
            var userKey = GetCustomUserTranslation(active);
            if (!string.IsNullOrEmpty(userKey))
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(active[userKey]);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
            }
        }
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

    private static void ListOption(Dictionary<string,string> active)
    {
        Console.WriteLine(active["options"]);
        Console.WriteLine(active["option1"]);
        Console.WriteLine(active["option2"]);
    }

    private static void KeyPlease(Dictionary<string, string> active)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(active["keyPlease"]);
        Console.ForegroundColor = ConsoleColor.White;
    }
}