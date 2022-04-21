using UnityEngine;
using UnityEngine.Events;
using Odders;

namespace RhythmArmy
{
	public enum DrumType { RED, GREEN, BLUE, PINK, A, B, C }

	public delegate void DrumDelegate(DrumType drum);

	[AddComponentMenu("Rhythm Army/Drum")]
	public class Drum : MonoBehaviour
	{
		#region Public Variables
		[Header("Parameters")]
		public DrumType drumType;

		[Header("Events")]
		public UnityEvent<DrumType> onDrum;
		#endregion Public Variables


		#region Events
		public static event DrumDelegate OnDrum;
		#endregion Events


		#region Unity Methods
#if UNITY_EDITOR
		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.Q)) InvokeDrumEvent(DrumType.RED);
			if (Input.GetKeyDown(KeyCode.W)) InvokeDrumEvent(DrumType.BLUE);
			if (Input.GetKeyDown(KeyCode.E)) InvokeDrumEvent(DrumType.GREEN);
			if (Input.GetKeyDown(KeyCode.R)) InvokeDrumEvent(DrumType.PINK);
			if (Input.GetKeyDown(KeyCode.Alpha1)) InvokeDrumEvent(DrumType.A);
			if (Input.GetKeyDown(KeyCode.Alpha2)) InvokeDrumEvent(DrumType.B);
			if (Input.GetKeyDown(KeyCode.Alpha3)) InvokeDrumEvent(DrumType.C);
		}
#endif
		#endregion Unity Methods


		#region Main Methods
		public void InvokeDrumEvent() => InvokeDrumEvent(drumType);
		public void InvokeDrumEvent(DrumType drumType)
		{
			if (drumType != this.drumType) return;

			onDrum?.Invoke(drumType);
			OnDrum?.Invoke(drumType);
		}
		#endregion Main Methods
	}
}