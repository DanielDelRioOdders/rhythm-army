using UnityEngine;
using Odders;

namespace RythmMonsters
{
	[AddComponentMenu("Rythm Monsters/IA")]
	public class IA : MonoBehaviour
	{
		#region Public Variables
		public string enemyLine;

		public Transform[] spawners;
		public Transform[] enemySpawners;

		public Combination[] combinations;
		#endregion Public Variables


		#region Private Variables
		private int lastLine;
		#endregion Private Variables


		#region Unity Methods
		private void OnEnable() => Rhythm.OnAccent += OnAccent;
		private void OnDisable() => Rhythm.OnAccent -= OnAccent;
		#endregion Unity Methods


		#region Main Methods
		private void OnAccent()
		{
			if (Random.Range(0, 4) == 0) return;

			int l;
			do
			{
				l = Random.Range(0, 3);

			} while (l == lastLine);
			lastLine = l;

			DrumType line = DrumType.B;
			switch (l)
			{
				case 0: line = DrumType.A; break;
				case 1: line = DrumType.B; break;
				case 2: line = DrumType.C; break;
			}

			Combination combination = combinations.Random();
			Spawn(combination.unitPrefab, line);
		}

		private void Spawn(GameObject unitPrefab, DrumType line)
		{
			Transform spawn, enemySpawn;

			int i = -1;
			switch (line)
			{
				case DrumType.A: i = 0; break;
				case DrumType.B: i = 1; break;
				case DrumType.C: i = 2; break;
			}

			spawn = spawners[i];
			enemySpawn = enemySpawners[i];

			if (spawn != null)
			{
				GameObject obj = Instantiate(unitPrefab, spawn.position, spawn.rotation, spawn);
				Unit unit = obj.GetComponent<Unit>();
				unit.SetDestination(enemySpawn);
				unit.tag = tag;
				unit.line = enemyLine;
			}
		}
		#endregion Main Methods
	}
}