using UnityEngine;
using UnityEngine.Events;

namespace Odders
{
	/// <summary>
	/// 
	/// </summary>
	[AddComponentMenu("Odders/Patterns/Observer")]
	public class Observer : BaseObject
	{
		#region Public Variables
		public GameEvent gameEvent;
		#endregion Public Variables


		#region Events
		public UnityEvent OnTrigger;
		#endregion Events


		#region Unity Methods
		protected override void OnEnable()
		{
			base.OnEnable();
			gameEvent.Add(this);
		}
		protected override void OnDisable()
		{
			base.OnDisable();
			gameEvent.Remove(this);
		}
		#endregion Unity Methods


		#region Main Methods
		public virtual void Invoke()
		{
			if (!enabled || !gameObject.activeSelf) return;

			OnTrigger?.Invoke();
		}
		#endregion Main Methods
	}
}