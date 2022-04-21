#if UNITY_EDITOR
using UnityEditor;

namespace Odders.Editor
{
	[CustomEditor(typeof(BoxDetector)), CanEditMultipleObjects]
	public class BoxDetectorInspector : DetectorInspector
	{
		#region Main Methods
		protected override void DrawDetector() => PropertyField("size");
		#endregion Main Methods
	}
}
#endif