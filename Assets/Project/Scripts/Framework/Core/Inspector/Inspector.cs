#if UNITY_EDITOR
using UnityEngine;
using AnimBool = UnityEditor.AnimatedValues.AnimBool;

namespace Odders
{
	[System.Serializable]
	public class Inspector
	{
		[HideInInspector]
		public bool drawDebugg, drawParameters = true, drawEvents = true;
		public readonly AnimBool fadeDebug = new AnimBool(false);
		public readonly AnimBool fadeParameters = new AnimBool(false);
		public readonly AnimBool fadeEvents = new AnimBool(false);

		[HideInInspector]
		public bool draw1, draw2, draw3, draw4, draw5;
		public readonly AnimBool fade1 = new AnimBool(false);
		public readonly AnimBool fade2 = new AnimBool(false);
		public readonly AnimBool fade3 = new AnimBool(false);
		public readonly AnimBool fade4 = new AnimBool(false);
		public readonly AnimBool fade5 = new AnimBool(false);
	}
}
#endif