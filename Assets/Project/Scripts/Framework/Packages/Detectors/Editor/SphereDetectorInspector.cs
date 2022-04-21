#if UNITY_EDITOR
using UnityEditor;

namespace Odders.Editor
{
	[CustomEditor(typeof(SphereDetector)), CanEditMultipleObjects]
	public class SphereDetectorInspector : DetectorInspector
	{
		#region Main Methods
		protected override void DrawDetector() => PropertyField("radius");
		#endregion Main Methods
	}
}
#endif