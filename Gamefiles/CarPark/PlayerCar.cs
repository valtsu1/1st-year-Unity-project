using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerCar : MonoBehaviour
{
    public int CarNumber;
    private CarGameManager carGameManager;

    private Button up;
    private Button right;
    private Button down;
    private Button left;
    private Text textArea;

    private bool meMove;
    private Vector3 lastLocation;

    // Use this for initialization
    void Start()
    {
        carGameManager = GameObject.Find("CarGameManager").GetComponent<CarGameManager>();
    }

    /// jokaisella autolla on CarNumber int
    /// kutsutaan CarGameManager luokan SelectCarX metodia
    /// PlayerCar on X suuntainen auto
    /// </summary>
    void OnMouseDown()
    {
        carGameManager.SelectCarX(CarNumber);
    }

    /// <summary>
    /// liikutetaan autoa x suunnassa
    /// bool meMove halutaan, että vain liikkunut auto palautetaan takaisin vanhaan positioniin
    /// </summary>
    /// <param name="direction"></param>
    public void MoveCar(string direction)
    {
        meMove = true;
        lastLocation = transform.position;
        if (direction.Equals("left"))
        {
            transform.Translate(-51, 0f, 0f);
        }
        if (direction.Equals("right"))
        {
            transform.Translate(51, 0f, 0f);
        }
        StartCoroutine(WaitTIme());
    }

    /// <summary>
    /// Törmäyksessä liikkuva auto palautetaan vahnaan poisioniin
    /// Jos PlayerCar törmää WinArea nimiseen spriteen, voitat pelin ja ladataan seuraava scene
    /// </summary>
    /// <param name="col"></param>
    void OnCollisionEnter2D(Collision2D col)
    {
        if (meMove == true)
        {
            transform.position = lastLocation;
        }
        if (col.collider.name.Equals("WinArea"))
        {
            carGameManager.YouWin();
        }
    }

    /// <returns></returns>
    IEnumerator WaitTIme()
    {
        yield return new WaitForSeconds(0.05f);
        meMove = false;
    }
}
