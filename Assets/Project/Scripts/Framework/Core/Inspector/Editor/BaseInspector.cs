#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using Enum = System.Enum;
using AnimBool = UnityEditor.AnimatedValues.AnimBool;

namespace Odders.Editor
{
	public abstract class BaseInspector : UnityEditor.Editor
	{
		#region Editor Methods
		public override void OnInspectorGUI() => DrawDefault();
		#endregion Editor Methods


		#region Main Methods
		protected virtual void DrawDefault(params string[] exclude)
		{
			if (exclude.Length == 0) exclude = new string[1] { "m_Script" };
			serializedObject.Update();
			DrawPropertiesExcluding(serializedObject, exclude);
			serializedObject.ApplyModifiedProperties();
		}
		#endregion Main Methods


		#region Utility Methods
		protected virtual void Space(float space = 0) => EditorGUILayout.Space(space == 0f ? 5f : Mathf.Abs(space));
		protected virtual void Label(string label) => EditorGUILayout.LabelField(label);
		protected virtual void Header(string label) { EditorGUILayout.LabelField(label, EditorStyles.boldLabel); }
		protected virtual void HelpBox(string msg, MessageType type = MessageType.None) { EditorGUILayout.HelpBox(msg, type); }
		protected virtual void Fade(AnimBool val, bool set, VoidDelegate f)
		{
			val.target = set;
			if (EditorGUILayout.BeginFadeGroup(val.faded)) f?.Invoke();
			EditorGUILayout.EndFadeGroup();
		}
		protected virtual void Button(string label, VoidDelegate f, float height = 20f) => Button(label, f, Color.white, height);
		protected virtual void Button(string label, VoidDelegate f, Color color, float height = 20f)
		{
			GUI.backgroundColor = color;
			if (GUILayout.Button(label, GUILayout.Height(height)))
			{
				Undo.RecordObject(target, "Change Button " + label);
				f?.Invoke();
				EditorUtility.SetDirty(target);
			}
			GUI.backgroundColor = Color.white;
		}
		protected virtual void ProgressBar(float val, string label, float height = 0)
		{
			Rect rect = EditorGUILayout.GetControlRect(false, height == 0 ? EditorGUIUtility.singleLineHeight : height);
			EditorGUI.ProgressBar(rect, val, label);
		}
		protected virtual bool FoldoutHeader(string label, ref bool val, VoidDelegate f = null)
		{
			if (val = EditorGUILayout.BeginFoldoutHeaderGroup(val, label)) f?.Invoke();
			EditorGUILayout.EndFoldoutHeaderGroup();
			return val;
		}
		protected virtual bool Foldout(string label, ref bool val)							=> val = EditorGUILayout.Foldout(val, label);

		protected virtual bool BoolField(string label, ref bool val)						=> Field(label, ref val, EditorGUILayout.Toggle);
		protected virtual int IntField(string label, ref int val)							=> Field(label, ref val, EditorGUILayout.IntField);
		protected virtual float FloatField(string label, ref float val)						=> Field(label, ref val, EditorGUILayout.FloatField);
		protected virtual string StringField(string label, ref string val)					=> Field(label, ref val, EditorGUILayout.TextField);
		protected virtual Vector2Int Vector2IntField(string label, ref Vector2Int val)		=> Field(label, ref val, EditorGUILayout.Vector2IntField);
		protected virtual Vector2 Vector2Field(string label, ref Vector2 val)				=> Field(label, ref val, EditorGUILayout.Vector2Field);
		protected virtual Vector3Int Vector3IntField(string label, ref Vector3Int val)		=> Field(label, ref val, EditorGUILayout.Vector3IntField);
		protected virtual Vector3 Vector3Field(string label, ref Vector3 val)				=> Field(label, ref val, EditorGUILayout.Vector3Field);
		protected virtual Color ColorField(string label, ref Color val)						=> Field(label, ref val, EditorGUILayout.ColorField);
		protected virtual void EnumField(string label, ref Enum val)						=> Field(label, ref val, EditorGUILayout.EnumPopup);
		protected virtual AnimationCurve CurveField(string label, ref AnimationCurve val)	=> Field(label, ref val, EditorGUILayout.CurveField);
		//protected virtual LayerMask LayerMaskField(string label, ref LayerMask val)		=> Field(label, ref val, LayerMaskDrawer.LayerMaskField);
		protected virtual void PropertyField(string property, string label = null)
		{
			serializedObject.Update();

			SerializedProperty p = serializedObject.FindProperty(property);
			if (p == null) return;

			if (string.IsNullOrEmpty(label)) EditorGUILayout.PropertyField(p);
			else EditorGUILayout.PropertyField(p, new GUIContent(label));

			if (GUI.changed) serializedObject.ApplyModifiedProperties();
		}

		private T Field<T>(string label, ref T val, FieldDelegate<T> f, GUILayoutOption[] options = null)
		{
			EditorGUI.BeginChangeCheck();
			T t = f(label, val, options);
			if (EditorGUI.EndChangeCheck())
			{
				Undo.RecordObject(target, "Change Field " + label);
				EditorUtility.SetDirty(target);
				val = t;
			}
			return t;
		}

		protected virtual void BeginIndent(float space = 16f)
		{
			EditorGUILayout.BeginHorizontal();
			GUILayout.Space(space);
			EditorGUILayout.BeginVertical();
		}
		protected virtual void EndIndent()
		{
			EditorGUILayout.EndVertical();
			EditorGUILayout.EndHorizontal();
		}
		#endregion Utility Methods
	}
}
#endif