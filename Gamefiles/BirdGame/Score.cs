using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	private Text TextScore;
	public static int score = 0;	
	public static int highScore = 0;

	static public void AddPoint () {
		score++;		

		if (score > highScore) {
			highScore = score;
			// Adds 1 to the score
			// if score is higher than highscore it makes highscore equal to score.
		}
	}
		void Start()  {
		score = 0; 
		TextScore = GameObject.Find ("TextScore").GetComponent<Text>();
		// Sets the score back to 0 a the start.
		}
	void OnDestroy() {
		PlayerPrefs.SetInt("highScore", highScore);
		// Saves the highscore
	}
	void Update () {
		TextScore.text = "Distance flown: " + score +"KM"+ "\nHighscore: " + highScore +"KM";
		// Changes the text no screen to be the new score. Also updates new highscore
	}
}
