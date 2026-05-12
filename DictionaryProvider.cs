namespace TranslatingStuffs;

public static class DictionaryProvider
{
    internal static Dictionary<string, string> EnDic = new()
    {
        { "welcome", "Hello and Welcome to ze Translator" },
        { "userState", "How are you?" },
        { "rate", "Please leave a rating of this fake translator" },
        { "selectedLanguage", "You have selected the english Language" },
        {"options", "Dear User you now have 2 Options. "}
    };

    internal static Dictionary<string, string> DeDic = new()
    {
        { "welcome", "Hallo und herzlich willkommen zum Übersetzter." },
        { "userState", "Wie geht es dir?" },
        { "rate", "Bitte hinterlasse eine fake Bewertung zu diesem fake Übersetzer" },
        { "selectedLanguage", "Du hast die deutsche Sprache ausgewählt" }
    };
}