namespace TranslatingStuffs;

class Program
{
    static void Main()
    {
        Console.WriteLine("Please choose a Language. Bitte wähle eine Sprache. (de/en)");
        var language = Console.ReadLine();
        
        Console.WriteLine("Please Choose a verison. Bitte wähle eine Version. (fancy/normal)");
        var version = Console.ReadLine();

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
}