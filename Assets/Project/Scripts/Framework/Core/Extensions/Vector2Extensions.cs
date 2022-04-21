using UnityEngine;

namespace Odders
{
	public static class Vector2Extensions
	{
		// Vector2
		public static Vector2 SetX(this Vector2 v, float x) => new Vector2(x, v.y);
		public static Vector2 SetY(this Vector2 v, float y) => new Vector2(v.x, y);

		public static Vector2 Add(this Vector2 v, float val) => new Vector2(v.x + val, v.y + val);
		public static Vector2 Add(this Vector2 v, float x, float y) => new Vector2(v.x + x, v.y + y);
		public static Vector2 AddX(this Vector2 v, float x) => new Vector2(v.x + x, v.y);
		public static Vector2 AddY(this Vector2 v, float y) => new Vector2(v.x, v.y + y);

		public static Vector2 Multiply(this Vector2 v, float x, float y) => new Vector2(v.x * x, v.y * y);
		public static Vector2 MultiplyX(this Vector2 v, float x) => new Vector2(v.x * x, v.y);
		public static Vector2 MultiplyY(this Vector2 v, float y) => new Vector2(v.x, v.y * y);

		public static Vector2 FlipX(this Vector2 v) => new Vector2(-v.x, v.y);
		public static Vector2 FlipX(this Vector2 v, float sign) => new Vector2(sign > 0f ? v.x.Abs() : -v.x.Abs(), v.y);
		public static Vector2 FlipY(this Vector2 v) => new Vector2(v.x, -v.y);
		public static Vector2 FlipY(this Vector2 v, float sign) => new Vector2(v.x, sign > 0f ? v.y.Abs() : -v.y.Abs());

		public static Vector2 Clamp(this Vector2 v, float min, float max) => new Vector2(Mathf.Clamp(v.x, min, max), Mathf.Clamp(v.y, min, max));
		public static Vector2 Clamp01(this Vector2 v) => new Vector2(Mathf.Clamp01(v.x), Mathf.Clamp01(v.y));

		public static Vector2 Abs(this Vector2 v) => new Vector2(Mathf.Abs(v.x), Mathf.Abs(v.y));

		public static bool IsNaN(this Vector2 v) => float.IsNaN(v.sqrMagnitude);
		public static bool IsBetween(this Vector2 v, float min, float max)
		{
			if (!v.x.IsBetween(min, max) | !v.y.IsBetween(min, max))
				return false;

			return true;
		}

		public static float Random(this Vector2 v) => UnityEngine.Random.Range(v.x, v.y);
		public static Vector2 Random(this Vector2 v, float min, float max, bool singleValue = false)
		{
			switch (singleValue)
			{
				case true:
					float n = UnityEngine.Random.Range(min, max);
					return new Vector2(n, n);
				case false:
					v.x = UnityEngine.Random.Range(min, max);
					v.y = UnityEngine.Random.Range(min, max);
					return v;
			}
		}


		// Vector2Int
		public static Vector2Int SetX(this Vector2Int v, int x) => new Vector2Int(x, v.y);
		public static Vector2Int SetY(this Vector2Int v, int y) => new Vector2Int(v.x, y);

		public static Vector2Int Add(this Vector2Int v, int val) => new Vector2Int(v.x + val, v.y + val);
		public static Vector2Int Add(this Vector2Int v, int x, int y) => new Vector2Int(v.x + x, v.y + y);
		public static Vector2Int AddX(this Vector2Int v, int x) => new Vector2Int(v.x + x, v.y);
		public static Vector2Int AddY(this Vector2Int v, int y) => new Vector2Int(v.x, v.y + y);

		public static Vector2Int Multiply(this Vector2Int v, int x, int y) => new Vector2Int(v.x * x, v.y * y);
		public static Vector2Int MultiplyX(this Vector2Int v, int x) => new Vector2Int(v.x * x, v.y);
		public static Vector2Int MultiplyY(this Vector2Int v, int y) => new Vector2Int(v.x, v.y * y);

		public static Vector2Int FlipX(this Vector2Int v) => new Vector2Int(-v.x, v.y);
		public static Vector2Int FlipY(this Vector2Int v) => new Vector2Int(v.x, -v.y);

		public static Vector2Int Clamp(this Vector2Int v, float min, float max) => new Vector2Int((int)Mathf.Clamp(v.x, min, max), (int)Mathf.Clamp(v.y, min, max));
		public static Vector2Int Clamp01(this Vector2Int v) => new Vector2Int((int)Mathf.Clamp01(v.x), (int)Mathf.Clamp01(v.y));

		public static Vector2Int Abs(this Vector2Int v) => new Vector2Int(Mathf.Abs(v.x), Mathf.Abs(v.y));

		public static bool IsNaN(this Vector2Int v) => float.IsNaN(v.sqrMagnitude);
		public static bool IsBetween(this Vector2Int v, int min, int max)
		{
			if (!v.x.IsBetween(min, max) | !v.y.IsBetween(min, max))
				return false;

			return true;
		}

		public static int Random(this Vector2Int v) => UnityEngine.Random.Range(v.x, v.y);
		public static Vector2Int Random(this Vector2Int v, int min, int max, bool singleValue = false)
		{
			switch (singleValue)
			{
				case true:
					int n = UnityEngine.Random.Range(min, max);
					return new Vector2Int(n, n);
				case false:
					v.x = UnityEngine.Random.Range(min, max);
					v.y = UnityEngine.Random.Range(min, max);
					return v;
			}
		}
	}
}