using System;
using NumberStyles = System.Globalization.NumberStyles;
using Regex = System.Text.RegularExpressions.Regex;
using Color32 = UnityEngine.Color32;

namespace Odders
{
    public static class StringExtensions
    {
        public static string[] Divide(this string s, int n)
        {
            string[] result = new string[1];
            int p = 1;

            for (int i = 0; i < s.Length; i++)
            {
                if (i >= n * p)
                {
                    p++;
                    result = result.Add(string.Empty);
                }

                result[p - 1] += s[i];
            }

            return result;
        }

        public static string Color(this string s, string color) => $"<color={color}>{s}</color>";
        public static Color32 ToColor(this string hex)
        {
            if (!hex.IsHex()) return default;

            hex = hex.Replace("0x", "");
            hex = hex.Replace("#", "");

            byte a = 255;
            byte r = byte.Parse(hex.Substring(0, 2), NumberStyles.HexNumber);
            byte g = byte.Parse(hex.Substring(2, 2), NumberStyles.HexNumber);
            byte b = byte.Parse(hex.Substring(4, 2), NumberStyles.HexNumber);

            if (hex.Length == 8) a = byte.Parse(hex.Substring(6, 2), NumberStyles.HexNumber);

            return new Color32(r, g, b, a);
        }
        public static T ToEnum<T>(this string s, Type t) => (T)Enum.Parse(t, s);

        public static bool IsHex(this string hex) => Regex.IsMatch(hex, @"\A\b[0-9a-fA-F]+\b\Z");
        public static bool IsAlpha(this string s) => Regex.IsMatch(s, @"^[a-zA-Z]+$");
        public static bool IsNumeric(this string s) => int.TryParse(s, out int _);
        public static bool IsAlphanumeric(this string s) => Regex.IsMatch(s, "^[a-zA-Z0-9]*$");

        public static bool IsValidInput<U>(this string s, ValidInputDelegate<U> f)
        {
            try { f(s); }
            catch { return false; }

            return true;
        }
    }
}