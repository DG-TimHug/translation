namespace TranslatingStuffs;

class Program
{
    static void Main()
    { 
        var language = GetUserLanguage();

        var version = GetUserPreferredVersion();

        switch (version)
        {
            case "normal":
            {
                NormalTranslation.Execute(language);
                break;
            }
            case "fancy":
            {
                FancyTranslation.Execute(language);
                break;
            }
        }
    }
    
    private static string GetUserLanguage()
    {
        while (true)
        {
            Console.WriteLine("Please choose a Language. Bitte wähle eine Sprache. (de/en)");
            var language = Console.ReadLine();
            if (!string.IsNullOrEmpty(language) && language is "en" or "de")
            {
                return language;
            }
        }
    }
    
    private static string GetUserPreferredVersion()
    {
        while (true)
        {
            Console.WriteLine("Please Choose a verison. Bitte wähle eine Version. (fancy/normal)");
            var preferredVersion = Console.ReadLine();
            if (!string.IsNullOrEmpty(preferredVersion) && preferredVersion is "fancy" or "normal")
            {
                return preferredVersion;
            }
        }
    }
}