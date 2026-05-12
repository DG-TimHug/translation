namespace TranslatingStuffs;

public static class FancyTranslation
{
    public static void Execute(string language)
    {
        var active = language == "en" ? DictionaryProvider.EnDic : DictionaryProvider.DeDic;
        Console.WriteLine(active["welcome"]);
        Console.WriteLine(active["selectedLanguage"]);
        
        Console.WriteLine(active["options"]);
        Console.WriteLine(active["option1"]);
        Console.WriteLine(active["option2"]);
        int.TryParse(Console.ReadLine(), out var UserOption);
        
        
        /*
        Console.WriteLine(active["userState"]);
        Console.WriteLine(active["rate"]);

        */
    }
}