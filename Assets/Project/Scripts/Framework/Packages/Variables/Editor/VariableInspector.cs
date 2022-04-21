#if UNITY_EDITOR
using UnityEditor;

namespace Odders.Editor
{
	[CustomEditor(typeof(BoolVariable), true), CanEditMultipleObjects]		public class BoolVariableInspector : BaseInspector { }
	[CustomEditor(typeof(IntVariable), true), CanEditMultipleObjects]		public class IntVariableInspector : BaseInspector { }
	[CustomEditor(typeof(FloatVariable), true), CanEditMultipleObjects]		public class FloatVariableInspector : BaseInspector { }
	[CustomEditor(typeof(StringVariable), true), CanEditMultipleObjects]	public class StringVariableInspector : BaseInspector { }
	[CustomEditor(typeof(Vector2Variable), true), CanEditMultipleObjects]	public class Vector2VariableInspector : BaseInspector { }
	[CustomEditor(typeof(Vector3Variable), true), CanEditMultipleObjects]	public class Vector3VariableInspector : BaseInspector { }
}
#endif