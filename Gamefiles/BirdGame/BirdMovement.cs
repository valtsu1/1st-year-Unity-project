using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BirdMovement : MonoBehaviour
{
	private NextSceneManager nextSceneManager;
	public Vector3 flapVelocity;
	float flapSpeed = 120f;
	float forwardSpeed = 2.5f;
	private Rigidbody2D rigidBody;
	Animator animator;
	bool didFlap = false;
	bool dead = false;
	float deathCoolDown;
	private Button ButtonRestart;
	private Button ButtonContinue;

	void Start ()
	{
		nextSceneManager = GameObject.Find ("NextSceneManager").GetComponent<NextSceneManager> ();
		ButtonRestart =	GameObject.Find ("ButtonRestart").GetComponent<Button> ();
		ButtonContinue = GameObject.Find ("ButtonContinue").GetComponent<Button> ();
		rigidBody = GetComponent<Rigidbody2D> ();
		animator = transform.GetComponentInChildren<Animator> ();
		ButtonContinue.gameObject.SetActive (false);
		ButtonRestart.gameObject.SetActive (false);
		Score.highScore = PlayerPrefs.GetInt ("highScore", Score.highScore);
		ButtonRestart.onClick.AddListener (Restart);
		ButtonContinue.onClick.AddListener (Continue);
	
	}

	void Update ()
	{
		if (dead) {
			deathCoolDown -= Time.deltaTime;
			// Gives death a cooldown so you cant respawn instantly as you die
		}
		if (Input.GetKeyDown (KeyCode.Space) || Input.GetMouseButtonDown (0)) {
			didFlap = true; 
			// When you press Space or leftMousebutton it sets didFlap to true
		}
	}

	void FixedUpdate ()
	{
		if (dead)
			return;
		// Makes it so you cannot continue the game without respawning
		
		rigidBody.AddForce (Vector2.right * forwardSpeed);
		// Makes the player move forward all the time at a certain speed
		if (didFlap) {
			rigidBody.AddForce (Vector2.up * flapSpeed);
			animator.SetTrigger ("DoFlap");
			didFlap = false;
			// if didFlap is true. It adds Force to the player on positive Y axis. Meaning it will go higher. 
			// Does the animation "DoFlap"
			// Sets the didFlap back to false.

		}

	}

	void OnCollisionEnter2D (Collision2D collision)
	{
		
		animator.SetTrigger ("Death");
		ButtonsAppear ();
		dead = true;
		// When the player collides with an 2D collider it plays the animation "Death" and sets the value of dead to true. This serves as death
		// Also does the ButtonsAppear method

	}

	void ButtonsAppear ()
	{
		ButtonRestart.gameObject.SetActive (true);
		if (Score.highScore >= 15) {
			ButtonContinue.gameObject.SetActive (true);
		}
		// Sets the Restart Button active
		// If highscore is 15 or higher it also sets Continue button to active
	}

	private void Restart ()
	{
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
		// Loads the game from the start
	}

	private void Continue ()
	{	
		nextSceneManager.NextScene ();
		// Loads the next scene
	}
}
