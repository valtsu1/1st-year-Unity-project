using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{


	//all the variables needed in the game
    private NextSceneManager nextSceneManager;

    public Sprite[] cardFace;
    public Sprite cardBack;
    public GameObject[] cards;
    public Text matchText;

    private bool _init = false;
    private int _matches = 7;

    void Start()
    {
        nextSceneManager = GameObject.Find("NextSceneManager").GetComponent<NextSceneManager>();
    }

    
    void Update()
    {
        if (!_init)
            initializeCards();
        if (Input.GetMouseButtonUp(0))
            checkCards();

    }

	//assings random number for each card pair
	//assings graphics for each card based on card number
    void initializeCards()
    {
        for (int id = 0; id < 2; id++)
        {
            for (int i = 1; i < 8; i++)
            {

                bool test = false;
                int choice = 0;
                while (!test)
                {
                    choice = Random.Range(0, cards.Length);
                    test = !(cards[choice].GetComponent<Card>().initialized);
                }

                cards[choice].GetComponent<Card>().cardValue = i;
                cards[choice].GetComponent<Card>().initialized = true;
            }
        }

        foreach (GameObject c in cards)
            c.GetComponent<Card>().setupGraphics();

        if (!_init)
            _init = true;
    }

	//sets card background
    public Sprite getCardBack()
    {
        return cardBack;
    }

	//returns card face from list based on the int
    public Sprite getCardFace(int i)
    {
        return cardFace[i - 1];
    }

	//compares 2 turned cards if they match
    void checkCards()
    {
        List<int> c = new List<int>();

        for (int i = 0; i < cards.Length; i++)
        {
            if (cards[i].GetComponent<Card>().state == 1)
                c.Add(i);
        }

        if (c.Count == 2)
            cardComparison(c);
    }

	//compares cards when called until there is no pairs left
    void cardComparison(List<int> c)
    {
        Card.DO_NOT = true;

        int x = 0;

        if (cards[c[0]].GetComponent<Card>().cardValue == cards[c[1]].GetComponent<Card>().cardValue)
        {
            x = 2;
            _matches--;
            matchText.text = "Pairs left " + _matches;

            if (_matches == 0)
            {
                matchText.text = "Voitit pelin!";
                nextSceneManager.NextScene();
            }
        }

        for (int i = 0; i < c.Count; i++)
        {
            cards[c[i]].GetComponent<Card>().state = x;
            cards[c[i]].GetComponent<Card>().falseCheck();

        }
    }
}
