using UnityEngine;
using Odders;

namespace RhythmArmy
{
	[CreateAssetMenu(fileName = "New Combination", menuName = "Rhythm Army/Combination")]
	public class Combination : ScriptableObject
	{
		#region Public Variables
		public GameObject unitPrefab;
		public DrumType[] sequence;
		#endregion Public Variables
	}
}