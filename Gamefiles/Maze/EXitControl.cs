using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EXitControl : MonoBehaviour {

	private NextSceneManager nextScenemanager;

	/// <summary>
	/// When the Exit collider is touched it summons it
	/// </summary>
	void Start () {
		nextScenemanager = GameObject.Find ("NextSceneManager").GetComponent<NextSceneManager> ();	
	}
	

	void OnTriggerEnter2D(Collider2D other){
		if (other.name == "OzeroPaa") {
			Debug.Log ("U win");
			nextScenemanager.NextScene ();
		}
	}
}
