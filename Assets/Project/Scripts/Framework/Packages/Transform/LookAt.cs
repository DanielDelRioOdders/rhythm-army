using UnityEngine;

namespace Odders
{
	[AddComponentMenu("Odders/Transform/Look At")]
	public class LookAt : BaseObject
	{
		#region Public Variables
		public Transform target;

		[Min(0f)]
		public float speed = 10f;

		public bool reverse;
		#endregion Public Variables


		#region Properties
		protected float Speed => speed.Abs() * DeltaTime;
		protected Quaternion TargetRotation
		{
			get
			{
				Vector3 forward = target.position - Position;

				return Quaternion.LookRotation(reverse ? -forward : forward);
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