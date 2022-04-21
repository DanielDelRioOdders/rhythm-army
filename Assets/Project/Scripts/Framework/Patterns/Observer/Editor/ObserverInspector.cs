#if UNITY_EDITOR
using UnityEditor;

namespace Odders.Editor
{
	[CustomEditor(typeof(GameEvent), true), CanEditMultipleObjects]		public class GameEventInspector : BaseInspector { }
	[CustomEditor(typeof(Observer), true), CanEditMultipleObjects]		public class ObserverInspector : BaseInspector { }
}
#endif