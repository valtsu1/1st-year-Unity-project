using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{

    private ColorGameManager colorGameManager;
    private SpriteRenderer colorArea;
    public int buttonNumber;


    // Use this for initialization
    void Start()
    {
        colorGameManager = GameObject.Find("ColorGameManager").GetComponent<ColorGameManager>();
        colorArea = GetComponent<SpriteRenderer>();

    }
    /// <summary>
    /// jos saa klikata, spriten väri vaihtuu kirkkaaksi
    /// </summary>
    void OnMouseDown()
    {
        if (colorGameManager.GetCanBeClicked() == true)
        {
            colorArea.color = new Color(colorArea.color.r, colorArea.color.g, colorArea.color.b, 1f);
        }
    }
    /// <summary>
    /// nostaessa hiiren ylös sprite muuttuu tavalliseksi ja spriten numero lähetetään vertailtavaksi
    /// </summary>
    void OnMouseUp()
    {
        colorArea.color = new Color(colorArea.color.r, colorArea.color.g, colorArea.color.b, 0.5f);
        colorGameManager.ColorPressed(buttonNumber);
    }
}
