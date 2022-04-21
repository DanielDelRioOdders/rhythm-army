using Color = UnityEngine.Color;
using Text = UnityEngine.UI.Text;

namespace Odders
{
    public static class TextExtensions
    {
        public static void SetR(this Text t, int r) => t.color.SetR(r);
        public static void SetR(this Text t, float r) => t.color.SetR(r);
        public static void SetG(this Text t, int g) => t.color.SetG(g);
        public static void SetG(this Text t, float g) => t.color.SetG(g);
        public static void SetB(this Text t, int b) => t.color.SetB(b);
        public static void SetB(this Text t, float b) => t.color.SetB(b);
        public static void SetA(this Text t, int a) => t.color.SetA(a);
        public static void SetA(this Text t, float a) => t.color.SetA(a);
        public static void SetColor(this Text t, Color col) => t.color = col;
        public static void SetColor(this Text t, string hex) => t.color = hex.ToColor();
    }
}