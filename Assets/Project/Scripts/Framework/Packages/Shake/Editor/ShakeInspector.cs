#if UNITY_EDITOR
using UnityEditor;

namespace Odders.Editor
{
	[CustomEditor(typeof(Shaker), true), CanEditMultipleObjects] public class ShakerInspector : BaseInspector { }

	[CustomEditor(typeof(ShakeData), true), CanEditMultipleObjects]
	public class ShakeDataInspector : BaseInspector
	{
		#region Properties
		private ShakeData Script => target as ShakeData;
		#endregion Properties


		#region Editor Methods
		public override void OnInspectorGUI()
		{
			PropertyField("target");
			PropertyField("amplitude");
			PropertyField("frequency");
			PropertyField("duration");
			PropertyField("curve");

			if (Foldout("Constraints", ref Script.showConstraints))
			{
				PropertyField("constraintX", "X");
				PropertyField("constraintY", "Y");
				PropertyField("constraintZ", "Z");
			}
		}
		#endregion Editor Methods
	}
}
#endif