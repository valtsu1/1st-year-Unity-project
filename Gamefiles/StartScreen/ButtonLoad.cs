using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonLoad : MonoBehaviour {


	private NextSceneManager nextScene;
	private Button start;


	void Start () {
		start = GameObject.Find ("JeesusPerkele").GetComponent<Button> ();
		nextScene = GameObject.Find ("NextSceneManager").GetComponent<NextSceneManager> ();

		start.onClick.AddListener(NextSceneGo);
	}
	// Update is called once per frame
	void NextSceneGo () {
		nextScene.NextScene ();
	
	}
}
