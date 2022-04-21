using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Odders;

namespace RhythmArmy
{
    [AddComponentMenu("Rhythm Army/Combinator"), RequireComponent(typeof(AudioSource))]
    public class Combinator : MonoBehaviour
    {
		#region Public Variables
		public int compas = 4;
		public float beatDuration = 1f;

		public AudioClip beatClip, accentClip, spawnClip;

		public Transform[] spawners;
		public Transform[] enemySpawners;

		public Combination[] combinations;
		#endregion Public Variables


		#region Private Variables
		[SerializeField]
		private List<DrumType> combo = new List<DrumType>();

		private int count;
		private bool canDrum;
		private AudioSource audioSource;

		#endregion Private Variables


		#region Unity Methods
		private void OnEnable()
		{
			RhythmController.OnBeat += OnBeat;
			Drum.OnDrum += OnDrum;
		}
		private void OnDisable()
		{
			RhythmController.OnBeat -= OnBeat;
			Drum.OnDrum -= OnDrum;
		}

		private void Awake() => audioSource = GetComponent<AudioSource>();
		#endregion Unity Methods


		#region Main Methods
		private void OnBeat()
		{
			count++;
			StartCoroutine(TimeCoroutine());
			StartCoroutine(BeatCoroutine());
		}

		private IEnumerator TimeCoroutine()
		{
			canDrum = true;

			float t = 0f;
			while ((t += Time.deltaTime) < beatDuration)
				yield return null;

			canDrum = false;
		}

		private IEnumerator BeatCoroutine()
		{
			audioSource.PlayOneShot(count >= compas ? accentClip : beatClip);

			yield return new WaitForSeconds(beatDuration / 2f);

			if (count >= compas)
			{
				count = 0;
				combo.Clear();
			}
		}

		private void OnDrum(DrumType drum)
		{
			if (!canDrum) return;

			combo.Add(drum);

			if (count >= compas && combo.Count == compas)
			{
				Combination combination = GetCombination(combo);

				if (combination != null && combo.Count >= compas)
				{
					audioSource.PlayOneShot(spawnClip);

					Spawn(combination.unitPrefab);
				}
			}
		}

		private void Spawn(GameObject unitPrefab)
		{
			DrumType line = combo.Last();
			Transform humanSpawn, enemySpawn;

			int i = -1;
			switch (line)
			{
				case DrumType.A: i = 0; break;
				case DrumType.B: i = 1; break;
				case DrumType.C: i = 2; break;
			}

			humanSpawn = spawners[i];
			enemySpawn = enemySpawners[i];

			if (humanSpawn != null)
			{
				GameObject obj = Instantiate(unitPrefab, humanSpawn.position, Quaternion.identity, humanSpawn);
				Unit unit = obj.GetComponent<Unit>();
				unit.SetDestination(enemySpawn);
			}
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

				if (match >= compas - 1)
					return combination;
			}

			return null;
		}
		#endregion Utility Methods
	}
}