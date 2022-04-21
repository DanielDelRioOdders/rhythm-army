#if UNITY_EDITOR
using UnityEditor;

namespace Odders.Editor
{
	[CustomEditor(typeof(ObjectPool), true), CanEditMultipleObjects]
	public class ObjectPoolInspector : BaseInspector { }
}
#endif