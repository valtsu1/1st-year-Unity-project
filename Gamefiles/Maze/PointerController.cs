using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class PointerController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

	bool pressed = false;

	/// <summary>
	/// Raises the pointer down event.
	/// Switches if the button is pressed or not
	/// <param name="eventdata">Eventdata.</param>

	public void OnPointerDown (PointerEventData eventdata) {
		pressed = true;
	}

	public void OnPointerUp (PointerEventData eventData) {
		pressed = false;
	}
	public bool getPressed() {
		return this.pressed;
	}
}
