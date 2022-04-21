using UnityEngine;

namespace Odders
{
    public static class SpriteRendererExtensions
    {
        public static void SetR(this SpriteRenderer s, int r) => s.color.SetR(r);
        public static void SetR(this SpriteRenderer s, float r) => s.color.SetR(r);
        public static void SetG(this SpriteRenderer s, int g) => s.color.SetG(g);
        public static void SetG(this SpriteRenderer s, float g) => s.color.SetG(g);
        public static void SetB(this SpriteRenderer s, int b) => s.color.SetB(b);
        public static void SetB(this SpriteRenderer s, float b) => s.color.SetB(b);
        public static void SetA(this SpriteRenderer s, int a) => s.color.SetA(a);
        public static void SetA(this SpriteRenderer s, float a) => s.color.SetA(a);
        public static void SetColor(this SpriteRenderer s, Color col) => s.color = col;
        public static void SetColor(this SpriteRenderer s, string hex) => s.color = hex.ToColor();
    }
}