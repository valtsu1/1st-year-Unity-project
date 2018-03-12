using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour {

	//shows a start screen and stops the time
	void Start ()
	{
			GetComponent<SpriteRenderer> ().enabled = true;
			Time.timeScale = 0;

	}
		
	void Update ()
	{
		//game starts by clicking space or mousebutton, hides the start screen
		if (Time.timeScale == 0 && (Input.GetKeyDown (KeyCode.Space) || Input.GetMouseButtonDown (0))) {
			Time.timeScale = 1;
			GetComponent<SpriteRenderer> ().enabled = false;
		}
	}
}
