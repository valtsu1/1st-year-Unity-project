using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartScreen : MonoBehaviour
{
	
	static bool sawOnce = false;

	void Start ()
	{
		if (!sawOnce) {

			Time.timeScale = 0;
		}
		sawOnce = true;
		// Resets the highscore
	}

	void Update ()
	{

		if (Time.timeScale == 0 && (Input.GetKeyDown (KeyCode.Space) || Input.GetMouseButtonDown (0))) {
			Time.timeScale = 1;
			// After the player presses Space or Left mouse button the game starts

		}
	}
}
