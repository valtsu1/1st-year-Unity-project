using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWin : MonoBehaviour {

	public NextSceneManager nextSceneManager;

	//loads the next scene when hit
	void OnCollisionEnter2D() {
		nextSceneManager.NextScene ();
	}
		
}
