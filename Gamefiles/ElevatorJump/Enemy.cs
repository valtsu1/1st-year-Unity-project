using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public float jumpForce = -20f;

	//on collision bounces the collided rigidbody2d down and destroys the game object.
	void OnCollisionEnter2D(Collision2D collision) 
	{
			Rigidbody2D ozerov = collision.collider.GetComponent<Rigidbody2D> ();
			Vector2 velocity = ozerov.velocity;
			velocity.y = jumpForce;
			ozerov.velocity = velocity;
			Destroy(gameObject);
	}
}
