#if UNITY_EDITOR
using UnityEditor;

namespace Odders.Editor
{
	[CustomEditor(typeof(SoundController), true), CanEditMultipleObjects] public class SoundControllerInspector : BaseInspector { }

	[CustomEditor(typeof(SoundEffect), true), CanEditMultipleObjects]
	public class SoundEffectInspector : BaseInspector
	{
		#region Properties
		private SoundEffect Script => target as SoundEffect;
		private SoundController Controller => Script.Controller.GetComponent<SoundController>();
		#endregion Properties


		#region Editor Methods
		public override void OnInspectorGUI()
		{
			if (FoldoutHeader("General", ref Script.showGeneral))
			{
				PropertyField("dontDestroyOnLoad");
				PropertyField("output");
			}

			if (FoldoutHeader("Time", ref Script.showTime))
			{
				PropertyField("backward");
				PropertyField("start");
				PropertyField("end");

				if (Script.Error) HelpBox("Start must be before than end.", MessageType.Warning);
			}

			if (FoldoutHeader("Delay", ref Script.showDelay))
			{
				PropertyField("delayIn", "In");
				PropertyField("delayOut", "Out");
			}

			if (FoldoutHeader("Playlist", ref Script.showPlaylist))
			{
				PropertyField("playMode", "Mode");

				if (Script.playMode != PlayMode.NONE && Script.playMode != PlayMode.ONCE)
				{
					PropertyField("cycle", "Cycles");

					if (Script.cycle == Cycle.FINITE)
					{
						PropertyField("minCycles", "Min");
						PropertyField("maxCycles", "Max");
					}

					if (Script.playMode == PlayMode.RANDOM)
						PropertyField("recurrence");
				}
			}

			if (FoldoutHeader("Volume", ref Script.showVolume))
			{
				PropertyField("volumeType", "Type");
				switch (Script.volumeType)
				{
					case VariableType.STATIC: PropertyField("volumeValue", "Value"); break;
					case VariableType.DYNAMIC:
						PropertyField("volumeCurve", "Curve");
						PropertyField("preVolume", "Preprocess");
						break;
				}

				PropertyField("spatialBlend");
			}

			if (FoldoutHeader("Pitch", ref Script.showPitch))
			{
				PropertyField("pitchType", "Type");
				switch (Script.pitchType)
				{
					case VariableType.STATIC: PropertyField("pitchValue", "Value"); break;
					case VariableType.DYNAMIC:
						PropertyField("pitchCurve", "Curve");
						PropertyField("prePitch", "Preprocess");
						break;
				}
			}

			PropertyField("clips");
			PropertyField("sounds");

			Space();
			EditorGUILayout.BeginHorizontal();
			Button("Play", Play, Controller.Source.isPlaying ? Colors.Blue : Colors.Green, 30f);
			Button("Stop", Stop, Colors.Red, 30f);
			EditorGUILayout.EndHorizontal();

			Repaint();

			//Space();
			//if (Previewer.clip != null && Previewer.time > 0f)
			//{
			//	float length = Previewer.clip.length;
			//	float time = Previewer.time;
			//	float percent = time / length;
			//	string maxMiliseconds = Timer.ToMilliseconds(length).ToString("000");
			//	string maxSeconds = Timer.ToSeconds(length).ToString("00");
			//	string maxMinutes = Timer.ToMinutes(length).ToString("00");
			//	string milliseconds = Timer.ToMilliseconds(time).ToString("000");
			//	string seconds = Timer.ToSeconds(time).ToString("00");
			//	string minutes = Timer.ToMinutes(time).ToString("00");
			//	ProgressBar(percent, $"{minutes}:{seconds}:{milliseconds} / {maxMinutes}:{maxSeconds}:{maxMiliseconds}");
			//	Label(Previewer.clip.name);
			//}
		}
		#endregion Editor Methods


		#region Utility Methods
		private void Play()
		{
			Controller.index = -1;
			Script.Play(Controller.Source);
		}
		private void Stop() => Controller.Stop();
		#endregion Utility Methods
	}
}
#endif