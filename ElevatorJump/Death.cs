using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Death : MonoBehaviour {

	//reloads the current scene on collision and plays audio file
	void OnCollisionEnter2D() {
		
	SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);

	}
}

