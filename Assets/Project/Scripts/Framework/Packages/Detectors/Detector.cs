using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace Odders
{
	public abstract class Detector : CollisionShape
	{
		#region Const Variables
		private const float REFRESH_RATE = 0.03f;
		#endregion Const Variables


		#region Public Variables
		[HideInInspector] public int total;

		public DetectionMode whatToDetect;
		public LayerMask _layer = 1;
		public string _component, _name;
		public string _tag;
		#endregion Public Variables


		#region Private Variables
		private Collider[] lastCollider3Ds = new Collider[0];
		private Collider2D[] lastCollider2Ds = new Collider2D[0];
		#endregion Private Variables


		#region Events
		public UnityEvent<GameObject> OnEnter, OnExit;
		#endregion Events


		#region Properties
		public virtual bool IsCollisionDetector { get; }
		#endregion Properties


		#region Unity Methods
		protected virtual void Awake() => InvokeRepeating(nameof(UpdateDetector), 0f, REFRESH_RATE);
		#endregion Unity Methods


		#region Main Methods
		protected virtual void UpdateDetector()
		{
			total = mode == Dimension._3D
					? Collider3Ds.Length
					: Collider2Ds.Length;
		}

		protected Collider[] Detect3D(Collider[] colliders)
		{
			colliders = colliders.Where(i => IsValidCollider(i)).ToArray();

			foreach (Collider c in lastCollider3Ds)
				if (!colliders.Contains(c))
					OnExit?.Invoke(GetObject(c));

			foreach (Collider c in colliders)
				if (!lastCollider3Ds.Contains(c) && IsValidCollider(c))
					OnEnter?.Invoke(GetObject(c));

			lastCollider3Ds = colliders;
			return colliders;
		}
		protected Collider2D[] Detect2D(Collider2D[] colliders)
		{
			colliders = colliders.Where(i => IsValidCollider(i)).ToArray();

			foreach (Collider2D c in lastCollider2Ds)
				if (!colliders.Contains(c))
					OnExit?.Invoke(GetObject(c));

			foreach (Collider2D c in colliders)
				if (!lastCollider2Ds.Contains(c) && IsValidCollider(c))
					OnEnter?.Invoke(GetObject(c));

			lastCollider2Ds = colliders;
			return colliders;
		}
		#endregion Main Methods


		#region Utility Methods
		public virtual bool IsValidCollider<T>(T c)
		{
			GameObject o = GetObject(c);

			if (o != null)
			{
				switch (whatToDetect)
				{
					case DetectionMode.ANYTHING:	return true;
					case DetectionMode.LAYER:		return _layer == (_layer | (1 << o.layer));
					case DetectionMode.TAG:			return !string.IsNullOrEmpty(_tag) && o.CompareTag(_tag);
					case DetectionMode.COMPONENT:	return o.GetComponent(_component);
					case DetectionMode.NAME:		return o.name == _name;
				}
			}
			return false;
		}
		#endregion Utility Methods
	}
}