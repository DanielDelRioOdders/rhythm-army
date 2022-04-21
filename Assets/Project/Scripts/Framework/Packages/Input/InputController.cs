using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

namespace Odders
{
	/// <summary>
	/// Receives player input.
	/// </summary>
	[AddComponentMenu("Odders/Input/Input Controller")]
    public class InputController : BaseObject
    {
		#region Private Variables
		private ActionBasedController controller;
		#endregion Private Variables


		#region Events
		public UnityEvent OnSelect, OnUIPress;
		#endregion Events


		#region Unity Methods
		private void Awake()
		{
			controller = GetComponent<ActionBasedController>();

			//bool isPressed = controller.selectAction.action.ReadValue<bool>();

			controller.uiPressAction.action.performed += UIPress;
			controller.selectAction.action.performed += SelectAction;
		}

		private void UIPress(UnityEngine.InputSystem.InputAction.CallbackContext obj) => OnUIPress?.Invoke();
		private void SelectAction(UnityEngine.InputSystem.InputAction.CallbackContext obj) => OnSelect?.Invoke();
		#endregion Unity Methods


		#region Utility Methods
		public void Vibration() => controller.SendHapticImpulse(0.7f, 0.1f);
		#endregion Utility Methods
	}
}