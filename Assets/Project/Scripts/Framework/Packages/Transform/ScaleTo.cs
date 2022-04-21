using UnityEngine;

namespace Odders
{
	[AddComponentMenu("Odders/Transform/Scale To")]
	public class ScaleTo : BaseObject
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
		public Vector3 TargetScale
		{
			get
			{
				Vector3 scale = target.localScale;

				if (constraintX) scale.x = LocalScale.x;
				if (constraintY) scale.y = LocalScale.y;
				if (constraintZ) scale.z = LocalScale.z;

				return scale;
			}
		}
		#endregion Properties


		#region Unity Methods
		protected virtual void Update()
		{
			if (target == null) return;

			Vector3 scale = Vector3.SmoothDamp(LocalScale, TargetScale, ref velocity, Smoothing);
			LocalScale = Vector3.MoveTowards(LocalScale, scale, Speed);
		}
		#endregion Unity Methods
	}
}