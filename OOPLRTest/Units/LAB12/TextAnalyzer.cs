using System.Collections.Generic;
using System.Text;

namespace LAB12;

public class TextAnalyzer
{
    public static List<string> SplitWords(string text)
    {
        var words = new List<string>();
        if (string.IsNullOrEmpty(text)) return words;
        var sb = new StringBuilder();
        foreach (char c in text)
        {
            if (char.IsLetterOrDigit(c) || c == '#')
            {
                sb.Append(c);
            }
            else
            {
                if (sb.Length > 0)
                {
                    words.Add(sb.ToString());
                    sb.Clear();
                }
            }
        }
        if (sb.Length > 0)
            words.Add(sb.ToString());
        return words;
    }

    public static string Backspace(string text)
    {
        if (string.IsNullOrEmpty(text) || text.Length == 1)
            return string.Empty;
        return text.Substring(0, text.Length - 1);
    }
}
