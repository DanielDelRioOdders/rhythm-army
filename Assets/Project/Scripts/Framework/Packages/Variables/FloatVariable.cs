using UnityEngine;

namespace Odders
{
	[CreateAssetMenu(fileName = "New Float", menuName = "Odders/Variables/Float")]
	public class FloatVariable : GlobalVariable<float>
	{
		#region Utility Methods
		public void Add(float value) => Value += value;

		public static FloatVariable operator +(FloatVariable a, float b) { a.Value += b; return a; }
		public static FloatVariable operator -(FloatVariable a, float b) { a.Value -= b; return a; }
		public static FloatVariable operator *(FloatVariable a, float b) { a.Value *= b; return a; }
		public static FloatVariable operator /(FloatVariable a, float b) { a.Value /= b; return a; }

		public static FloatVariable operator +(FloatVariable a, FloatVariable b) { a.Value += b.Value; return a; }
		public static FloatVariable operator -(FloatVariable a, FloatVariable b) { a.Value -= b.Value; return a; }
		public static FloatVariable operator *(FloatVariable a, FloatVariable b) { a.Value *= b.Value; return a; }
		public static FloatVariable operator /(FloatVariable a, FloatVariable b) { a.Value /= b.Value; return a; }
		#endregion Utility Methodss
	}
}