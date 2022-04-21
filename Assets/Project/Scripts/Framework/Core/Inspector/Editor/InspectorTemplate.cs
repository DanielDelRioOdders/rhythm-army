#if UNITY_EDITOR
namespace Odders.Editor
{
	public abstract class InspectorTemplate<T> : BaseInspector where T : BaseObject
	{
		#region Properties
		protected T Script => target as T;
		protected Inspector Inspector => Script.inspector;

		protected virtual bool Debug => false;
		protected virtual bool Parameters => false;
		protected virtual bool Events => false;
		#endregion Properties


		#region Editor Methods
		protected virtual void OnEnable()
		{
			Inspector.fadeDebug.valueChanged.AddListener(Repaint);
			Inspector.fadeParameters.valueChanged.AddListener(Repaint);
			Inspector.fadeEvents.valueChanged.AddListener(Repaint);
		}

		public override void OnInspectorGUI()
		{
			if (Debug)			FadeDebug();
			if (Parameters)		FadeParameters();
			if (Events)			FadeEvents();
		}
		#endregion Editor Methods


		#region Main Methods
		protected void FadeDebug() => Fade(Inspector.fadeDebug, FoldoutHeader("Debug", ref Inspector.drawDebugg), DrawDebug);
		protected void FadeParameters() => Fade(Inspector.fadeParameters, FoldoutHeader("Parameters", ref Inspector.drawParameters), DrawParameters);
		protected void FadeEvents() => Fade(Inspector.fadeEvents, FoldoutHeader("Events", ref Inspector.drawEvents), DrawEvents);

		protected virtual void DrawDebug() { }
		protected virtual void DrawParameters() { }
		protected virtual void DrawEvents() { }
		#endregion Main Methods
	}
}
#endif