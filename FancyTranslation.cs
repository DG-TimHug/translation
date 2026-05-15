using Spectre.Console;

namespace TranslatingStuffs;

public static class FancyTranslation
{
    public static void Execute(string language)
    {
        var active = language == "en" ? DictionaryProvider.EnDic : DictionaryProvider.DeDic;
        AnsiConsole.MarkupLine($"[teal]{active["welcome"]}[/]");
        AnsiConsole.WriteLine(active["selectedLanguage"]);
        
        var userOption = ListAndSelectOptions(active);
        
        while (true)
        {
            switch (userOption.Key)
            {
                case "option1":
                {
                    AnsiConsole.WriteLine(active["welcome"]);
                    AnsiConsole.WriteLine(active["selectedLanguage"]);
                    AnsiConsole.WriteLine(active["userState"]);
                    AnsiConsole.WriteLine(active["rate"]);
                    goto default;
                }
                case "option2":
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

    private static (string Key, string display) ListAndSelectOptions(Dictionary<string, string> active)
    {
        var option1 = ("option1", active["option1"]);
        var option2 = ("option2", active["option2"]);
        AnsiConsole.WriteLine();
        var choice = AnsiConsole.Prompt(
            new SelectionPrompt<(string Key, string Display)>()
                .Title(active["options"])
                .UseConverter(option => option.Display)
                .AddChoices(option1, option2));

        AnsiConsole.MarkupLine($"Sending you to [blue]{choice.Item2}[/]!");
        AnsiConsole.WriteLine();
        return choice;
    }
    
    // DO fancy shit. 
}