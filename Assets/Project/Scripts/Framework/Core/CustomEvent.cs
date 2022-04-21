using UnityEngine;
using UnityEngine.Events;

namespace Odders
{
	[System.Serializable]
	public class CustomEvent
	{
		#region Events
		[SerializeField] private UnityEvent Event;
		#endregion Events


		#region Main Methods
		public virtual void Invoke() => Event?.Invoke();
		public virtual void Add(UnityAction call) => Event.AddListener(call);
		public virtual void Remove(UnityAction call) => Event.RemoveListener(call);
		public virtual void RemoveAll() => Event.RemoveAllListeners();
		#endregion Main Methods
	}

	[System.Serializable]
	public class CustomEvent<T>
	{
		#region Events
		[SerializeField] private UnityEvent<T> Event;
		#endregion Events


		#region Main Methods
		public virtual void Invoke(T t) => Event?.Invoke(t);
		public virtual void Add(UnityAction<T> call) => Event.AddListener(call);
		public virtual void Remove(UnityAction<T> call) => Event.RemoveListener(call);
		public virtual void RemoveAll() => Event.RemoveAllListeners();
		#endregion Main Methods
	}

	[System.Serializable]
	public class CustomEvent<T1, T2>
	{
		#region Events
		[SerializeField] private UnityEvent<T1, T2> Event;
		#endregion Events


		#region Main Methods
		public virtual void Invoke(T1 t1, T2 t2) => Event?.Invoke(t1, t2);
		public virtual void Add(UnityAction<T1, T2> call) => Event.AddListener(call);
		public virtual void Remove(UnityAction<T1, T2> call) => Event.RemoveListener(call);
		public virtual void RemoveAll() => Event.RemoveAllListeners();
		#endregion Main Methods
	}

	[System.Serializable]
	public class CustomEvent<T1, T2, T3>
	{
		#region Events
		[SerializeField] private UnityEvent<T1, T2, T3> Event;
		#endregion Events


		#region Main Methods
		public virtual void Invoke(T1 t1, T2 t2, T3 t3) => Event?.Invoke(t1, t2, t3);
		public virtual void Add(UnityAction<T1, T2, T3> call) => Event.AddListener(call);
		public virtual void Remove(UnityAction<T1, T2, T3> call) => Event.RemoveListener(call);
		public virtual void RemoveAll() => Event.RemoveAllListeners();
		#endregion Main Methods
	}
}