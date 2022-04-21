using System;
using System.Linq;

namespace Odders
{
	public static class ArrayExtensions
	{
		public static T[] Shuffle<T>(this T[] a)
		{
			int length = a.Length;
			for (int i = 0; i < length - 1; i++)
			{
				int j = UnityEngine.Random.Range(i, length);
				T tmp = a[i];
				a[i] = a[j];
				a[j] = tmp;
			}

			return a;
		}
		public static T Random<T>(this T[] a)
		{
			if (a == null || a.Length == 0) return default;

			return a[UnityEngine.Random.Range(0, a.Length)];
		}

		public static T[] Add<T>(this T[] a, T b, bool ifNotContains = false)
		{
			int length = a.Length;
			T[] result = new T[length + 1];

			for (int i = 0; i < length; i++)
			{
				result[i] = a[i];
				if (ifNotContains && result[i].Equals(a[i]))
					return a;
			}
			result[length] = b;

			return result;
		}
		public static T[] Add<T>(this T[] a, T[] b)
		{
			int length = a.Length + b.Length;
			T[] result = new T[length];

			for (int i = 0; i < result.Length; i++)
				result[i] = i < a.Length ? a[i] : b[i - a.Length];

			return result;
		}

		public static T[] Insert<T>(this T[] a, T b, int p)
		{
			int length = a.Length + 1;
			T[] result = new T[length + 1];

			for (int i = 0; i < length; i++)
			{
				if (i < p) result[i] = a[i];
				else if (i == p) result[i] = b;
				else result[i] = a[i - 1];
			}

			return result;
		}
		public static T[] Insert<T>(this T[] a, T[] b, int p)
		{
			int length = a.Length + b.Length;
			T[] result = new T[length];

			int end = p + b.Length - 1;
			for (int i = 0; i < p; i++) result[i] = a[i];
			for (int i = p; i <= end; i++) result[i] = b[i - p];
			for (int i = end + 1; i < length; i++) result[i] = a[i - p - 1];

			return result;
		}

		public static T[] Fusion<T>(this T[] a, T[] b) => a.Union(b).ToArray();
		public static U[] Get<T, U>(this T[] a, Func<T, U> f) => a.Select(f).ToArray();

		public static T[] RemoveAt<T>(this T[] a, int i)			=> a.Remove(a[i]);
		public static T[] Remove<T>(this T[] a, T b)				=> a.Where(i => !i.Equals(b)).ToArray();
		public static T[] Remove<T>(this T[] a, T[] b)				=> a.Where(i => !b.Contains(i)).ToArray();
		public static T[] Remove<T>(this T[] a, int p1, int p2)		=> a.Where(i => a.Index(i) < p1 || a.Index(i) > p2).ToArray();

		public static T[] FindAll<T>(this T[] a, T b)				=> Array.FindAll(a, i => i.Equals(b));
		public static T[] FindAll<T>(this T[] a, T[] b)				=> Array.FindAll(a, i => b.Contains(i));
		public static T[] FindAll<T>(this T[] a, Predicate<T> f)	=> Array.FindAll(a, f);

		public static T First<T>(this T[] a)						=> a[0];
		public static T Last<T>(this T[] a)							=> a[a.Length - 1];

		public static T Find<T>(this T[] a, T b)					=> Array.Find(a, i => i.Equals(b));
		public static T Find<T>(this T[] a, Predicate<T> f)			=> Array.Find(a, f);

		public static U Maximum<T, U>(this T[] a, Func<T, U> f)		=> a.Max(f);
		public static U Minimum<T, U>(this T[] a, Func<T, U> f)		=> a.Min(f);

		public static int Index<T>(this T[] a, T b)					=> Index(a, i => i.Equals(b));
		public static int Index<T>(this T[] a, Predicate<T> f)		=> Array.FindIndex(a, f);

		public static bool Contains<T>(this T[] a, T b)				=> Contains(a, i => i.Equals(b));
		public static bool Contains<T>(this T[] a, Predicate<T> f)	=> Array.Exists(a, f);

		public static void Each<T>(this T[] a, Action<T> f)			=> Array.ForEach(a, f);
		public static void Sort<T>(this T[] a)						=> Array.Sort(a);
		public static void Reverse<T>(this T[] a)					=> Array.Reverse(a);

		public static void Swap<T>(this T[] a, T i1, T i2)			=> a.Swap(a.Index(i1), a.Index(i2));
		public static void Swap<T>(this T[] a, int p1, int p2)		=> (a[p1], a[p2]) = (a[p2], a[p1]);

		public static bool InBounds<T>(this T[] a, int p)			=> p >= 0 && p < a.Length;

		public static bool IsNull<T>(this T[] a, int p)				=> a[p].Equals(default);
		public static bool IsNull<T>(this T[] a)					=> a == null;
		public static bool IsEmpty<T>(this T[] a)					=> a.Length == 0;
		public static bool IsNullOrEmpty<T>(this T[] a)				=> a.IsNull() || a.IsEmpty();
	}
}