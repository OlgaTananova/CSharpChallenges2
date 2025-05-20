using System;
using System.Globalization;
using System.Text;

namespace Practice.Core.CustomStringFormatter;

public static class CustomStringFormatter
{
    public static string FormatStringToCapitalizeFirstLetters(string s)
    {
        if (string.IsNullOrEmpty(s)) return string.Empty;
        string[] array = s.Split(" ", StringSplitOptions.RemoveEmptyEntries);
        StringBuilder capitalizedString = new();
        for (int i = 0; i < array.Length; i++)
        {
            var currWord = array[i];
            if (string.IsNullOrWhiteSpace(currWord)) continue;
            if (currWord.Length > 0) currWord = char.ToUpper(currWord[0]) + currWord.Substring(1);

            capitalizedString.Append(currWord);
            capitalizedString.Append(" ");
        }
        return capitalizedString.ToString().Trim();
    }

    public static string FormatStringToTitleCase(string s)
    {
        if (string.IsNullOrWhiteSpace(s)) return string.Empty;

        s = s.ToLowerInvariant();

        TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
        return textInfo.ToTitleCase(s);
    }
}
