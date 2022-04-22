using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using Odders;

namespace RythmMonsters
{
    [AddComponentMenu("Rythm Monsters/Rhythm Controller"), RequireComponent(typeof(AudioSource))]
    public class Rhythm : MonoBehaviour
    {
		#region Static Variables
		public static Rhythm Instance;
		#endregion Static Variables


		#region Public Variables
		[Header("Parameters")]
		public float delay;
		public float rate = 1f;
		public int compas = 4;
		public int count;
		public bool canDrum;

		public AudioClip beatClip, accentClip;

		[Header("Events")]
		public UnityEvent onBeat;
		public UnityEvent onAccent;
		#endregion Public Variables


		#region Private Variables
		private AudioSource audioSource;
		#endregion Private Variables


		#region Events
		public static event VoidDelegate OnBeat, OnAccent;
		#endregion Events


		#region Unity Methods
		private void Awake()
		{
			Instance = this;

			audioSource = GetComponent<AudioSource>();
		}

		private void Start() => InvokeRepeating(nameof(InvokeBeat), delay, rate);
		#endregion Unity Methods


		#region Main Methods
		public void InvokeBeat()
		{
			if (!transform.parent.gameObject.activeSelf) return;

			count++;

			if (count >= compas)
			{
				Invoke(nameof(ResetCount), rate - 0.1f);

				OnAccent?.Invoke();
				onAccent.Invoke();

				audioSource.PlayOneShot(accentClip);
			}
			else
			{
				OnBeat?.Invoke();
				onBeat.Invoke();

				//audioSource.PlayOneShot(beatClip);
			}
			Debug.Log("Beat!");
			StopAllCoroutines();
			StartCoroutine(TimeCoroutine());
		}

		private IEnumerator TimeCoroutine()
		{
			canDrum = true;

			float t = 0f;
			while ((t += Time.deltaTime) < rate - 0.1f)
				yield return null;

			canDrum = false;
		}
		#endregion Main Methods


		#region Utility Methods
		private void ResetCount() => count = 0;
		#endregion Utility Methods
	}
}