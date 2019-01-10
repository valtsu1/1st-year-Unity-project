using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMover : MonoBehaviour
{
	Rigidbody2D player;	
	private Rigidbody2D rigidBody;

	void Start ()
	{
		GameObject player_go = GameObject.FindGameObjectWithTag ("Player");
		if (player_go == null) {
			Debug.LogError ("pelaaja ei löytynyt");
			return;
		}
		player = player_go.GetComponent<Rigidbody2D>();
	}
	void FixedUpdate ()
	{
		float vel = player.velocity.x * 0.9f;
		transform.position = transform.position + Vector3.right * vel * Time.deltaTime;
		// Moves the background slightly slower than the player moves giving it a an cool effect.
	}

}


