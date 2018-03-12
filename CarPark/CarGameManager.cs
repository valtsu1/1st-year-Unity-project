using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CarGameManager : MonoBehaviour
{
    private NextSceneManager nextSceneManager;

    private PlayerCar playerCar;

    private XCar xCar1;
    private XCar xCar2;
    private XCar xCar3;
    private XCar xCar4;
    private XCar xCar5;
    private XCar xCar6;

    private YCar yCar1;
    private YCar yCar2;
    private YCar yCar3;
    private YCar yCar4;
    private YCar yCar5;
    private YCar yCar6;

    private Button right;
    private Button left;
    private Button up;
    private Button down;
    private Text textArea;

    private Button reset;
    private Text buttonText;

    // Use this for initialization
    /// <summary>
    /// Find all cars, buttons and add listener
    /// </summary>
    void Start()
    {
        nextSceneManager = GameObject.Find("NextSceneManager").GetComponent<NextSceneManager>();

        playerCar = GameObject.Find("PlayerCar").GetComponent<PlayerCar>();

        xCar1 = GameObject.Find("X-Car1").GetComponent<XCar>();
        xCar2 = GameObject.Find("X-Car2").GetComponent<XCar>();
        xCar3 = GameObject.Find("X-Car3").GetComponent<XCar>();
        xCar4 = GameObject.Find("X-Car4").GetComponent<XCar>();
        xCar5 = GameObject.Find("X-Car5").GetComponent<XCar>();
        xCar6 = GameObject.Find("X-Car6").GetComponent<XCar>();

        yCar1 = GameObject.Find("Y-Car1").GetComponent<YCar>();
        yCar2 = GameObject.Find("Y-Car2").GetComponent<YCar>();
        yCar3 = GameObject.Find("Y-Car3").GetComponent<YCar>();
        yCar4 = GameObject.Find("Y-Car4").GetComponent<YCar>();
        yCar5 = GameObject.Find("Y-Car5").GetComponent<YCar>();
        yCar6 = GameObject.Find("Y-Car6").GetComponent<YCar>();

        right = GameObject.Find("ButtonRight").GetComponent<Button>();
        left = GameObject.Find("ButtonLeft").GetComponent<Button>();
        up = GameObject.Find("ButtonUp").GetComponent<Button>();
        down = GameObject.Find("ButtonDown").GetComponent<Button>();
        textArea = GameObject.Find("TextField").GetComponent<Text>();

        reset = GameObject.Find("ButtonReset/Continue").GetComponent<Button>();
        reset.onClick.AddListener(ResetGame);
        buttonText = GameObject.Find("ButtonReset/Continue").GetComponentInChildren<Text>();
        buttonText.text = "Reset";

    }

    /// <summary>
    /// Removes listeners and adds right one for the right car
    /// </summary>
    /// <param name="carNumber"></param>
    public void SelectCarX(int carNumber)
    {
        up.interactable = false;
        down.interactable = false;
        left.interactable = true;
        right.interactable = true;
        left.onClick.RemoveAllListeners();
        right.onClick.RemoveAllListeners();
        up.onClick.RemoveAllListeners();
        down.onClick.RemoveAllListeners();
        textArea.text = ("Gray Car");
        switch (carNumber)
        {
            case 0:
                textArea.text = ("Players Car ");
                left.onClick.AddListener(() => playerCar.MoveCar("left"));
                right.onClick.AddListener(() => playerCar.MoveCar("right"));
                break;
            case 1:
                left.onClick.AddListener(() => xCar1.MoveCar("left"));
                right.onClick.AddListener(() => xCar1.MoveCar("right"));
                break;
            case 2:
                left.onClick.AddListener(() => xCar2.MoveCar("left"));
                right.onClick.AddListener(() => xCar2.MoveCar("right"));
                break;
            case 3:
                left.onClick.AddListener(() => xCar3.MoveCar("left"));
                right.onClick.AddListener(() => xCar3.MoveCar("right"));
                break;
            case 4:
                left.onClick.AddListener(() => xCar4.MoveCar("left"));
                right.onClick.AddListener(() => xCar4.MoveCar("right"));
                break;
            case 5:
                left.onClick.AddListener(() => xCar5.MoveCar("left"));
                right.onClick.AddListener(() => xCar5.MoveCar("right"));
                break;
            case 6:
                left.onClick.AddListener(() => xCar6.MoveCar("left"));
                right.onClick.AddListener(() => xCar6.MoveCar("right"));
                break;
        }
    }

    // <summary>
    /// Removes listeners and adds right one for the right car
    /// </summary>
    /// <param name="carNumber"></param>
    public void SelectCarY(int carNumber)
    {
        up.interactable = true;
        down.interactable = true;
        left.interactable = false;
        right.interactable = false;
        up.onClick.RemoveAllListeners();
        down.onClick.RemoveAllListeners();
        left.onClick.RemoveAllListeners();
        right.onClick.RemoveAllListeners();
        textArea.text = ("Red Car");
        switch (carNumber)
        {
            case 1:
                 up.onClick.AddListener(() => yCar1.MoveCar("up"));
                down.onClick.AddListener(() => yCar1.MoveCar("down"));
                break;
            case 2:
                up.onClick.AddListener(() => yCar2.MoveCar("up"));
                down.onClick.AddListener(() => yCar2.MoveCar("down"));
                break;
            case 3:
                up.onClick.AddListener(() => yCar3.MoveCar("up"));
                down.onClick.AddListener(() => yCar3.MoveCar("down"));
                break;
            case 4:
                up.onClick.AddListener(() => yCar4.MoveCar("up"));
                down.onClick.AddListener(() => yCar4.MoveCar("down"));
                break;
            case 5:
                up.onClick.AddListener(() => yCar5.MoveCar("up"));
                down.onClick.AddListener(() => yCar5.MoveCar("down"));
                break;
            case 6:
                up.onClick.AddListener(() => yCar6.MoveCar("up"));
                down.onClick.AddListener(() => yCar6.MoveCar("down"));
                break;
        }
    }

    /// <summary>
    /// Makes other buttons uninteractable
    /// Changes button text to "You WIn"
    /// removes old listeners and adds new one
    /// </summary>
    public void YouWin()
    {
        up.interactable = false;
        down.interactable = false;
        left.interactable = false;
        right.interactable = false;
        textArea.text = "You Win";

        buttonText.text = "Continue";
        reset.onClick.RemoveAllListeners();
        reset.onClick.AddListener(NextScene);

    }

    /// <summary>
    /// Loads same scene
    /// </summary>
    private void ResetGame()
    {
        SceneManager.LoadScene("CarParkGame");
    }

    /// <summary>
    /// Loads next scene
    /// </summary>
    private void NextScene()
    {
        nextSceneManager.NextScene();
    }
}
        
