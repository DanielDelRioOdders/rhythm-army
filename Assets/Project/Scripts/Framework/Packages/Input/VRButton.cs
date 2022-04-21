using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Odders
{
	/// <summary>
	/// It detects whether the player has pressed the button.
	/// </summary>
	[AddComponentMenu("Odders/Input/VR Button"), RequireComponent(typeof(Image))]
	public class VRButton : BaseObject, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
	{
		#region Protected Variables
		protected Image image;
		#endregion Protected Variables


		#region Events
		[Header("Events")]
		public UnityEvent OnEnter;
		public UnityEvent OnExit;
		public UnityEvent OnDown;
		public UnityEvent OnUp;
		#endregion Events


		#region Unity Methods
		protected virtual void Awake() => image = GetComponent<Image>();

		public virtual void OnPointerEnter(PointerEventData eventData) => OnEnter?.Invoke();
		public virtual void OnPointerExit(PointerEventData eventData) => OnExit?.Invoke();
		public virtual void OnPointerDown(PointerEventData eventData) => OnDown?.Invoke();
		public virtual void OnPointerUp(PointerEventData eventData) => OnUp?.Invoke();
		#endregion Unity Methods


		#region Utility Methods
		public void SetColor(string hex) => image.color = hex.ToColor();
		public void SetAlpha(float alpha) => image.color = image.color.SetA(alpha);
		#endregion Utility Methods
	}
}