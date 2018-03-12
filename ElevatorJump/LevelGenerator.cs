using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {

	public GameObject platformPrefab;

	public int numberOfPlatforms = 200;
	public float levelWidth = 8f;
	public float minY = 1f;
	public float maxY = 4;


	void Start () {

		Vector3 spawnPosition = new Vector3 ();

		//spawns objects in positions given by user
		for (int i = 0; i < numberOfPlatforms; i++) {
			spawnPosition.y += Random.Range (minY, maxY);
			spawnPosition.x = Random.Range (-levelWidth, levelWidth);
			Instantiate (platformPrefab, spawnPosition, Quaternion.identity);

		}
	}
}
