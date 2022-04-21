using UnityEngine;
using Odders;

namespace RhythmArmy
{
	[AddComponentMenu("Rhythm Army/Unit")]
	public class Unit : MonoBehaviour
	{
		#region Public Variables
		public int health = 1;
		public int speed = 1;
		public int damage = 1;
		public float range = 1f;
		#endregion Public Variables


		#region Unity Methods
		protected virtual void OnEnable() => RhythmController.OnBeat += OnBeat;
		protected virtual void OnDisable() => RhythmController.OnBeat -= OnBeat;
		#endregion Unity Methods


		#region Main Methods
		protected virtual void OnBeat() { }
		#endregion Main Methods
	}
}