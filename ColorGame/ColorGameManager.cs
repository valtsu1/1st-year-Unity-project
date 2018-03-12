using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ColorGameManager : MonoBehaviour
{
    private SpriteRenderer red;
    private SpriteRenderer green;
    private SpriteRenderer blue;
    private SpriteRenderer yellow;
    private SpriteRenderer[] Colors;
    private int colorSelect;

    private const float timeStayLit = 0.3f;
    private float stayLit;
    private float stayLitCounter;

    private const float timeBetweenLights = 0.3f;
    private float waitBetweenLights;
    private float waitBetweenCounter;

    private bool isLit;
    private bool isDark;

    private List<int> combo = new List<int>();
    private int positionInCombo;

    private bool canBeClicked;
    private int clickedInCombo;

    private Button gameButton;
    private Text buttonText;

    private Text gameText;
    private NextSceneManager nextSceneManager;

    // Use this for initialization
    /// <summary>
    /// etsitään värit ja tehdään niistä Array
    /// </summary>
    void Start()
    {
        red = GameObject.Find("Red").GetComponent<SpriteRenderer>();
        green = GameObject.Find("Green").GetComponent<SpriteRenderer>();
        blue = GameObject.Find("Blue").GetComponent<SpriteRenderer>();
        yellow = GameObject.Find("Yellow").GetComponent<SpriteRenderer>();
        Colors = new SpriteRenderer[] { red, green, blue, yellow };

        gameText = GameObject.Find("GameText").GetComponent<Text>();
        nextSceneManager = GameObject.Find("NextSceneManager").GetComponent<NextSceneManager>();

        gameButton = GameObject.Find("GameButton").GetComponent<Button>();
        buttonText = GameObject.Find("GameButton").GetComponentInChildren<Text>();
        gameButton.onClick.AddListener(StartGame);
    }

    // Update is called once per frame

    /// <summary>
    /// IsLit is true when game starts
    /// 
    /// </summary>
    void Update()
    {
        if (isLit == true)
        {
            gameText.text = combo.Count + ". Level";
            stayLitCounter -= Time.deltaTime;
            if (stayLitCounter < 0)
            {
                Colors[combo[positionInCombo]].color = new Color(Colors[combo[positionInCombo]].color.r, Colors[combo[positionInCombo]].color.g,
                Colors[combo[positionInCombo]].color.b, 0.5f);

                isLit = false;
                isDark = true;
                waitBetweenCounter = waitBetweenLights;
                positionInCombo++;
            }
        }

        if (isDark == true)
        {
            {

                if (positionInCombo >= combo.Count)
                {
                    isDark = false;
                    canBeClicked = true;
                }

                else
                {
                    waitBetweenCounter -= Time.deltaTime;
                    if (waitBetweenCounter < 0)
                    {
                        Colors[combo[positionInCombo]].color = new Color(Colors[combo[positionInCombo]].color.r, Colors[combo[positionInCombo]].color.g,
                        Colors[combo[positionInCombo]].color.b, 1f);

                        stayLitCounter = stayLit;
                        isLit = true;
                        isDark = false;
                    }
                }
            }
        }
    }


    /// <summary>
    ///  Metodia kutsutaa, kun start nappia painetaan
    ///  vanhan pelin muuttujat  nollataa, nappia ei
    ///  voi enää painaa.
    ///  arvotaan väri ja lisätään se jonoon, väriä fläshätään pelaajalle, jonka jälkeen update hoitaa lopun pelistä
    /// </summary>
    private void StartGame()
    {
        combo.Clear();
        positionInCombo = 0;
        clickedInCombo = 0;
        gameButton.interactable = false;

        stayLit = timeStayLit;
        waitBetweenLights = timeBetweenLights;

        colorSelect = Random.Range(0, Colors.Length);
        combo.Add(colorSelect);

        Colors[combo[positionInCombo]].color = new Color(Colors[combo[positionInCombo]].color.r, Colors[combo[positionInCombo]].color.g,
        Colors[combo[positionInCombo]].color.b, 1f);

        stayLitCounter = stayLit;
        isLit = true;
        isDark = false;
    }
    /// <summary>
    /// Compares if you clicked right
    /// if you repeated the sequence correclty game gets harder
    /// if done 7 times you win
    /// if you fail, timers get reset to easy and new game is started
    /// </summary>
    /// <param name="buttonNumber"></param>
    public void ColorPressed(int buttonNumber)
    {
        if (canBeClicked == true)
        {
            if (combo[clickedInCombo] == buttonNumber)
            {
                clickedInCombo++;

                if (clickedInCombo >= combo.Count)
                {
                    if (combo.Count == 7)
                    {
                        YouWin();
                    }

                    else
                    {
                        waitBetweenLights -= 0.02f;
                        stayLit -= 0.02f;
                        positionInCombo = 0;
                        clickedInCombo = 0;
                        colorSelect = Random.Range(0, Colors.Length);

                        combo.Add(colorSelect);

                        Colors[combo[positionInCombo]].color = new Color(Colors[combo[positionInCombo]].color.r, Colors[combo[positionInCombo]].color.g,
                        Colors[combo[positionInCombo]].color.b, 1f);

                        stayLitCounter = stayLit;
                        isLit = true;
                        canBeClicked = false;
                    }
                }
            }
            else
            {
                gameText.text = "YOU LOSE";
                buttonText.text = "Restart";
                waitBetweenCounter = timeBetweenLights;
                stayLitCounter = timeStayLit;
                canBeClicked = false;
                gameButton.interactable = true;
            }

        }
    }

    /// <summary>
    /// returns can be clicked bool
    /// </summary>
    /// <returns></returns>
    public bool GetCanBeClicked()
    {
        return canBeClicked;
    }

    /// <summary>
    /// Win the game
    /// </summary>
    private void YouWin()
    {
        gameText.text = ("You Win");
        gameButton.interactable = true;
        buttonText.text = "Continue";
        gameButton.onClick.RemoveAllListeners();
        gameButton.onClick.AddListener(OnClickWin);
    }

    /// <summary>
    /// loads next scene
    /// </summary>
    private void OnClickWin()
    {
        nextSceneManager.NextScene();
    }
}
