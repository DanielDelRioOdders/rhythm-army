using UnityEngine;

namespace Odders
{
	[CreateAssetMenu(fileName = "New Int", menuName = "Odders/Variables/Int")]
	public class IntVariable : GlobalVariable<int>
	{
		#region Utility Methods
		public void Add(int value) => Value += value;

		public static IntVariable operator +(IntVariable a, int b) { a.Value += b; return a; }
		public static IntVariable operator -(IntVariable a, int b) { a.Value -= b; return a; }
		public static IntVariable operator *(IntVariable a, int b) { a.Value *= b; return a; }
		public static IntVariable operator /(IntVariable a, int b) { a.Value /= b; return a; }

		public static IntVariable operator +(IntVariable a, IntVariable b) { a.Value += b.Value; return a; }
		public static IntVariable operator -(IntVariable a, IntVariable b) { a.Value -= b.Value; return a; }
		public static IntVariable operator *(IntVariable a, IntVariable b) { a.Value *= b.Value; return a; }
		public static IntVariable operator /(IntVariable a, IntVariable b) { a.Value /= b.Value; return a; }
		#endregion Utility Methodss
	}
}