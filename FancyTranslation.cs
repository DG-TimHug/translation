using Spectre.Console;

namespace TranslatingStuffs;

public class FancyTranslation(string language) : ITranslator
{
    private readonly DictionaryProvider translator = new(language);

    public void Execute()
    {
        AnsiConsole.WriteLine();
        AnsiConsole.MarkupLine($"[teal]{translator.GetText("welcome")}[/]");
        AnsiConsole.WriteLine(translator.GetText("selectedLanguage"));

        var userOption = ListAndSelectOptions();

        while (true)
        {
            switch (userOption.Key)
            {
                case "option1":
                {
                    AnsiConsole.MarkupLine($"[teal]{translator.GetText("welcome")}[/]");
                    AnsiConsole.MarkupLine($"[teal]{translator.GetText("selectedLanguage")}[/]");
                    AnsiConsole.MarkupLine($"[teal]{translator.GetText("userState")}[/]");
                    AnsiConsole.MarkupLine($"[teal]{translator.GetText("rate")}[/]");
                    break;
                }
                case "option2":
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
        var option1 = new DisplayPair { Key = "option1", Display = translator.GetText("option1") };

        var option2 = new DisplayPair { Key = "option2", Display = translator.GetText("option2") };
        AnsiConsole.WriteLine();
        var choice = AnsiConsole.Prompt(
            new SelectionPrompt<DisplayPair>()
                .Title(translator.GetText("options"))
                .UseConverter(option => option.Display)
                .AddChoices(option1, option2)
        );

        AnsiConsole.MarkupLine($"{translator.GetText("sendingTo")} [blue]{choice.Display}[/]");
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
                $"[red]{translator.GetText("leaveInfo")}[/] [green]{translator.GetText("continueInfo")}[/]"
            );
        } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
    }

    private string GetCustomUserTranslation()
    {
        AnsiConsole.MarkupLine($"[yellow]{translator.GetText("keyPlease")}[/]");
        while (true)
        {
            var userKey = Console.ReadLine();
            if (!string.IsNullOrEmpty(userKey) && translator.ContainsKeyPair(userKey))
            {
                return userKey;
            }

            AnsiConsole.MarkupLine($"[red]{translator.GetText("askValidKey")}[/]");
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
