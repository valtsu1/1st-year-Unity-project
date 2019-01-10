using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class PointerControllerBreakOut : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

	bool pressed = false;

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
