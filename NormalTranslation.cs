using System.Net.Security;

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
                goto default;
            }
            case 2:
            {
                GetCustomUserTranslation(active);
                goto default;
            }

            default:
            {
                Console.WriteLine(active["options"]);
                Console.WriteLine(active["option1"]);
                Console.WriteLine(active["option2"]);
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
        //idfk if ts works, goal was to be able to press esc and then it would bring you back to the main menu
        // it works but only in external console because rider doing rider stuffs
        // also just causes program to exit not return to menu
        var input = Console.ReadKey();
        while (input.Key != ConsoleKey.Escape)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(active["keyPlease"]);
            Console.WriteLine(active["leave"]);
            Console.ForegroundColor = ConsoleColor.White;
            var userKey = Console.ReadLine();
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
}