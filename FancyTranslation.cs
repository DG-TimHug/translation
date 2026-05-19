using Spectre.Console;

namespace TranslatingStuffs;

public class FancyTranslation(string language) : ITranslator
{
    private readonly Translator translator = new(language);

    public void Execute()
    {
        AnsiConsole.WriteLine();
        AnsiConsole.MarkupLine($"[teal]{translator["welcome"]}[/]");
        AnsiConsole.WriteLine(translator["selectedLanguage"]);

        var userOption = ListAndSelectOptions();

        while (true)
        {
            switch (userOption.Key)
            {
                case "optionDefaultTranslations":
                {
                    AnsiConsole.MarkupLine($"[teal]{translator["welcome"]}[/]");
                    AnsiConsole.MarkupLine($"[teal]{translator["selectedLanguage"]}[/]");
                    AnsiConsole.MarkupLine($"[teal]{translator["userState"]}[/]");
                    AnsiConsole.MarkupLine($"[teal]{translator["rate"]}[/]");
                    break;
                }
                case "optionCustomTranslation":
                {
                    CustomUserTranslation();
                    break;
                }
            }

            userOption = ListAndSelectOptions();
        }
    }

    private DisplayPair ListAndSelectOptions()
    {
        var option1 = new DisplayPair
        {
            Key = "optionDefaultTranslations",
            Display = translator["optionDefaultTranslations"],
        };

        var option2 = new DisplayPair
        {
            Key = "optionCustomTranslation",
            Display = translator["optionCustomTranslation"],
        };
        AnsiConsole.WriteLine();
        var choice = AnsiConsole.Prompt(
            new SelectionPrompt<DisplayPair>()
                .Title(translator["options"])
                .UseConverter(option => option.Display)
                .AddChoices(option1, option2)
        );

        AnsiConsole.MarkupLine($"{translator["sendingTo"]} [blue]{choice.Display}[/]");
        AnsiConsole.WriteLine();
        return choice;
    }

    private void CustomUserTranslation()
    {
        do
        {
            var userKey = GetCustomUserTranslation();
            PrintCustomUserTranslation(userKey);
            AnsiConsole.MarkupLine(
                $"[red]{translator["leaveInfo"]}[/] [green]{translator["continueInfo"]}[/]"
            );
        } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
    }

    private string GetCustomUserTranslation()
    {
        AnsiConsole.MarkupLine($"[yellow]{translator["keyPlease"]}[/]");
        while (true)
        {
            var userKey = Console.ReadLine();
            if (!string.IsNullOrEmpty(userKey) && translator.ContainsKeyPair(userKey))
            {
                return userKey;
            }

            AnsiConsole.MarkupLine($"[red]{translator["askValidKey"]}[/]");
        }
    }

    private void PrintCustomUserTranslation(string userKey)
    {
        Console.WriteLine();

        foreach (var possibleOutputs in translator.GetAllLanguages(userKey))
        {
            AnsiConsole.MarkupLine($"[teal]{possibleOutputs}[/]");
        }
        Console.WriteLine();
    }
}

public record DisplayPair
{
    public required string Key { get; init; }
    public required string Display { get; init; }
}
