using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {


	private GameObject ozerov;
	private ButtonController buttonUp;
	private ButtonController buttonLeft;
	private ButtonController buttonRight;
	private Text jumpCounterText;

	Animator ozerovAni;

	public float moveSpeed;
	public float jumpPower;

	public bool isGrounded;
	public int jumpCounter = 0;

	//ties the variables to components
	void Start () {

		ozerovAni = transform.GetComponentInChildren<Animator> ();
		ozerov = GameObject.Find ("Ozerov");
		buttonUp = GameObject.Find ("ButtonJump").GetComponent<ButtonController> ();
		buttonLeft = GameObject.Find ("ButtonLeft").GetComponent<ButtonController> ();
		buttonRight = GameObject.Find ("ButtonRight").GetComponent<ButtonController> ();
		jumpCounterText = GameObject.Find ("JumpCounter").GetComponent<Text> ();

	}

	//resets the jump counter when colliding with an object
	void OnCollisionEnter2D() {

			isGrounded = true;
			jumpCounter++;
			jumpCounterText.text = "Jump Counter: 1";

	}
		
	void Update () {
		Rigidbody2D rb = GetComponent<Rigidbody2D> ();

		//moves the player to left by clicking the left button or when pressing left arrow
		if (buttonLeft.GetButtonPressed () || Input.GetKey(KeyCode.LeftArrow)) {
			ozerov.transform.Translate (-Vector3.right * moveSpeed * Time.deltaTime);
			ozerovAni.SetTrigger ("OzeroLeft");
		}

		//moves the player to right by clicking the right button or when pressing right arrow
		if (buttonRight.GetButtonPressed () || Input.GetKey(KeyCode.RightArrow)) {
			ozerov.transform.Translate (Vector3.right * moveSpeed * Time.deltaTime);
			ozerovAni.SetTrigger ("OzeroRight");
		}

		//jumps the player up when by clicking jump button or space
		if (buttonUp.GetButtonPressed () || Input.GetKey(KeyCode.Space) && isGrounded) {
			//checks if player has touched a platform since last jump
			if (jumpCounter > 0) {
				//jump is disabled if y.axis speed is too much
				//sets jumpCounter to zero
				if (rb.velocity.y < 10) {
					rb.AddForce (Vector3.up * jumpPower);
					isGrounded = false;
					jumpCounter--;
					jumpCounterText.text = "Jump Counter: 0";
					ozerovAni.SetTrigger ("OzeroFlip");
				}
			} 
		}
	}
}
