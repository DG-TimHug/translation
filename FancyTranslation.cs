using Spectre.Console;

namespace TranslatingStuffs;

public class FancyTranslation(string language)
{
    private readonly DictionaryProvider provider = new(language);
    private readonly DisplayPair displayPair = new();

    public void Execute()
    {
        AnsiConsole.WriteLine();
        AnsiConsole.MarkupLine($"[teal]{provider.GetText("welcome")}[/]");
        AnsiConsole.WriteLine(provider.GetText("selectedLanguage"));

        var userOption = ListAndSelectOptions();

        while (true)
        {
            switch (userOption.Key)
            {
                case "option1":
                {
                    AnsiConsole.MarkupLine($"[teal]{provider.GetText("welcome")}[/]");
                    AnsiConsole.MarkupLine($"[teal]{provider.GetText("selectedLanguage")}[/]");
                    AnsiConsole.MarkupLine($"[teal]{provider.GetText("userState")}[/]");
                    AnsiConsole.MarkupLine($"[teal]{provider.GetText("rate")}[/]");
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
        var option1 = ("option1", provider.GetText("option1"));
        var option2 = ("option2", provider.GetText("option2"));
        AnsiConsole.WriteLine();
        var choice = AnsiConsole.Prompt(
            new SelectionPrompt<DisplayPair>()
                .Title(provider.GetText("options"))
                .UseConverter(option => option.Display)
                .AddChoices<>(option1, option2)
        );

        AnsiConsole.MarkupLine($"{provider.GetText("sendingTo")} [blue]{displayPair.Display}[/]");
        AnsiConsole.WriteLine();
        return choice;
    }

    private void CustomUserTranslation()
    {
        do
        {
            var userKey = GetCustomUserTranslation();
            Console.WriteLine();
            AnsiConsole.MarkupLine($"[teal]{provider.GetEnText(userKey)}[/]");
            AnsiConsole.MarkupLine($"[teal]{provider.GetDeText(userKey)}[/]");
            Console.WriteLine();
            AnsiConsole.MarkupLine(
                $"[red]{provider.GetText("leaveInfo")}[/] [green]{provider.GetText("continueInfo")}[/]"
            );
        } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
    }

    private string GetCustomUserTranslation()
    {
        AnsiConsole.MarkupLine($"[yellow]{provider.GetText("keyPlease")}[/]");
        while (true)
        {
            var userKey = Console.ReadLine();
            if (!string.IsNullOrEmpty(userKey) && provider.ContainsKeyPair(userKey))
            {
                return userKey;
            }

            AnsiConsole.MarkupLine($"[red]{provider.GetText("askValidKey")}[/]");
        }
    }
}

public record DisplayPair
{
    public string Key { get; init; }
    public string Display { get; init; }
}
