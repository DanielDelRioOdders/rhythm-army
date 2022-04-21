using UnityEngine;

namespace Odders
{
	[CreateAssetMenu(fileName = "New Vector2", menuName = "Odders/Variables/Vector2")]
	public class Vector2Variable : GlobalVariable<Vector2>
	{
		#region Utility Methods
		public void SetX(float x) => Value = new Vector2(x, Value.y);
		public void SetY(float y) => Value = new Vector2(Value.x, y);
		public void AddX(float x) => Value = new Vector2(Value.x + x, Value.y);
		public void AddY(float y) => Value = new Vector2(Value.x, Value.y + y);
		#endregion Utility Methods
	}
}