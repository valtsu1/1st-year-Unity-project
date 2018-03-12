using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrickScript : MonoBehaviour
{

	public static int score;
	public static int highScore;

	void Start ()
	{
		score = 0;
		// Sets the score to 0 at start

	}

	void OnCollisionEnter ()
	{
		Destroy (gameObject);
		score++;
		if (score > highScore) {
			highScore = score;
			// When ball destroys a brick it adds score
			// Updates highscore if its lower than score
		}
	}
}

