using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveMaze : MonoBehaviour
{
	private PointerController UpButton;
	private PointerController RightButton;
	private PointerController DownButton;
	private PointerController LeftButton;


	public Transform OzeroPaa;
	/// <summary>
	/// Finds the game objects
	/// </summary>

	void Start ()
	{
		
		
		RightButton = GameObject.Find ("RightButton").GetComponent<PointerController> ();
		LeftButton = GameObject.Find ("LeftButton").GetComponent<PointerController> ();
		UpButton = GameObject.Find ("UpButton").GetComponent<PointerController> ();
		DownButton = GameObject.Find ("DownButton").GetComponent<PointerController> ();


	}
	/// <summary>
	/// Tells What button does what
	/// <param name="u">U.</param>

	private void Up (Button u)
	{
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, -3);
		OzeroPaa.transform.eulerAngles = new Vector3 (0, 0, 0);
	}

	private void Down (Button d)
	{
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 3);
		OzeroPaa.transform.eulerAngles = new Vector3 (0, 0, 180);
	}

	private void Left (Button l)
	{
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (3, 0);
		OzeroPaa.transform.eulerAngles = new Vector3 (0, 0, 90);
	}

	private void Right (Button r)
	{
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (-3, 0);
		OzeroPaa.transform.eulerAngles = new Vector3 (0, 0, -90);
	
	}
	/// <summary>
	/// Turns Ozeros head around and moves her
	/// </summary>

	void Update ()
	{
		if (!UpButton.getPressed () && !DownButton.getPressed () && !RightButton.getPressed () && !LeftButton.getPressed ()) {
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 0);	
		}
		if (UpButton.getPressed ()) {
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, -3);
			OzeroPaa.transform.eulerAngles = new Vector3 (0, 0, 0);
		}
		if (LeftButton.getPressed ()) {
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (3, 0);
			OzeroPaa.transform.eulerAngles = new Vector3 (0, 0, 90);
		}
		if (DownButton.getPressed ()) {
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 3);
			OzeroPaa.transform.eulerAngles = new Vector3 (0, 0, 180);
		}
		if (RightButton.getPressed ()) {
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (-3, 0);
			OzeroPaa.transform.eulerAngles = new Vector3 (0, 0, -90);
		}
	}
}
