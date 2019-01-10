using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SpeakerManager : MonoBehaviour
{
    public TextAsset textFile;
    public Text textArea;
    private string[] textLines;

    private int currentLine = 0;
    private int lastLine;

    private Button button;

    public GameObject ozero;
    public GameObject notOzero;

    private NextSceneManager nextSceneManager;

    // Use this for initialization
    void Start()
    {
        button = GameObject.Find("ButtonA").GetComponent<Button>();
        button.onClick.AddListener(MeClicked);

        nextSceneManager = GameObject.Find("NextSceneManager").GetComponent<NextSceneManager>();

        if (textFile.text != null)
        {
            textLines = textFile.text.Split('\n');
        }
        lastLine = textLines.Length;
    }

    /// Update is called once per frame
    /// <summary>
    /// Valitaan oikea puhujan kuva, kutsumalla SelectPicture metodia
    ///SpaceBaria painalla voi myös vaihtaa seuraavaan riviin
    ///Kirjoitetaan rivi textAreaan
    /// </summary>
    void Update()
    {
        SelectPicture();
        if (currentLine < lastLine)
        {
            textArea.text = textLines[currentLine];
            if (Input.GetKeyDown(KeyCode.Space))
            {
                currentLine++;
            }
        }

        if (currentLine == lastLine)
        {
            nextSceneManager.NextScene();
        }
    }
    /// <summary>
    /// Dialogit ovat kahden henkilön välisiä
    /// Jos nykyisellä rivillä lukee päähenkilö "Ozero" nimi, valitaan ozero aktiiviseksi ja toinen pois päältä
    /// Jos on toinen nimi kuin "Ozero", ozero ei ole aktiivinen ja toinen on aktiivinen
    /// </summary>
    private void SelectPicture()
    {
        if (currentLine < lastLine)
        {
            if (textLines[currentLine].Trim().Equals("Ozero"))
            {
                ozero.SetActive(true);
                notOzero.SetActive(false);

            }
            else
            {
                ozero.SetActive(false);
                notOzero.SetActive(true);
            }
        }
    }

    /// <summary>
    /// nappia painaessa jos nykyinen rivi on vähemmän kuin viimeinen rivi, nykyistä riviä kasvatetaan eli vaihdetaan seuraavaan riviin
    /// </summary>
    private void MeClicked()
    {
        if (currentLine < lastLine)
        {
            currentLine++;
        }
    }
}