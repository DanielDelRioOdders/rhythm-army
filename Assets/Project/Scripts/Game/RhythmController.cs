using UnityEngine;
using UnityEngine.Events;
using Odders;

namespace RhythmArmy
{
    [AddComponentMenu("Rhythm Army/Rhythm Controller")]
    public class RhythmController : BaseObject
    {
		#region Public Variables
		[Header("Parameters")]
		public float delay;
		public float rate = 1f;

		[Header("Events")]
		public UnityEvent onBeat;
		#endregion Public Variables


		#region Events
		public static event VoidDelegate OnBeat;
		#endregion Events


		#region Unity Methods
		private void Start() => InvokeRepeating(nameof(InvokeBeat), delay, rate);
		#endregion Unity Methods


		#region Main Methods
		public void InvokeBeat()
		{
			OnBeat?.Invoke();
			onBeat.Invoke();
		}
		#endregion Main Methods
	}
}