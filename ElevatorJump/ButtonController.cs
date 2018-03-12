using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {


	private bool buttonPressed = false;

	//sets the buttonPressed variable to true when mouse is pressed
	public void OnPointerDown (PointerEventData e) {
		buttonPressed = true;

	}
	//sets the buttonPressed variable to false when mouse is released
	public void OnPointerUp (PointerEventData e) {
		buttonPressed = false;
	}

	//returns the state of buttonPressed when called
	public bool GetButtonPressed() {
		return buttonPressed;
	}
}
