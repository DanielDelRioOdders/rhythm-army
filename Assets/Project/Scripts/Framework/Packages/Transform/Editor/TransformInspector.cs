#if UNITY_EDITOR
using UnityEditor;

namespace Odders.Editor
{
	[CustomEditor(typeof(Rotator), true), CanEditMultipleObjects]		public class RotatorInspector : BaseInspector { }
	[CustomEditor(typeof(LookAt), true), CanEditMultipleObjects]		public class LookAtInspector : BaseInspector { }
	[CustomEditor(typeof(MoveTo), true), CanEditMultipleObjects]		public class MoveToInspector : TransformToInspector<MoveTo> { }
	[CustomEditor(typeof(RotateTo), true), CanEditMultipleObjects]		public class RotateToInspector : TransformToInspector<RotateTo> { }
	[CustomEditor(typeof(ScaleTo), true), CanEditMultipleObjects]		public class ScaleToInspector : TransformToInspector<ScaleTo> { }

	public class TransformToInspector<T> : BaseInspector where T : BaseObject
	{
		#region Properties
		private T Script => target as T;
		private Inspector Inspector => Script.inspector;
		#endregion Properties


		#region Editor Methods
		public override void OnInspectorGUI()
		{
			DrawParameters();

			if (Foldout("Constraints", ref Inspector.draw1))
				DrawConstraints();
		}
		#endregion Editor Methods


		#region Main Methods
		protected virtual void DrawParameters()
		{
			PropertyField("target");
			PropertyField("speed");
			PropertyField("smoothing");
		}
		protected virtual void DrawConstraints()
		{
			
			PropertyField("constraintX", "X");
			PropertyField("constraintY", "Y");
			PropertyField("constraintZ", "Z");
		}
		#endregion Main Methods
	}
}
#endif