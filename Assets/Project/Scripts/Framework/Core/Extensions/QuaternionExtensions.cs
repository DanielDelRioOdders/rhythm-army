using UnityEngine;

namespace Odders
{
	public static class QuaternionExtensions
	{
		public static bool IsNaN(Quaternion q) => float.IsNaN(q.x * q.y * q.z * q.w);

		public static Quaternion Zero(this Quaternion q) => Quaternion.Euler(0f, 0f, 0f);

		public static Quaternion Up(this Quaternion q) => Quaternion.Euler(0f, 1f, 0f);
		public static Quaternion Up(this Quaternion q, int i) => Quaternion.Euler(0f, i, 0f);
		public static Quaternion Up(this Quaternion q, float f) => Quaternion.Euler(0f, f, 0f);
		public static Quaternion Up90(this Quaternion q) => Quaternion.Euler(0f, 90f, 0f);
		public static Quaternion Up180(this Quaternion q) => Quaternion.Euler(0f, 180f, 0f);

		public static Quaternion Down(this Quaternion q) => Quaternion.Euler(0f, -1f, 0f);
		public static Quaternion Down(this Quaternion q, int i) => Quaternion.Euler(0f, -i, 0f);
		public static Quaternion Down(this Quaternion q, float f) => Quaternion.Euler(0f, -f, 0f);
		public static Quaternion Down90(this Quaternion q) => Quaternion.Euler(0f, -90f, 0f);
		public static Quaternion Down180(this Quaternion q) => Quaternion.Euler(0f, -180f, 0f);

		public static Quaternion Left(this Quaternion q) => Quaternion.Euler(-1f, 0f, 0f);
		public static Quaternion Left(this Quaternion q, int i) => Quaternion.Euler(-i, 0f, 0f);
		public static Quaternion Left(this Quaternion q, float f) => Quaternion.Euler(-f, 0f, 0f);
		public static Quaternion Left90(this Quaternion q) => Quaternion.Euler(-90f, 0f, 0f);
		public static Quaternion Left180(this Quaternion q) => Quaternion.Euler(-180f, 0f, 0f);

		public static Quaternion Right(this Quaternion q) => Quaternion.Euler(1f, 0f, 0f);
		public static Quaternion Right(this Quaternion q, int i) => Quaternion.Euler(i, 0f, 0f);
		public static Quaternion Right(this Quaternion q, float f) => Quaternion.Euler(f, 0f, 0f);
		public static Quaternion Right90(this Quaternion q) => Quaternion.Euler(90f, 0f, 0f);
		public static Quaternion Right180(this Quaternion q) => Quaternion.Euler(180f, 0f, 0f);

		public static Quaternion Forward(this Quaternion q) => Quaternion.Euler(0f, 0f, 1f);
		public static Quaternion Forward(this Quaternion q, int i) => Quaternion.Euler(0f, 0f, i);
		public static Quaternion Forward(this Quaternion q, float f) => Quaternion.Euler(0f, 0f, f);
		public static Quaternion Forward90(this Quaternion q) => Quaternion.Euler(0f, 0f, 90f);
		public static Quaternion Forward180(this Quaternion q) => Quaternion.Euler(0f, 0f, 180f);

		public static Quaternion Backward(this Quaternion q) => Quaternion.Euler(0f, 0f, -1f);
		public static Quaternion Backward(this Quaternion q, int i) => Quaternion.Euler(0f, 0f, -i);
		public static Quaternion Backward(this Quaternion q, float f) => Quaternion.Euler(0f, 0f, -f);
		public static Quaternion Backward90(this Quaternion q) => Quaternion.Euler(0f, 0f, -90f);
		public static Quaternion Backward180(this Quaternion q) => Quaternion.Euler(0f, 0f, -180f);

		public static Quaternion Add(this Quaternion a, int b) => a.Add(Vector3.one * b);
		public static Quaternion Add(this Quaternion a, float b) => a.Add(Vector3.one * b);
		public static Quaternion Add(this Quaternion a, Quaternion b) => a.Add(b.eulerAngles);
		public static Quaternion Add(this Quaternion a, Vector3Int b) => a.Add((Vector3)b);
		public static Quaternion Add(this Quaternion a, Vector3 b)
		{
			Vector3 e = a.eulerAngles;
			return Quaternion.Euler(e.x + b.x, e.y + b.y, e.z + b.z);
		}

		public static Quaternion Subtract(this Quaternion a, int b) => a.Subtract(Vector3.one * b);
		public static Quaternion Subtract(this Quaternion a, float b) => a.Subtract(Vector3.one * b);
		public static Quaternion Subtract(this Quaternion a, Quaternion b) => a.Subtract(b.eulerAngles);
		public static Quaternion Subtract(this Quaternion a, Vector3Int b) => a.Subtract((Vector3)b);
		public static Quaternion Subtract(this Quaternion a, Vector3 b)
		{
			Vector3 e = a.eulerAngles;
			return Quaternion.Euler(e.x - b.x, e.y - b.y, e.z - b.z);
		}

		public static Quaternion Multiply(this Quaternion a, int b) => a.Multiply(Vector3.one * b);
		public static Quaternion Multiply(this Quaternion a, float b) => a.Multiply(Vector3.one * b);
		public static Quaternion Multiply(this Quaternion a, Quaternion b) => a.Multiply(b.eulerAngles);
		public static Quaternion Multiply(this Quaternion a, Vector3Int b) => a.Multiply((Vector3)b);
		public static Quaternion Multiply(this Quaternion a, Vector3 b)
		{
			Vector3 e = a.eulerAngles;
			return Quaternion.Euler(e.x * b.x, e.y * b.y, e.z * b.z);
		}

		public static Quaternion Divide(this Quaternion a, int b) => a.Divide(Vector3.one * b);
		public static Quaternion Divide(this Quaternion a, float b) => a.Divide(Vector3.one * b);
		public static Quaternion Divide(this Quaternion a, Quaternion b) => a.Divide(b.eulerAngles);
		public static Quaternion Divide(this Quaternion a, Vector3Int b) => a.Divide((Vector3)b);
		public static Quaternion Divide(this Quaternion a, Vector3 b)
		{
			Vector3 e = a.eulerAngles;
			return Quaternion.Euler(e.x / b.x, e.y / b.y, e.z / b.z);
		}
	}
}