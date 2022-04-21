using Color = UnityEngine.Color;
using TMP_Text = TMPro.TMP_Text;

namespace Odders
{
    public static class TMPTextExtensions
    {
        public static void SetR(this TMP_Text t, int r) => t.color.SetR(r);
        public static void SetR(this TMP_Text t, float r) => t.color.SetR(r);
        public static void SetG(this TMP_Text t, int g) => t.color.SetG(g);
        public static void SetG(this TMP_Text t, float g) => t.color.SetG(g);
        public static void SetB(this TMP_Text t, int b) => t.color.SetB(b);
        public static void SetB(this TMP_Text t, float b) => t.color.SetB(b);
        public static void SetA(this TMP_Text t, int a) => t.color.SetA(a);
        public static void SetA(this TMP_Text t, float a) => t.color.SetA(a);
        public static void SetColor(this TMP_Text t, Color col) => t.color = col;
        public static void SetColor(this TMP_Text t, string hex) => t.color = hex.ToColor();
    }
}