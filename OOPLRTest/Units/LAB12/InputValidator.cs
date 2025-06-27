using System;

namespace LAB12;

public class InputValidator
{
    public static bool ValidateDouble(string text)
    {
        double val;
        return double.TryParse(text.Replace(',', '.'), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out val);
    }

    public static bool ValidateInt(string text)
    {
        int val;
        return int.TryParse(text, out val);
    }
} 