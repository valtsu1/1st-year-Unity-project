using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
	private float ballForce = 8000f;
	public float velocity;

	void Start ()
	{
		Rigidbody ballrigid = GetComponent<Rigidbody> ();
		ballrigid.AddForce (0, ballForce, 0);
		// Adds starting force to ball
	
	}

	void Update ()
	{
		if (ballForce > 5000f) {
			ballForce = 4500f;
			// Lowers the speed if the balls goes too fast.
		}

	}

}
