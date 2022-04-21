using UnityEngine;

namespace Odders
{
	[AddComponentMenu("Odders/Detector/Ray Detector", 3)]
	public class RayDetector : Detector
	{
		#region Public Variables
		[Min(0f)] public float distance = 1f;
		#endregion Public Variables


		#region Properties
		public float Distance => distance.Abs();
		#endregion Properties


		#region Main Methods
		protected override void UpdateDetector()
		{
			base.UpdateDetector();

			// 3D
			RaycastHit[] hits = Physics.RaycastAll(Position, Forward, Distance);
			Collider[] colliders = new Collider[hits.Length];
			for (int i = 0; i < hits.Length; i++)
			{
				RaycastHit hit = hits[i];
				colliders[i] = hit.collider;
			}
			Collider3Ds = Detect3D(colliders);

			// 2D
			RaycastHit2D[] hit2Ds = Physics2D.RaycastAll(Position, Down, Distance);
			Collider2D[] collider2Ds = new Collider2D[hit2Ds.Length];
			for (int i = 0; i < hit2Ds.Length; i++)
			{
				RaycastHit2D hit = hit2Ds[i];
				collider2Ds[i] = hit.collider;
			}
			Collider2Ds = Detect2D(collider2Ds);
		}

#if UNITY_EDITOR
		public override void Draw()
		{
			Vector3 target;

			switch (mode)
			{
				case Dimension._3D:
					target = Position + (Forward * Distance);

					Gizmos.color = color;
					Gizmos.DrawLine(Position, target);
					break;

				case Dimension._2D:
					target = Position + (Down * Distance);

					Gizmos.color = color;
					Gizmos.DrawLine(Position, target);
					break;
			}
		}
#endif
		#endregion Main Methods
	}
}