using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopWallBounce : MonoBehaviour
{

	void OnCollisionEnter (Collision col)
	{
		foreach (ContactPoint contact in col.contacts) {
			if (contact.thisCollider == GetComponent<BoxCollider> ()) {
				float calc = contact.point.x - transform.position.x;
				contact.otherCollider.GetComponent<Rigidbody> ().AddForce (110f * calc, 0, 0);
				// Adds force to ball when it hits the Top wall.
			}
		}
	}
}
