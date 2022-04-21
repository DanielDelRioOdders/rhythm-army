using UnityEngine;
using UnityEngine.Events;

namespace Odders
{
	[AddComponentMenu("Odders/Detector/Collision Detector", 0)]
	public class CollisionDetector : Detector
	{
		#region Events
		public UnityEvent<Collision> OnEnterCollision { get; private set; }
		public UnityEvent<Collision> OnExitCollision { get; private set; }
		public UnityEvent<Collision2D> OnEnterCollision2D { get; private set; }
		public UnityEvent<Collision2D> OnExitCollision2D { get; private set; }
		#endregion Events


		#region Properties
		public override bool IsCollisionDetector => true;
		#endregion Properties


		#region Unity Methods
		protected virtual void OnCollisionEnter(Collision c)
		{
			OnEnterCollision?.Invoke(c);
			Process(c.collider, true);
		}
		protected virtual void OnCollisionExit(Collision c)
		{
			OnExitCollision?.Invoke(c);
			Process(c.collider, false);
		}

		protected virtual void OnCollisionEnter2D(Collision2D c)
		{
			OnEnterCollision2D?.Invoke(c);
			Process(c.collider, true);
		}
		protected virtual void OnCollisionExit2D(Collision2D c)
		{
			OnExitCollision2D?.Invoke(c);
			Process(c.collider, false);
		}


		protected virtual void OnTriggerEnter(Collider c) => Process(c, true);
		protected virtual void OnTriggerExit(Collider c) => Process(c, false);

		protected virtual void OnTriggerEnter2D(Collider2D c) => Process(c, true);
		protected virtual void OnTriggerExit2D(Collider2D c) => Process(c, false);
		#endregion Unity Methods


		#region Main Methods
		protected void Process<T>(T c, bool val)
		{
			if (!IsValidCollider(c)) return;

			switch (mode)
			{
				case Dimension._3D:
					Collider3Ds = val
						? Collider3Ds.Add(c as Collider)
						: Collider3Ds.Remove(c as Collider);
					break;

				case Dimension._2D:
					Collider2Ds = val
						? Collider2Ds.Add(c as Collider2D)
						: Collider2Ds.Remove(c as Collider2D);
					break;
			}

			GameObject o = GetObject(c);
			if (val) OnEnter?.Invoke(o);
			else OnExit?.Invoke(o);
		}
		#endregion Main Methods
	}
}