using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathZone : MonoBehaviour {
	private Button buttonReset;
	private Button buttonContinue;
	private NextSceneManager nextSceneManager;

	void Start () {
		nextSceneManager = GameObject.Find("NextSceneManager").GetComponent<NextSceneManager>();	
		buttonReset = GameObject.Find ("ButtonReset").GetComponent<Button> ();
		buttonContinue = GameObject.Find ("ButtonContinue").GetComponent<Button> ();
		buttonReset.onClick.AddListener (buttonRestart);
		buttonContinue.onClick.AddListener (buttonContinueGame);
		buttonContinue.gameObject.SetActive (false);
		// Finds the buttons and sets them non active at the start
	}

void OnTriggerEnter()
	{
		buttonsAppear ();
		// When object enters trigger it does the method
	}
	public void buttonsAppear () {
		if (BrickScript.highScore > 7) {
			buttonContinue.gameObject.SetActive (true);
		}
		// Sets the Reset button active
		// if highscore is more than 10 it also sets the continue button active
		// servers as win condition
	}
	void buttonRestart () {
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
		// Loads the scene from the start
	}
	void buttonContinueGame () {
		nextSceneManager.NextScene ();
		// Continues to the next Scene
	}
}
