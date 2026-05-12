namespace TranslatingStuffs;

class Program
{
    static void Main()
    {
        
        Console.WriteLine("Please choose a Language. Bitte wähle eine Sprache. (de/en)");
        var language = Console.ReadLine();
        
        Console.WriteLine();

        var active = language == "en" ? DictionaryProvider.EnDic : DictionaryProvider.DeDic;
        Console.WriteLine(active["welcome"]);
        Console.WriteLine(active["selectedLanguage"]);
        
        
        Console.WriteLine(active["userState"]);
        Console.WriteLine(active["rate"]);
    }
}