using Spectre.Console;

namespace TranslatingStuffs;

public static class FancyTranslation
{
    public static void Execute(string language)
    {
        var active = language == "en" ? DictionaryProvider.EnDic : DictionaryProvider.DeDic;
        AnsiConsole.MarkupLine($"[teal]{active["welcome"]}[/]");
        Console.WriteLine(active["selectedLanguage"]);
        var option1 = ("Option 1", active[option1]);
        
        var userOption = ListAndSelectOptions(active);
        
        while (true)
        {
            switch (userOption)
            {
                case option1.Item1:
                {
                    Console.WriteLine(active["welcome"]);
                    Console.WriteLine(active["selectedLanguage"]);
                    Console.WriteLine(active["userState"]);
                    Console.WriteLine(active["rate"]);
                    goto default;
                }
                case option2:
                {
                    //CustomUserTranslation(active);
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

    private static string ListAndSelectOptions(Dictionary<string, string> active)
    {

        var choice = AnsiConsole.Prompt(
            new SelectionPrompt<(string Key, string Display)>()
                .Title(active["options"])
                .UseConverter(option1 => option1.Display)
                .UseConverter(option2 => option2.Display)
                .AddChoices<>(option1.Key, "Option 2"));

        AnsiConsole.MarkupLine($"Deploying to [blue]{choice}[/]");
        return choice;
    }
    
    // DO fancy shit. 
}