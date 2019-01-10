using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

	public Transform target;
	public float smoothSpeed = .4f;

	//if target y position is greater than current position, move to target
	void Update () {
		if (target.position.y > transform.position.y) {
			Vector3 newPos = new Vector3(transform.position.x, target.position.y, transform.position.z);
			transform.position = Vector3.Lerp (transform.position, newPos, smoothSpeed);
		}
	}
}
