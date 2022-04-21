using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Odders
{
	[AddComponentMenu("Odders/Detector/Sphere Detector", 2)]
	public class SphereDetector : Detector
	{
		#region Public Variables
		[Min(0f)] public float radius = 0.5f;
		#endregion Public Variables


		#region Properties
		public float Radius => radius.Abs();
		#endregion Properties


		#region Main Methods
		protected override void UpdateDetector()
		{
			base.UpdateDetector();

			Collider3Ds = Detect3D(Physics.OverlapSphere(Position, Radius));
			Collider2Ds = Detect2D(Physics2D.OverlapCircleAll(Position, Radius));
		}

#if UNITY_EDITOR
		public override void Draw()
		{
			switch (mode)
			{
				case Dimension._3D:
					Gizmos.color = color;
					Gizmos.DrawWireSphere(Position, Radius);
					break;

				case Dimension._2D:
					Handles.color = color;
					Handles.DrawWireDisc(Position, Vector3.forward, Radius);
					break;
			}
		}
#endif
		#endregion Main Methods
	}
}