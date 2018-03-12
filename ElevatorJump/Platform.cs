using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {
	
	public float jumpForce = 20f;

	//bounces collided rigidbody2d up and destroys game object
	void OnCollisionEnter2D(Collision2D collision) {

		if (collision.relativeVelocity.y <= 0f) {

			Rigidbody2D ozerov = collision.collider.GetComponent<Rigidbody2D> ();
			if (ozerov != null) { 
				Vector2 velocity = ozerov.velocity/2;
				velocity.y = jumpForce;
				ozerov.velocity = velocity;
				Destroy(gameObject);
			}
		}
	}
}
