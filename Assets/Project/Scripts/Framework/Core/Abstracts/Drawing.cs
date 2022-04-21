using UnityEngine;

namespace Odders
{
	public abstract class Drawing : BaseObject
	{
		#region Public Variables
		public bool drawIfNotSelected;
		public Color color = Color.white;
		#endregion Public Variables


		#region Unity Methods
#if UNITY_EDITOR
		public void OnDrawGizmos()
		{
			if (isActiveAndEnabled && drawIfNotSelected) Draw();
		}
		public void OnDrawGizmosSelected()
		{
			if (isActiveAndEnabled && !drawIfNotSelected) Draw();
		}
#endif
		#endregion Unity Methods


		#region Main Methods
#if UNITY_EDITOR
		public virtual void Draw() { }
#endif
		#endregion Main Methods
	}
}