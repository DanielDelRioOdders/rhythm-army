using System.Collections.Generic;
using System.Linq;

namespace Odders
{
    public static class ListExtensions
    {
        public static List<T> Shuffle<T>(this List<T> a) => a.ToArray().Shuffle().ToList();
        public static T Random<T>(this List<T> a) => a.ToArray().Random();

		public static T First<T>(this List<T> l) => l.ToArray().First();
        public static T Last<T>(this List<T> l) => l.ToArray().Last();
    }
}