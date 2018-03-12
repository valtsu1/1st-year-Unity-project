using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MapManager : MonoBehaviour
{

    private static int timesVisited = 0;

    private Button home;
    private Button shop;
    private Button studentFunding;
    private Button graveYard;
    private Button arcade;
    private Button gym;
    private Button fishingHut;
    private Button radioStation;
    private Button church;
    private Button castle;
    private Button hotel;

    private List<Button> buttonList = new List<Button>();

    // Use this for initialization
    /// <summary>
    /// Find all buttons, make a list, add Listeners, make all buttons not interactable
    /// </summary>
    void Start()
    {
        home = GameObject.Find("HomeButton").GetComponent<Button>();
        shop = GameObject.Find("ShopButton").GetComponent<Button>();
        studentFunding = GameObject.Find("StudentFundingButton").GetComponent<Button>();
        graveYard = GameObject.Find("GraveYardButton").GetComponent<Button>();
        arcade = GameObject.Find("ArcadeButton").GetComponent<Button>();
        gym = GameObject.Find("GymButton").GetComponent<Button>();
        fishingHut = GameObject.Find("FishingHutButton").GetComponent<Button>();
        radioStation = GameObject.Find("RadioStationButton").GetComponent<Button>();
        church = GameObject.Find("ChurchButton").GetComponent<Button>();
        castle = GameObject.Find("CastleButton").GetComponent<Button>();
        hotel = GameObject.Find("HotelButton").GetComponent<Button>();

        buttonList.Add(home);
        buttonList.Add(shop);
        buttonList.Add(studentFunding);
        buttonList.Add(graveYard);
        buttonList.Add(arcade);
        buttonList.Add(gym);
        buttonList.Add(fishingHut);
        buttonList.Add(radioStation);
        buttonList.Add(church);
        buttonList.Add(castle);
        buttonList.Add(hotel);

        home.onClick.AddListener(() => LoadScene(2));
        shop.onClick.AddListener(() => LoadScene(3));
        studentFunding.onClick.AddListener(() => LoadScene(4));
        graveYard.onClick.AddListener(() => LoadScene(5));
        arcade.onClick.AddListener(() => LoadScene(8));
        gym.onClick.AddListener(() => LoadScene(11));
        fishingHut.onClick.AddListener(() => LoadScene(13));
        radioStation.onClick.AddListener(() => LoadScene(14));
        church.onClick.AddListener(() => LoadScene(17));
        castle.onClick.AddListener(() => LoadScene(19));
        hotel.onClick.AddListener(() => LoadScene(22));

        for (int x = 0; x <= 10; x++)
        {
            buttonList[x].interactable = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        ButtonsActive(timesVisited);
    }

    /// <summary>
    /// Chooses what buttons are active
    /// </summary>
    /// <param name="visited"></param>
    private void ButtonsActive(int visited)
    {
        switch (visited)
        {
            case 1:
                for (int x = 0; x <= 0; x++)
                {
                    buttonList[x].interactable = true;
                }
                break;
            case 2:
                for (int x = 0; x <= 1; x++)
                {
                    buttonList[x].interactable = true;
                }
                break;
            case 3:
                for (int x = 0; x <= 2; x++)
                {
                    buttonList[x].interactable = true;
                }
                break;
            case 4:
                for (int x = 0; x <= 5; x++)
                {
                    buttonList[x].interactable = true;
                }
                break;
            case 5:
                for (int x = 0; x <= 6; x++)
                {
                    buttonList[x].interactable = true;
                }
                break;
            case 6:
                for (int x = 0; x <= 9; x++)
                {
                    buttonList[x].interactable = true;
                }
                break;
            default:
                for (int x = 0; x <= 10; x++)
                {
                    buttonList[x].interactable = true;
                }
                break;
        }
    }

    /// <summary>
    /// Loads next scene
    /// </summary>
    /// <param name="sceneNumber"></param>
    private void LoadScene(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }

    /// <summary>
    /// Player can only increse timesVisited, if he comes from right level
    /// this prevents player from only playing first level and growing the timesVisited counter
    /// </summary>
    /// <param name="LevelLocation"></param>
    public static void UnlockNextLevel(int LevelLocation)
    {
        if (LevelLocation == 0 && timesVisited == 0)
        {
            timesVisited++;
        }
        else if (LevelLocation == 1 && timesVisited == 1)
        {
            timesVisited++;
        }
        else if (LevelLocation == 2 && timesVisited == 2)
        {
            timesVisited++;
        }
        else if (LevelLocation == 3 && timesVisited == 3)
        {
            timesVisited++;
        }
        else if (LevelLocation == 4 && timesVisited == 4)
        {
            timesVisited++;
        }
        else if (LevelLocation == 5 && timesVisited == 5)
        {
            timesVisited++;
        }
        else if (LevelLocation == 6 && timesVisited == 6)
        {
            timesVisited++;
        }
    }
}
