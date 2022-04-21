using UnityEngine;

namespace Odders
{
	[AddComponentMenu("Odders/Transform/Move To")]
	public class MoveTo : BaseObject
	{
		#region Public Variables
		public Transform target;

		[Min(0f)]
		public float speed = 10f;

		[Range(0f, 1f)]
		public float smoothing;

		public bool constraintX, constraintY, constraintZ;
		#endregion Public Variables


		#region Protected Variables
		protected Vector3 velocity;
		#endregion Protected Variables


		#region Properties
		protected float Speed => speed.Abs() * DeltaTime;
		protected float Smoothing => smoothing.Abs();
		protected Vector3 TargetPosition
		{
			get
			{
				Vector3 pos = target.position;

				if (constraintX) pos.x = Position.x;
				if (constraintY) pos.y = Position.y;
				if (constraintZ) pos.z = Position.z;

				return pos;
			}
		}
		#endregion Properties


		#region Unity Methods
		protected virtual void Update()
		{
			if (target == null) return;

			Vector3 position = Vector3.SmoothDamp(Position, TargetPosition, ref velocity, Smoothing);
			Position = Vector3.MoveTowards(Position, position, Speed);
		}
		#endregion Unity Methods
	}
}