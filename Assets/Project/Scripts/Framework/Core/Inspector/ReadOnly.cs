#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

namespace Odders
{
	public class ReadOnlyAttribute : PropertyAttribute { }

	[CustomPropertyDrawer(typeof(ReadOnlyAttribute))]
	public class ReadOnlyPropertyDrawer : PropertyDrawer
	{
		#region Editor Methods
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			GUI.enabled = false;
			EditorGUI.PropertyField(position, property, label);
			GUI.enabled = true;
		}
		#endregion Editor Methods
	}
}
#endif