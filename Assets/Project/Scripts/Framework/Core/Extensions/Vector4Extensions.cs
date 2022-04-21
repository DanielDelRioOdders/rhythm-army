using UnityEngine;

namespace Odders
{
	public static class Vector4Extensions
	{
		public static Vector4 SetX(this Vector4 v, float x) => new Vector4(x, v.y, v.z, v.w);
		public static Vector4 SetY(this Vector4 v, float y) => new Vector4(v.x, y, v.z, v.w);
		public static Vector4 SetZ(this Vector4 v, float z) => new Vector4(v.x, v.y, z, v.w);
		public static Vector4 SetW(this Vector4 v, float w) => new Vector4(v.x, v.y, v.z, w);

		public static Vector4 Add(this Vector4 v, float val) => new Vector4(v.x + val, v.y + val, v.z + val, v.w + val);
		public static Vector4 Add(this Vector4 v, float x, float y, float z, float w) => new Vector4(v.x + x, v.y + y, v.z + z, v.w + w);
		public static Vector4 AddX(this Vector4 v, float x) => new Vector4(v.x + x, v.y, v.z, v.w);
		public static Vector4 AddY(this Vector4 v, float y) => new Vector4(v.x, v.y + y, v.z, v.w);
		public static Vector4 AddZ(this Vector4 v, float z) => new Vector4(v.x, v.y, v.z + z, v.w);
		public static Vector4 AddW(this Vector4 v, float w) => new Vector4(v.x, v.y, v.z, v.w + w);

		public static Vector4 Multiply(this Vector4 v, float x, float y, float z, float w) => new Vector4(v.x * x, v.y * y, v.z * z, v.w * w);
		public static Vector4 MultiplyX(this Vector4 v, float x) => new Vector4(v.x * x, v.y, v.z, v.w);
		public static Vector4 MultiplyY(this Vector4 v, float y) => new Vector4(v.x, v.y * y, v.z, v.w);
		public static Vector4 MultiplyZ(this Vector4 v, float z) => new Vector4(v.x, v.y, v.z * z, v.w);
		public static Vector4 MultiplyW(this Vector4 v, float w) => new Vector4(v.x, v.y, v.z, v.w * w);

		public static Vector4 FlipX(this Vector4 v) => new Vector4(-v.x, v.y, v.z, v.w);
		public static Vector4 FlipX(this Vector4 v, float sign) => new Vector4(sign > 0f ? v.x.Abs() : -v.x.Abs(), v.y, v.z, v.w);
		public static Vector4 FlipY(this Vector4 v) => new Vector4(v.x, -v.y, v.z, v.w);
		public static Vector4 FlipY(this Vector4 v, float sign) => new Vector4(v.x, sign > 0f ? v.y.Abs() : -v.y.Abs(), v.z, v.w);
		public static Vector4 FlipZ(this Vector4 v) => new Vector4(v.x, v.y, -v.z, v.w);
		public static Vector4 FlipZ(this Vector4 v, float sign) => new Vector4(v.x, v.y, sign > 0f ? v.z.Abs() : -v.z.Abs(), v.w);
		public static Vector4 FlipW(this Vector4 v) => new Vector4(v.x, v.y, v.z, -v.w);
		public static Vector4 FlipW(this Vector4 v, float sign) => new Vector4(v.x, v.y, v.z, sign > 0f ? v.w.Abs() : -v.w.Abs());

		public static Vector4 Clamp(this Vector4 v, float min, float max) => new Vector4(Mathf.Clamp(v.x, min, max), Mathf.Clamp(v.y, min, max), Mathf.Clamp(v.z, min, max), Mathf.Clamp(v.w, min, max));
		public static Vector4 Clamp01(this Vector4 v) => new Vector4(Mathf.Clamp01(v.x), Mathf.Clamp01(v.y), Mathf.Clamp01(v.z), Mathf.Clamp01(v.w));

		public static Vector4 Abs(this Vector4 v) => new Vector4(Mathf.Abs(v.x), Mathf.Abs(v.y), Mathf.Abs(v.z), Mathf.Abs(v.w));

		public static bool IsNaN(this Vector4 v) => float.IsNaN(v.sqrMagnitude);
		public static bool IsBetween(this Vector4 v, float min, float max)
		{
			if (!v.x.IsBetween(min, max) | !v.y.IsBetween(min, max) | !v.z.IsBetween(min, max) | !v.w.IsBetween(min, max))
				return false;

			return true;
		}

		public static Vector4 Random(this Vector4 v, float min, float max, bool singleValue = false)
		{
			switch (singleValue)
			{
				case true:
					float n = UnityEngine.Random.Range(min, max);
					return new Vector4(n, n, n, n);
				case false:
					v.x = UnityEngine.Random.Range(min, max);
					v.y = UnityEngine.Random.Range(min, max);
					v.z = UnityEngine.Random.Range(min, max);
					v.w = UnityEngine.Random.Range(min, max);
					return v;
			}
		}
	}
}