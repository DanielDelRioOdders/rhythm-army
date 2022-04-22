using UnityEngine;
using Odders;

namespace RythmMonsters
{
	[CreateAssetMenu(fileName = "New Combination", menuName = "Rythm Monsters/Combination")]
	public class Combination : ScriptableObject
	{
		#region Public Variables
		public GameObject unitPrefab;
		public DrumType[] sequence;
		#endregion Public Variables
	}
}