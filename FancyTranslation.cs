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
                    AnsiConsole.MarkupLine($"[teal]{active["welcome"]}[/]");
                    AnsiConsole.MarkupLine($"[teal]{active["selectedLanguage"]}[/]");
                    AnsiConsole.MarkupLine($"[teal]{active["userState"]}[/]");
                    AnsiConsole.MarkupLine($"[teal]{active["leaveInfo"]}[/]");
                    goto default;
                }
                case "option2":
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

    private static void CustomUserTranslation(Dictionary<string, string> active)
    {
        do
        {
            var userKey = GetCustomUserTranslation(active);
            Console.WriteLine();
            AnsiConsole.MarkupLine($"[teal]{DictionaryProvider.EnDic[userKey]}[/]");
            AnsiConsole.MarkupLine($"[teal]{DictionaryProvider.DeDic[userKey]}[/]");
            Console.WriteLine();
            AnsiConsole.MarkupLine($"[red]{active["leaveInfo"]}[/]");
        } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
    }

    private static string GetCustomUserTranslation(Dictionary<string, string> active)
    {
        AnsiConsole.MarkupLine($"[red]{active["keyPlease"]}[/]");
        while (true)
        {
            var userKey = Console.ReadLine();
            if (!string.IsNullOrEmpty(userKey) && active.ContainsKey(userKey))
            {
                return userKey;
            }

            AnsiConsole.MarkupLine($"[red]{active["validKey"]}[/]");
        }
    }
}