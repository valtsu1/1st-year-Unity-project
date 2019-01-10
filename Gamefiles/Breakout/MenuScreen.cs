using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScreen : MonoBehaviour
{
	static bool sawOnce = false;

	void Start ()
	{
		if (!sawOnce) {
			Score.highScore = 0;
		}
		sawOnce = true;
		// Resets the highscore when you launch the game for the first time

	}
}


