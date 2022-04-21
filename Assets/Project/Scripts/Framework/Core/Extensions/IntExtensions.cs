using Mathf = UnityEngine.Mathf;

namespace Odders
{
	public static class IntExtensions
	{
		public static int Abs(this int i) => Mathf.Abs(i);

		public static bool IsBetween(this int f, int min, int max) => f > min && f < max;
		public static bool IsOut(this int f, int min, int max) => f < min || f > max;
	}
}