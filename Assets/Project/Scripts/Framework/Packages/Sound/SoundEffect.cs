using UnityEngine;
using UnityEngine.Audio;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Odders
{
	[ExecuteInEditMode]
	[CreateAssetMenu(fileName = "New Sound Effect", menuName = "Odders/Sound Effect")]
	public class SoundEffect : ScriptableObject
	{
		#region Public Variables
		public bool dontDestroyOnLoad;
		public AudioMixerGroup output;

		[Range(0f, 60f)] public float delayIn;
		[Range(0f, 60f)] public float delayOut;

		public bool backward;
		[Range(0f, 1f)] public float start;
		[Range(0f, 1f)] public float end = 1f;

		public PlayMode playMode;
		public Cycle cycle;
		[Range(1, 10)] public int minCycles = 1;
		[Range(1, 10)] public int maxCycles = 1;
		public RecurrenceRate recurrence;

		public VariableType volumeType;
		[Range(0f, 1f)] public float volumeValue = 1f;
		public AnimationCurve volumeCurve = new AnimationCurve
		(
			new Keyframe(0f, 0f),
			new Keyframe(0.1f, 1f),
			new Keyframe(0.9f, 1f),
			new Keyframe(1f, 0f)
		);
		[Range(0f, 1f)] public float spatialBlend;
		public bool preVolume;

		public VariableType pitchType;
		public Vector2 pitchValue = Vector2.one;
		public AnimationCurve pitchCurve = new AnimationCurve
		(
			new Keyframe(0f, 1f),
			new Keyframe(0.1f, 0.75f),
			new Keyframe(0.2f, 1f),
			new Keyframe(0.3f, 0.75f),
			new Keyframe(0.4f, 1f),
			new Keyframe(0.5f, 0.75f),
			new Keyframe(0.6f, 1f),
			new Keyframe(0.7f, 0.75f),
			new Keyframe(0.8f, 1f),
			new Keyframe(0.9f, 0.75f),
			new Keyframe(1f, 1f)
		);
		public bool prePitch;

		public AudioClip[] clips;
		public SoundEffect[] sounds;

		public bool showGeneral, showTime, showDelay, showPlaylist, showVolume, showPitch;
		#endregion Public Variables


		#region Properties
		public AudioClip this[int i] => clips[i];
		public AudioClip this[string name] => clips[GetIndex(name)];

		public SoundController Controller { get; private set; }

		public bool Error => start >= end;
		#endregion Properties


		#region Unity Methods
#if UNITY_EDITOR
		private void OnEnable()
		{
			Controller = EditorUtility.
				CreateGameObjectWithHideFlags("SoundController", HideFlags.HideAndDontSave, typeof(AudioSource), typeof(SoundController)).
				GetComponent<SoundController>();
		}
		private void OnDisable() => DestroyImmediate(Controller.gameObject);
#endif
		#endregion Unity Methods


		#region Main Methods
		public void PlayRandomIn(AudioSource source)
		{
			if (!source.isPlaying) Play(source);
		}
		public void PlayRandom() => Play(clips.Random(), null);
		public void PlayIndex(int i) => Play(i, null);
		public void PlayClip(string name) => Play(name, null);

		public SoundController Play(AudioSource source = null) => Play(clips.Random(), source);
		public SoundController Play(int i, AudioSource source = null) => Play(this[i], source);
		public SoundController Play(string name, AudioSource source = null) => Play(this[name], source);
		public SoundController Play(AudioClip clip, AudioSource source = null)
		{
			if (clips.IsNullOrEmpty())
			{
				this.LogWarning($"Missing sound clips for {name}");
				return null;
			}

			bool destroy = false;
			if (source == null)
			{
				destroy = true;
				GameObject obj = new GameObject("Sound", typeof(AudioSource));
				source = obj.GetComponent<AudioSource>();

				if (dontDestroyOnLoad) obj.AddComponent<DontDestroyOnLoad>();
			}

			SoundController sfx = source.GetComponent<SoundController>();

			if (sfx != null) destroy = sfx.destroy;
			else sfx = source.gameObject.AddComponent<SoundController>();

			if (playMode != PlayMode.NONE && playMode != PlayMode.RANDOM && sfx.index == -1)
				clip = this[0];

			sfx.Play(this, clip, destroy);
			return sfx;
		}
		#endregion Main Methods


		#region Utility Methods
		public int GetIndex(string name) => clips.Index(i => i.name == name);
		#endregion Utility Methods
	}
}