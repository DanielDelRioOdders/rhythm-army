#if UNITY_EDITOR
using UnityEditor;

namespace Odders.Editor
{
	[CustomEditor(typeof(RayDetector)), CanEditMultipleObjects]
	public class RayDetectorInspector : DetectorInspector
	{
		#region Main Methods
		protected override void DrawDetector() => PropertyField("distance");
		#endregion Main Methods
	}
}
#endif