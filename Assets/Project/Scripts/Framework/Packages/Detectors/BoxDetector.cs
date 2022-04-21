using UnityEngine;

namespace Odders
{
	[AddComponentMenu("Odders/Detector/Box Detector", 1)]
	public class BoxDetector : Detector
	{
		#region Public Variables
		public Vector3 size = Vector3.one;
		#endregion Public Variables


		#region Properties
		public Vector3 Size => size.Abs();
		#endregion Properties


		#region Main Methods
		protected override void UpdateDetector()
		{
			base.UpdateDetector();

			Collider3Ds = Detect3D(Physics.OverlapBox(Position, Vector3.Scale(LocalScale, Size / 2), Rotation));
			Collider2Ds = Detect2D(Physics2D.OverlapBoxAll(Position, Size * (Vector2)LocalScale, EulerAngles.z));
		}

#if UNITY_EDITOR
		public override void Draw()
		{
			switch (mode)
			{
				case Dimension._3D:
					Gizmos.color = color;
					Gizmos.matrix = LocalToWorldMatrix;
					Gizmos.DrawWireCube(Vector3.zero, Size);
					break;

				case Dimension._2D:
					Gizmos.color = color;
					Gizmos.matrix = LocalToWorldMatrix;
					Gizmos.DrawWireCube(Vector3.zero, Size.SetZ(0f));
					break;
			}
		}
#endif
		#endregion Main Methods
	}
}