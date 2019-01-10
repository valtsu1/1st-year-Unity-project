using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaddleController : MonoBehaviour
{
	private Text textScore;
	public float paddleSpeed = 8f;
//	public GameObject ballPrefab;
	private PointerControllerBreakOut rightButton;
	private PointerControllerBreakOut leftButton;
	private Image paddle;

	void Start ()
	{
		textScore = GameObject.Find ("TextScore").GetComponent<Text> ();
		rightButton = GameObject.Find ("ButtonRight").GetComponent<PointerControllerBreakOut> ();
		leftButton = GameObject.Find ("ButtonLeft").GetComponent<PointerControllerBreakOut> ();
		paddle = GameObject.Find ("Paddle").GetComponent<Image> ();
		// Finds the buttons, paddle and text screen for score
	}

	void Update ()
	{
		float xPos = transform.position.x + (Input.GetAxis ("Horizontal") * paddleSpeed);
		var pos = transform.position;
		pos.x = Mathf.Clamp (xPos, -500f, 1600f);
		transform.position = pos;
		textScore.text = "Score: " + BrickScript.score + "\nHighscore: " + BrickScript.highScore;
		// This method does the movement of the paddle
		// Updates the score


		if (leftButton.getPressed ()) {
			paddle.transform.Translate (-4f, 0, 0);
			// invisible button to allow the game to be played ot mobile
		}
		if (rightButton.getPressed ()) {
			paddle.transform.Translate (4f, 0, 0);
			// invisible button to allow the game to be played ot mobile
		}
	}

	void OnCollisionEnter (Collision col)
	{
		foreach (ContactPoint contact in col.contacts) {
			if (contact.thisCollider == GetComponent<BoxCollider> ()) {
				float calc = contact.point.x - transform.position.x;
				contact.otherCollider.GetComponent<Rigidbody> ().AddForce (120f * calc, 0, 0);
				// When a object hits the paddle it adds Force to the ball. Also makes it so the ball bounces in an angle.
			}
		}
	}
}

