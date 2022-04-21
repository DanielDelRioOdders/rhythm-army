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

			if (count >= compas)
			{
				Combination combination = GetCombination(combo);

				if (combination != null && combo.Count >= compas)
				{
					//Spawn(combination);

					audioSource.PlayOneShot(spawnClip);
					Debug.Log(combination.name);
				}
			}
		}

		private void Spawn(Combination combination)
		{
			DrumType line = combination.sequence.Last();
			Transform spawner = null;

			switch (line)
			{
				case DrumType.A: spawner = spawners[0]; break;
				case DrumType.B: spawner = spawners[1]; break;
				case DrumType.C: spawner = spawners[2]; break;
			}

			if (spawner != null)
			{
				GameObject unitPrefab = combination.unitPrefab;
				Instantiate(unitPrefab, spawner.position, Quaternion.identity);
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