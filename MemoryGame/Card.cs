using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour {

	public static bool DO_NOT = false;

	//makes private values visible in the Inspector
	[SerializeField]
	private int _state;
	[SerializeField]
	private int _cardValue;
	[SerializeField]
	private bool _initialized = false;

	private Sprite _cardBack;
	private Sprite _cardFace;

	private GameObject _manager;

	//assings gameobject to variable
	void Start() {
		_state = 1;
		_manager = GameObject.Find ("Manager");
	}

	//calls for graphics for cards
	public void setupGraphics() {
		_cardBack = _manager.GetComponent<Manager> ().getCardBack ();
		_cardFace = _manager.GetComponent<Manager> ().getCardFace (_cardValue);

		flipCard ();
	}

	//flips card two times
	public void flipCard() {
		if (_state == 0)
			_state = 1;
		else if (_state == 1)
			_state = 0; 
		
		if (_state == 0 && !DO_NOT)
			GetComponent<Image> ().sprite = _cardBack;
		else if (_state == 1 && !DO_NOT)
			GetComponent<Image> ().sprite = _cardFace;
	}

	//sets value for card
	public int cardValue {
		get { return _cardValue; }
		set {_cardValue = value; }
	}

	//sets and gets state 
	public int state {
		get { return _state; }
		set { _state = value; }
	}

	//sets and gets initialized
	public bool initialized {
		get { return _initialized; }
		set { _initialized = value; }
	}

	//calls for pause method
	public void falseCheck() {
		StartCoroutine (pause ());
	}


	//sets a small delay when flipping cards
	IEnumerator pause() {
		yield return new WaitForSeconds (1);
		if (_state == 0)
			GetComponent<Image> ().sprite = _cardBack;
		else if (_state == 1)
			GetComponent<Image> ().sprite = _cardFace;
		DO_NOT = false;
	}

}
