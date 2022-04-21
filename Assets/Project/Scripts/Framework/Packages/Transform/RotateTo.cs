using UnityEngine;

namespace Odders
{
	[AddComponentMenu("Odders/Transform/Rotate To")]
	public class RotateTo : BaseObject
	{
		#region Public Variables
		public Transform target;

		[Min(0f)]
		public float speed = 10f;

		public bool constraintX, constraintY, constraintZ;
		#endregion Public Variables


		#region Properties
		protected float Speed => speed.Abs() * DeltaTime;
		protected Quaternion TargetRotation
		{
			get
			{
				Vector3 rot = target.eulerAngles;

				if (constraintX) rot.x = EulerAngles.x;
				if (constraintY) rot.y = EulerAngles.y;
				if (constraintZ) rot.z = EulerAngles.z;

				return Quaternion.Euler(rot);
			}
		}
		#endregion Properties


		#region Unity Methods
		protected virtual void Update()
		{
			if (target == null) return;

			Rotation = Quaternion.Slerp(Rotation, TargetRotation, Speed);
		}
		#endregion Unity Methods
	}
}