using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class Boing : MonoBehaviour
{
	/// <summary>
	/// The boing.
	/// </summary> :D
	public AudioClip boing;

	//stops boing sound from playing on start
	//ties the applied sound to boing variable
	void start () {
		GetComponent<AudioSource> ().clip = boing;
	}


	//plays The boing when collided with
		void OnCollisionEnter2D() {
		GetComponent<AudioSource> ().Play ();
	}
}
