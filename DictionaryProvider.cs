namespace TranslatingStuffs;

public static class DictionaryProvider
{
    internal static readonly Dictionary<string, string> EnDic = new()
    {
        { "welcome", "Hello and Welcome to ze Translator." },
        { "userState", "How are you?" },
        { "rate", "Please leave a rating of this fake translator." },
        { "selectedLanguage", "You have selected the english Language." },
        { "options", "Dear User you now have 2 Options."},
        { "option1", "Option 1: Get some Default Translations in your current Language." },
        { "option2", "Option 2: Enter the key for any one Translation and get the text for the current language as well as for the Translated Language." },
        { "optionsPlease", "Please choose an Option!"},
        { "keyPlease", "Please enter your key for the translation!"},
        { "leaveInfo", "Press ESC to leave."},
        { "continueInfo", "Or Enter to continue."},
        { "validKey", "Please provide a Valid Key!"},
        { "sendingTo", "Sending you to"}
    };

    internal static readonly Dictionary<string, string> DeDic = new()
    {
        { "welcome", "Hallo und herzlich willkommen zum Übersetzter." },
        { "userState", "Wie geht es dir?" },
        { "rate", "Bitte hinterlasse eine fake Bewertung zu diesem nicht echten Übersetzer." },
        { "selectedLanguage", "Du hast die deutsche Sprache ausgewählt." },
        { "options", "Lieber Nutzer, du hast nun 2 Optionen. "},
        { "option1", "Option 1: Erhalte ein paar Standart Übersetzungen in deiner Sprache." },
        { "option2", "Option 2: Gib den Schlüssel für irgendene Übersetzung ein und erhalte die Übersetzung für deine aktuelle Sprache sowie auch für die übersetzte Sprache." },
        { "optionsPlease", "Bitte wähle eine Option."},
        { "keyPlease", "Bitte gib den Schlüssel für deine Übersetung ein!"},
        { "leaveInfo", "Drücke ESC um zu verlassen."},
        { "continueInfo", "Oder Enter um weiter zumachen."},
        { "validKey", "Bitte stelle einen gültigen Schlüssel zur verfügung!"},
        { "sendingTo" , "Wir senden dich zur"}
    };
}