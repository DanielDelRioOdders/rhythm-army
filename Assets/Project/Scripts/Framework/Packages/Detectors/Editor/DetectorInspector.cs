#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

namespace Odders.Editor
{
	[CustomEditor(typeof(Detector), true), CanEditMultipleObjects]
	public class DetectorInspector : InspectorTemplate<Detector>
	{
		#region Properties
		private bool HasCollider3D => Script.GetComponent<Collider>();
		private bool HasCollider2D => Script.GetComponent<Collider2D>();
		private bool HasCollider => Script.mode switch
		{
			Dimension._3D => HasCollider3D,
			Dimension._2D => HasCollider2D,
			_ => false
		};

		protected override bool Debug => true;
		protected override bool Parameters => true;
		protected override bool Events => true;
		#endregion Properties


		#region Editor Methods
		protected override void OnEnable()
		{
			base.OnEnable();
			Inspector.fade1.valueChanged.AddListener(Repaint);
		}
		#endregion Editor Methods


		#region Main Methods
		protected override void DrawDebug()
		{
			if (!Script.IsCollisionDetector)
			{
				PropertyField("drawIfNotSelected");
				PropertyField("color");
			}

			HelpBox($"Colliders: {Script.total}", MessageType.Info);

			DrawMessage();
		}
		protected override void DrawParameters()
		{
			PropertyField("mode");
			PropertyField("whatToDetect");
			Fade(Inspector.fade1, Script.whatToDetect != DetectionMode.ANYTHING, DrawDetectionMode);

			DrawDetector();
		}
		protected override void DrawEvents()
		{
			PropertyField("OnEnter");
			PropertyField("OnExit");
		}

		private void DrawMessage()
		{
			string c = string.Empty;
			if (Script.IsCollisionDetector && !HasCollider)
			{
				c = Script.mode == Dimension._3D ? "collider" : "collider2D";
				HelpBox($"Add a {c} to make it work.", MessageType.Error);
			}
			else if (!Script.IsCollisionDetector)
			{
				if (HasCollider3D) c = "collider";
				else if (HasCollider2D) c = "collider2D";

				if (c != string.Empty) HelpBox($"Remove the {c} to improve performance.", MessageType.Warning);
			}
		}
		private void DrawDetectionMode()
		{
			switch (Script.whatToDetect)
			{
				case DetectionMode.LAYER:		PropertyField("_layer"); break;
				case DetectionMode.TAG:			PropertyField("_tag"); break;
				case DetectionMode.COMPONENT:	StringField("Component", ref Script._component); break;
				case DetectionMode.NAME:		StringField("Name", ref Script._name); break;
			}
		}

		protected virtual void DrawDetector() { }
		#endregion Main Methods
	}
}
#endif