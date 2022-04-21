using UnityEngine;
using UnityEngine.Events;

namespace Odders
{
	public abstract class GlobalVariable<T> : ScriptableObject
	{
		#region Private Variables
		[SerializeField] private bool debug, reset = true;
		[SerializeField] private T defaultValue;
		[SerializeField] private T value;
		#endregion Private Variables


		#region Events
		[HideInInspector] public UnityEvent OnValueChanged;
		#endregion Events


		#region Properties
		public T Value
		{
			get => value;
			set
			{
				this.value = value;
				InvokeOnValueChanged();
			}
		}
		#endregion Properties


		#region Unity Methods
		private void OnDisable()
		{
			if (reset) value = defaultValue;
		}

		private void OnValidate() => InvokeOnValueChanged();
		#endregion Unity Methods


		#region Main Methods
		private void InvokeOnValueChanged()
		{
			OnValueChanged?.Invoke();

			if (debug) this.Log(value);
		}
		#endregion Main Methods


		#region Utility Methods
		public void Set(T value) => Value = value;
		#endregion Utility Methods
	}
}