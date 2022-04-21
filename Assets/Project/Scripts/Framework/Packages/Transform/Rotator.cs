using UnityEngine;

namespace Odders
{
	[AddComponentMenu("Odders/Transform/Rotator")]
	public class Rotator : BaseObject
	{
		#region Public Variables
		public Vector3 rotation = Vector3.up * 100f;
		#endregion Public Variables


		#region Properties
		protected Vector3 TargetRotation => rotation * DeltaTime;
		#endregion Properties


		#region Unity Methods
		protected virtual void Update() => transform.Rotate(TargetRotation);
		#endregion Unity Methods
	}
}