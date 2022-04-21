using Color = UnityEngine.Color;
using Image = UnityEngine.UI.Image;

namespace Odders
{
    public static class ImageExtensions
    {
        public static void SetR(this Image i, int r) => i.color.SetR(r);
        public static void SetR(this Image i, float r) => i.color.SetR(r);
        public static void SetG(this Image i, int g) => i.color.SetG(g);
        public static void SetG(this Image i, float g) => i.color.SetG(g);
        public static void SetB(this Image i, int b) => i.color.SetB(b);
        public static void SetB(this Image i, float b) => i.color.SetB(b);
        public static void SetA(this Image i, int a) => i.color.SetA(a);
        public static void SetA(this Image i, float a) => i.color.SetA(a);
        public static void SetColor(this Image i, Color col) => i.color = col;
        public static void SetColor(this Image i, string hex) => i.color = hex.ToColor();
    }
}