using Spectre.Console;

namespace TranslatingStuffs;

public class FancyTranslation(string language)
{
    public void Execute()
    {
        AnsiConsole.WriteLine();
        AnsiConsole.MarkupLine($"[teal]{dic["welcome"]}[/]");
        AnsiConsole.WriteLine(dic["selectedLanguage"]);

        var userOption = ListAndSelectOptions(dic);

        while (true)
        {
            switch (userOption.Key)
            {
                case "option1":
                {
                    AnsiConsole.MarkupLine($"[teal]{dic["welcome"]}[/]");
                    AnsiConsole.MarkupLine($"[teal]{dic["selectedLanguage"]}[/]");
                    AnsiConsole.MarkupLine($"[teal]{dic["userState"]}[/]");
                    AnsiConsole.MarkupLine($"[teal]{dic["rate"]}[/]");
                    break;
                }
                case "option2":
                {
                    CustomUserTranslation(dic);
                    break;
                }

            }
            userOption = ListAndSelectOptions(dic);
        }
    }

    private (string Key, string display) ListAndSelectOptions()
    {
        var option1 = ("option1", dic["option1"]);
        var option2 = ("option2", dic["option2"]);
        AnsiConsole.WriteLine();
        var choice = AnsiConsole.Prompt(
            new SelectionPrompt<(string Key, string Display)>()
                .Title(dic["options"])
                .UseConverter(option => option.Display)
                .AddChoices(option1, option2));

        AnsiConsole.MarkupLine($"{dic["sendingTo"]} [blue]{choice.Item2}[/]");
        AnsiConsole.WriteLine();
        return choice;
    }

    private static void CustomUserTranslation(Dictionary<string, string> dic)
    {
        do
        {
            var userKey = GetCustomUserTranslation(dic);
            Console.WriteLine();
            AnsiConsole.MarkupLine($"[teal]{DictionaryProvider.EnDic[userKey]}[/]");
            AnsiConsole.MarkupLine($"[teal]{DictionaryProvider.DeDic[userKey]}[/]");
            Console.WriteLine();
            AnsiConsole.MarkupLine($"[red]{dic["leaveInfo"]}[/] [green]{dic["continueInfo"]}[/]");
        } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
    }

    private static string GetCustomUserTranslation(Dictionary<string, string> dic)
    {
        AnsiConsole.MarkupLine($"[yellow]{dic["keyPlease"]}[/]");
        while (true)
        {
            var userKey = Console.ReadLine();
            if (!string.IsNullOrEmpty(userKey) && dic.ContainsKey(userKey))
            {
                return userKey;
            }

            AnsiConsole.MarkupLine($"[red]{dic["askValidKey"]}[/]");
        }
    }
}