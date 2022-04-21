using UnityEngine;

namespace Odders
{
	[CreateAssetMenu(fileName = "New Vector3", menuName = "Odders/Variables/Vector3")]
	public class Vector3Variable : GlobalVariable<Vector3>
	{
		#region Utility Methods
		public void SetX(float x) => Value = new Vector3(x, Value.y, Value.z);
		public void SetY(float y) => Value = new Vector3(Value.x, y, Value.z);
		public void SetZ(float z) => Value = new Vector3(Value.x, Value.y, z);
		public void AddX(float x) => Value = new Vector3(Value.x + x, Value.y, Value.z);
		public void AddY(float y) => Value = new Vector3(Value.x, Value.y + y, Value.z);
		public void AddZ(float z) => Value = new Vector3(Value.x, Value.y, Value.z + z);
		#endregion Utility Methods
	}
}