using Coroutine = System.Collections.IEnumerator;
using UnityEngine;

namespace Odders
{
	public static class FloatExtensions
	{
		public static float Abs(this float f) => Mathf.Abs(f);

		public static bool IsBetween(this float f, float min, float max) => f > min && f < max;
		public static bool IsOut(this float f, float min, float max) => f < min || f > max;

		public static Coroutine Lerp(this float f, float target, FloatDelegate function)
		{
			do { function(f); yield return null; }
			while ((f += Time.deltaTime) < target);
		}
	}
}