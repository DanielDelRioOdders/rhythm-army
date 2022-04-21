using UnityEngine;

namespace Odders
{
	public static class Vector3Extensions
	{
		// Vector3
		public static Vector3 SetX(this Vector3 v, float x) => new Vector3(x, v.y, v.z);
		public static Vector3 SetY(this Vector3 v, float y) => new Vector3(v.x, y, v.z);
		public static Vector3 SetZ(this Vector3 v, float z) => new Vector3(v.x, v.y, z);

		public static Vector3 Add(this Vector3 v, float val) => new Vector3(v.x + val, v.y + val, v.z + val);
		public static Vector3 Add(this Vector3 v, float x, float y, float z) => new Vector3(v.x + x, v.y + y, v.z + z);
		public static Vector3 AddX(this Vector3 v, float x) => new Vector3(v.x + x, v.y, v.z);
		public static Vector3 AddY(this Vector3 v, float y) => new Vector3(v.x, v.y + y, v.z);
		public static Vector3 AddZ(this Vector3 v, float z) => new Vector3(v.x, v.y, v.z + z);

		public static Vector3 Multiply(this Vector3 v, float x, float y, float z) => new Vector3(v.x * x, v.y * y, v.z * z);
		public static Vector3 MultiplyX(this Vector3 v, float x) => new Vector3(v.x * x, v.y, v.z);
		public static Vector3 MultiplyY(this Vector3 v, float y) => new Vector3(v.x, v.y * y, v.z);
		public static Vector3 MultiplyZ(this Vector3 v, float z) => new Vector3(v.x, v.y, v.z * z);

		public static Vector3 FlipX(this Vector3 v) => new Vector3(-v.x, v.y, v.z);
		public static Vector3 FlipX(this Vector3 v, float sign) => new Vector3(sign > 0f ? v.x.Abs() : -v.x.Abs(), v.y, v.z);
		public static Vector3 FlipY(this Vector3 v) => new Vector3(v.x, -v.y, v.z);
		public static Vector3 FlipY(this Vector3 v, float sign) => new Vector3(v.x, sign > 0f ? v.y.Abs() : -v.y.Abs(), v.z);
		public static Vector3 FlipZ(this Vector3 v) => new Vector3(v.x, v.y, -v.z);
		public static Vector3 FlipZ(this Vector3 v, float sign) => new Vector3(v.x, v.y, sign > 0f ? v.z.Abs() : -v.z.Abs());

		public static Vector3 Clamp(this Vector3 v, float min, float max) => new Vector3(Mathf.Clamp(v.x, min, max), Mathf.Clamp(v.y, min, max), Mathf.Clamp(v.z, min, max));
		public static Vector3 Clamp01(this Vector3 v) => new Vector3(Mathf.Clamp01(v.x), Mathf.Clamp01(v.y), Mathf.Clamp01(v.z));

		public static Vector3 Abs(this Vector3 v) => new Vector3(Mathf.Abs(v.x), Mathf.Abs(v.y), Mathf.Abs(v.z));

		public static bool IsNaN(this Vector3 v) => float.IsNaN(v.sqrMagnitude);
		public static bool IsBetween(this Vector3 v, float min, float max)
		{
			if (!v.x.IsBetween(min, max) | !v.y.IsBetween(min, max) | !v.z.IsBetween(min, max))
				return false;

			return true;
		}

		public static Vector3 Random(this Vector3 v, float min, float max, bool singleValue = false)
		{
			switch (singleValue)
			{
				case true:
					float n = UnityEngine.Random.Range(min, max);
					return new Vector3(n, n, n);
				case false:
					v.x = UnityEngine.Random.Range(min, max);
					v.y = UnityEngine.Random.Range(min, max);
					v.z = UnityEngine.Random.Range(min, max);
					return v;
			}
		}


		// Vector3Int
		public static Vector3Int SetX(this Vector3Int v, int x) => new Vector3Int(x, v.y, v.z);
		public static Vector3Int SetY(this Vector3Int v, int y) => new Vector3Int(v.x, y, v.z);
		public static Vector3Int SetZ(this Vector3Int v, int z) => new Vector3Int(v.x, v.y, z);

		public static Vector3Int Add(this Vector3Int v, int val) => new Vector3Int(v.x + val, v.y + val, v.z + val);
		public static Vector3Int Add(this Vector3Int v, int x, int y, int z) => new Vector3Int(v.x + x, v.y + y, v.z + z);
		public static Vector3Int AddX(this Vector3Int v, int x) => new Vector3Int(v.x + x, v.y, v.z);
		public static Vector3Int AddY(this Vector3Int v, int y) => new Vector3Int(v.x, v.y + y, v.z);
		public static Vector3Int AddZ(this Vector3Int v, int z) => new Vector3Int(v.x, v.y, v.z + z);

		public static Vector3Int Multiply(this Vector3Int v, int x, int y, int z) => new Vector3Int(v.x * x, v.y * y, v.z * z);
		public static Vector3Int MultiplyX(this Vector3Int v, int x) => new Vector3Int(v.x * x, v.y, v.z);
		public static Vector3Int MultiplyY(this Vector3Int v, int y) => new Vector3Int(v.x, v.y * y, v.z);
		public static Vector3Int MultiplyZ(this Vector3Int v, int z) => new Vector3Int(v.x, v.y, v.z * z);

		public static Vector3Int FlipX(this Vector3Int v) => new Vector3Int(-v.x, v.y, v.z);
		public static Vector3Int FlipY(this Vector3Int v) => new Vector3Int(v.x, -v.y, v.z);
		public static Vector3Int FlipZ(this Vector3Int v) => new Vector3Int(v.x, v.y, -v.z);

		public static Vector3Int Clamp(this Vector3Int v, float min, float max) => new Vector3Int((int)Mathf.Clamp(v.x, min, max), (int)Mathf.Clamp(v.y, min, max), (int)Mathf.Clamp(v.z, min, max));
		public static Vector3Int Clamp01(this Vector3Int v) => new Vector3Int((int)Mathf.Clamp01(v.x), (int)Mathf.Clamp01(v.y), (int)Mathf.Clamp01(v.z));

		public static Vector3Int Abs(this Vector3Int v) => new Vector3Int(Mathf.Abs(v.x), Mathf.Abs(v.y), Mathf.Abs(v.z));

		public static Vector3Int Random(this Vector3Int v, int min, int max, bool singleValue = false)
		{
			switch (singleValue)
			{
				case true:
					int n = UnityEngine.Random.Range(min, max);
					return new Vector3Int(n, n, n);
				case false:
					v.x = UnityEngine.Random.Range(min, max);
					v.y = UnityEngine.Random.Range(min, max);
					v.z = UnityEngine.Random.Range(min, max);
					return v;
			}
		}

		public static bool IsNaN(this Vector3Int v) => float.IsNaN(v.sqrMagnitude);
		public static bool IsBetween(this Vector3Int v, int min, int max)
		{
			if (!v.x.IsBetween(min, max) | !v.y.IsBetween(min, max) | !v.z.IsBetween(min, max))
				return false;

			return true;
		}
	}
}