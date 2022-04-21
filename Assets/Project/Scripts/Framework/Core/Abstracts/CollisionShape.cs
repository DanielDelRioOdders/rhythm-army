using UnityEngine;

namespace Odders
{
	public abstract class CollisionShape : Drawing
	{
		#region Public Variables
		public Dimension mode;
		#endregion Public Variables


		#region Properties
		public virtual Collider[] Collider3Ds { get; protected set; } = new Collider[0];
		public virtual Collider2D[] Collider2Ds { get; protected set; } = new Collider2D[0];
		#endregion Properties


		#region Utility Methods
		protected GameObject GetObject<T>(T c)
		{
			switch (mode)
			{
				case Dimension._3D: if (IsCollider3D(c)) return (c as Collider).gameObject; break;
				case Dimension._2D: if (IsCollider2D(c)) return (c as Collider2D).gameObject; break;
			}
			return null;
		}
		protected bool IsCollider3D<T>(T c) => c.GetType().BaseType == typeof(Collider);
		protected bool IsCollider2D<T>(T c) => c.GetType().BaseType == typeof(Collider2D);
		#endregion Utility Methods
	}
}