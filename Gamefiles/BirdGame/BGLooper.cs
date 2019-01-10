using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGLooper : MonoBehaviour
{
	int numBGPaneles = 6;
	float pipeMax = 0.76f;
	float pipeMin = -0.09f;

	void Start ()
	{
		GameObject[] Pipes = GameObject.FindGameObjectsWithTag ("Pipe");
		foreach (GameObject pipe in Pipes) {
			Vector3 pos = pipe.transform.position;
			pos.y = Random.Range (pipeMin, pipeMax);
			pipe.transform.position = pos;

			// Moves the Pipes when the hitbox hits the them.
			// Moves the pipes to the front
		}
	}
	void OnTriggerEnter2D (Collider2D collider)
	{
		float widthOfBGObject = ((BoxCollider2D)collider).size.x;
		Vector3 pos = collider.transform.position;
		pos.x += widthOfBGObject * numBGPaneles;

		if (collider.tag == "Pipe") {
			pos.y = Random.Range (pipeMin, pipeMax);
		}
		collider.transform.position = pos;
		// Moves the background images to the front when the hitbox hits them.
		// also gives the pipes a random value between pipeMin and pipeMax
	}
}