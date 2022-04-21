using UnityEngine;

namespace Odders
{
    public static class ColorExtensions
    {
        public static Color Set(this Color c, int r, int g, int b, int a) => new Color(r / 255, g / 255, b / 255, a / 255);
        public static Color SetR(this Color c, int r) => new Color(r / 255, c.g, c.b, c.a);
        public static Color SetR(this Color c, float r) => new Color(r, c.g, c.b, c.a);
        public static Color SetG(this Color c, int g) => new Color(c.r, g / 255, c.b, c.a);
        public static Color SetG(this Color c, float g) => new Color(c.r, g, c.b, c.a);
        public static Color SetB(this Color c, int b) => new Color(c.r, c.g, b / 255, c.a);
        public static Color SetB(this Color c, float b) => new Color(c.r, c.g, b, c.a);
        public static Color SetA(this Color c, int a) => new Color(c.r, c.g, c.b, a / 255);
        public static Color SetA(this Color c, float a) => new Color(c.r, c.g, c.b, a);

        public static string ToHex(this Color32 c)
        {
            string r = c.r.ToString("X2");
            string g = c.g.ToString("X2");
            string b = c.b.ToString("X2");
            return r + g + b;
        }
    }
}