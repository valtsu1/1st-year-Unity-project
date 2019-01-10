using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    public TextAsset textFile;
    public Text textArea;
    private string[] textLines;

    private int currentLine;
    private int lastLine;

    private Button button;

    // Use this for initialization
    //Etsitään nappi ja lisätään MeClicked metodi listener
    //Hajoitetaan .text arrayksi
    //Viimeinen rivi on arrayn pituus
    void Start()
    {
        button = GameObject.Find("ButtonA").GetComponent<Button>();
        button.onClick.AddListener(MeClicked);

        if (textFile.text != null)
        {
            textLines = textFile.text.Split('\n');
        }
        lastLine = textLines.Length;
    }

    // Update is called once per frame
    /// <summary>
    ///SpaceBaria painalla voi myös vaihtaa seuraavaan riviin
    ///Kirjoitetaan rivi textAreaan
    /// </summary>
    void Update()
    {
        if (currentLine < lastLine)
        {
            textArea.text = textLines[currentLine];
            if (Input.GetKeyDown(KeyCode.Space))
            {
                currentLine++;
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
