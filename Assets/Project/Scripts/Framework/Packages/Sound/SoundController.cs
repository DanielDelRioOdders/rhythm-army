using UnityEngine;
using UnityEngine.Events;
using Coroutine = System.Collections.IEnumerator;

namespace Odders
{
	//TODO: Refactoring

	[ExecuteInEditMode, RequireComponent(typeof(AudioSource))]
	public class SoundController : BaseObject
	{
		#region Public Variables
		[HideInInspector] public bool destroy;
		[HideInInspector] public int index = -1;
		#endregion Public Variables


		#region Private Variables
		private bool isRunning, inPingPong;
		private float start, end;
		private int cycle, maxCycle;
		private AudioClip[] avaiableClips = new AudioClip[0];
		#endregion Private Variables


		#region Events
		public UnityEvent<SoundController> OnPlay = new UnityEvent<SoundController>();
		public UnityEvent<SoundController> OnStop = new UnityEvent<SoundController>();
		#endregion Events


		#region Properties
		public SoundEffect Sound { get; private set; }
		public AudioSource Source { get; private set; }

		private float Duration => Source.clip.length;
		private bool IsBackward => Sound.backward;
		private float StartTime => IsBackward ? end - 0.01f : start;
		private float EndTime => IsBackward ? start : end;
		private bool HasFinished
			=> (Source.time == 0f && !Source.isPlaying && isRunning)
			|| (!IsBackward && Source.time > EndTime)
			|| (IsBackward && Source.time < EndTime);

		private bool NextCycle
		{
			get
			{
				if (Sound.cycle == Cycle.INFINITE)
					return true;

				if (++cycle >= maxCycle)
				{
					cycle = 0;
					NextSound();

					return false;
				}

				return true;
			}
		}
		#endregion Properties


		#region Unity Methods
		protected override void OnEnable()
		{
			base.OnEnable();
			Source = GetComponent<AudioSource>();
		}

		protected override void OnDestroy()
		{
			base.OnDisable();
			Stop();
		}
		#endregion Unity Methods


		#region Main Methods
		public void Play(SoundEffect sound, AudioClip clip, bool destroy = false)
		{
			if (sound.Error)
			{
				if (destroy) Kill();
				else Stop();

				return;
			}

			Stop();
			StartEditorCoroutine(InCoroutine(sound, clip, destroy));
		}

		public void Stop()
		{
			Source.Stop();
			RunEditor(StopAllCoroutines, StopAllEditorCoroutines);
		}
		private void Kill()
		{
			Stop();
			RunEditor(Destroy, DestroyImmediate);
		}

		private Coroutine InCoroutine(SoundEffect sound, AudioClip clip, bool destroy = false)
		{
			if (index == -1)
			{
				int min = sound.minCycles;
				int max = sound.maxCycles;
				maxCycle = Random.Range(min, max);
			}

			Sound = sound;
			Source.outputAudioMixerGroup = sound.output;
			this.destroy = destroy;

			if (sound.playMode == PlayMode.RANDOM && sound.recurrence == RecurrenceRate.LOW)
			{
				if (avaiableClips.Length <= 0)
				{
					AudioClip[] clips = new AudioClip[sound.clips.Length];
					sound.clips.CopyTo(clips, 0);
					clips.Shuffle();

					avaiableClips = new AudioClip[0];
					while (avaiableClips.Length < maxCycle)
						avaiableClips = avaiableClips.Add(clips);
				}

				clip = avaiableClips.Random();
				avaiableClips = avaiableClips.Remove(clip);
			}

			Source.clip = clip;
			index = Sound.GetIndex(Source.clip.name);

			Source.spatialBlend = Sound.spatialBlend;

			start = sound.start * Duration;
			end = sound.end * Duration;
			Source.time = StartTime;

			AnimationCurve volumeCurve = sound.volumeType == VariableType.DYNAMIC ? sound.volumeCurve : null;
			AnimationCurve pitchCurve = sound.pitchType == VariableType.DYNAMIC ? sound.pitchCurve : null;

			float delay = sound.delayIn;
			yield return new WaitForSecondsRealtime(delay);

			SetDynamicValue(volumeCurve, SetVolume, sound.volumeValue, sound.preVolume);
			SetDynamicValue(pitchCurve, SetPitch, sound.pitchValue.Random(), sound.prePitch);
			StartEditorCoroutine(SFXUpdate());

			Source.Play();
			OnPlay?.Invoke(this);
			isRunning = true;
		}
		private Coroutine OutCoroutine()
		{
			OnStop?.Invoke(this);

			float delay = Sound.delayOut;
			yield return new WaitForSecondsRealtime(delay);

			Stop();

			if (Sound.playMode != PlayMode.NONE) NextClip();
			else NextSound();
		}

		private Coroutine SFXUpdate()
		{
			while (true)
			{
				if (HasFinished && isRunning)
				{
					isRunning = false;
					StartEditorCoroutine(OutCoroutine());
				}

				yield return null;
			}
		}

		private void NextClip()
		{
			int index = this.index;
			int nextIndex = index + 1;
			int previousIndex = index - 1;
			int length = Sound.clips.Length;

			switch (Sound.playMode)
			{
				default:
				case PlayMode.NONE: this.index = -1; break;

				case PlayMode.ONCE:
					if (nextIndex <= length - 1) PlayIndex(nextIndex);
					else
					{
						this.index = -1;
						NextSound();
					}
					break;

				case PlayMode.LOOP:
					if (index >= length - 1 && !NextCycle) return;

					if (nextIndex <= length - 1) PlayIndex(nextIndex);
					else PlayIndex(0);
					break;

				case PlayMode.PING_PONG:
					if (!inPingPong)
					{
						if (nextIndex > length - 1)
						{
							inPingPong = true;
							PlayIndex(previousIndex);
						}
						else PlayIndex(nextIndex);
					}
					else
					{
						if (previousIndex < 0)
						{
							inPingPong = false;

							if (!NextCycle) return;

							PlayIndex(nextIndex);
						}
						else PlayIndex(previousIndex);
					}
					break;

				case PlayMode.RANDOM:
					if (!NextCycle) return;

					int i = Random.Range(0, length);

					if (Sound.recurrence == RecurrenceRate.NORMAL)
						while (length >= 2 && Sound[i] == Source.clip)
							i = Random.Range(0, length);

					PlayIndex(i);
					break;
			}
		}
		private void NextSound()
		{
			if (Sound.sounds != null && Sound.sounds.Length > 0)
			{
				Stop();
				Sound.sounds.Random().Play(Source);
			}
			else if (destroy) Kill();
		}
		#endregion Main Methods


		#region Utility Methods
		private void SetDynamicValue(AnimationCurve curve, FloatDelegate function, float defaultValue, bool preprocess)
		{
			if (curve != null) StartEditorCoroutine(CurveCoroutine(curve, function, preprocess));
			else function(defaultValue);
		}
		private Coroutine CurveCoroutine(AnimationCurve curve, FloatDelegate function, bool preprocess)
		{
			while (!HasFinished)
			{
				float time = preprocess ? Source.time : Source.time - StartTime;
				float duration = preprocess ? Duration : EndTime - StartTime;

				if (IsBackward && preprocess) time = Duration - time;

				function(curve.Evaluate(time / duration));
				yield return null;
			}
		}

		private void SetVolume(float v) => Source.volume = Mathf.Clamp01(v);
		private void SetPitch(float p)
		{
			p = Mathf.Clamp(p, 0.1f, 3f);

			if (IsBackward) p *= -1;

			Source.pitch = p;
		}

		private void Destroy() => Destroy(gameObject);
		private void DestroyImmediate() => DestroyImmediate(gameObject);

		private void PlayIndex(int i)
		{
			if (i < 0 || i > Sound.clips.Length - 1) return;

			Sound.Play(i, Source);
		}
		#endregion Utility Methods
	}
}