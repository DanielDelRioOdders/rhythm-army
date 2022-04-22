using System.Collections.Generic;
using UnityEngine;
using Odders;

namespace RythmMonsters
{
    [AddComponentMenu("Rythm Monsters/Human"), RequireComponent(typeof(AudioSource))]
    public class Human : MonoBehaviour
    {
		#region Public Variables
		public AudioClip spawnClip;
		public string enemyLine;

		public Transform[] spawners;
		public Transform[] enemySpawners;

		public Combination[] combinations;
		#endregion Public Variables


		#region Private Variables
		[SerializeField]
		private List<DrumType> combo = new List<DrumType>();

		private AudioSource audioSource;

		private float Rate => Rhythm.Instance.rate;
		private int Compas => Rhythm.Instance.compas;
		private bool CanDrum => Rhythm.Instance.canDrum;
		private int Count => Rhythm.Instance.count;
		#endregion Private Variables


		#region Unity Methods
		private void OnEnable()
		{
			Rhythm.OnAccent += OnAccent;
			Drum.OnDrum += OnDrum;
		}
		private void OnDisable()
		{
			Rhythm.OnAccent -= OnAccent;
			Drum.OnDrum -= OnDrum;
		}

		private void Awake() => audioSource = GetComponent<AudioSource>();
		#endregion Unity Methods


		#region Main Methods
		private void OnAccent() => Invoke(nameof(ResetCombo), Rate - 0.1f);

		private void OnDrum(DrumType drum)
		{
			if (!CanDrum) return;

			combo.Add(drum);

			if (Count >= Compas && combo.Count == Compas)
			{
				Combination combination = GetCombination(combo);

				if (combination != null && combo.Count >= Compas)
					Spawn(combination.unitPrefab, combo.Last());
			}
		}

		private void Spawn(GameObject unitPrefab, DrumType line)
		{
			Transform spawn, enemySpawn;

			int i = 1;
			switch (line)
			{
				case DrumType.A: i = 0; break;
				case DrumType.B: i = 1; break;
				case DrumType.C: i = 2; break;
			}

			spawn = spawners[i];
			enemySpawn = enemySpawners[i];

			GameObject obj = Instantiate(unitPrefab, spawn.position, spawn.rotation, spawn);
			Unit unit = obj.GetComponent<Unit>();
			unit.SetDestination(enemySpawn);
			unit.tag = tag;
			unit.line = enemyLine;

			audioSource.PlayOneShot(spawnClip);
		}
		#endregion Main Methods


		#region Utility Methods
		private Combination GetCombination(List<DrumType> list)
		{
			foreach (Combination combination in combinations)
			{
				int match = 0;
				for (int i = 0; i < combination.sequence.Length; i++)
				{
					DrumType a = combination.sequence[i];
					DrumType b = list[i];

					if (a == b) match++;
				}

				if (match >= Compas - 1)
					return combination;
			}

			return null;
		}

		private void ResetCombo() => combo.Clear();
		#endregion Utility Methods
	}
}