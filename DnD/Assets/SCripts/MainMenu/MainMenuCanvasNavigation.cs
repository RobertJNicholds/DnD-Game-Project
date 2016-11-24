using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuCanvasNavigation : MonoBehaviour {

    float leftMove = 0.0f;
    float transferTime = 0.5f;

    Vector3 CentreStartPosition = Vector3.zero;
    Vector3 p = Vector3.zero;
    [SerializeField]
    Transform BackgroundMapThing = null;
    [SerializeField]
    Transform MainMenu = null;
    Vector3 mmStartValue;
    [SerializeField]
    Transform playOnlineMenu = null;
    [SerializeField]
    Transform hostGameMenu = null;
    [SerializeField]
    Transform joinGameMenu = null;
    [SerializeField]
    Transform createMainMenu = null;
    [SerializeField]
    Transform createMapMenu = null;
    [SerializeField]
    Transform createCampaignMenu = null;


    IndevidualCanvasITems canvasCreationScript;

    // Use this for initialization
    void Start() {

        canvasCreationScript =  GetComponent<IndevidualCanvasITems>();

        MainMenu.gameObject.SetActive(true);
        playOnlineMenu.gameObject.SetActive(true);
        hostGameMenu.gameObject.SetActive(true);
        joinGameMenu.gameObject.SetActive(true);
        createMainMenu.gameObject.SetActive(true);
        createMapMenu.gameObject.SetActive(true);
        createCampaignMenu.gameObject.SetActive(true);

        mmStartValue = MainMenu.GetComponent<RectTransform>().position;
        p = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height / 2, Camera.main.nearClipPlane));
        leftMove = mmStartValue.x - p.x;
        CentreStartPosition = BackgroundMapThing.position;

        playOnlineMenu.position += new Vector3(-leftMove * 2, 0, 0);
        hostGameMenu.position += new Vector3(-leftMove * 2, 0, 0);
        joinGameMenu.position += new Vector3(-leftMove * 2, 0, 0);
        createMainMenu.position += new Vector3(-leftMove * 2, 0, 0);
        createMapMenu.position += new Vector3(-leftMove * 2, 0, 0);
        createCampaignMenu.position += new Vector3(-leftMove * 2, 0, 0);
    }
    public void ExitGame()
    {
        Application.Quit();
    }

    public void BackToMenuFromHostGame()
    {
        Sequence mysequence = DOTween.Sequence();

        mysequence.Append(playOnlineMenu.DOMoveX(-leftMove, transferTime, false));
        mysequence.Append(MainMenu.DOMoveX(leftMove, transferTime, false));
    }

    public void MainMenuToPlayOnlineMenu()
    {
        Sequence mysequence = DOTween.Sequence();

        mysequence.Append(MainMenu.DOMoveX(-leftMove, transferTime, false));
        mysequence.Append(playOnlineMenu.DOMoveX(leftMove, transferTime, false));
    }

    #region multiplayer navigation functions

    /// <summary>
    /// HOST GAME
    /// </summary>
    public void OnlineMenuToHostGameMenu()
    {
        Sequence mysequence = DOTween.Sequence();

        mysequence.Append(playOnlineMenu.DOMoveX(-leftMove, transferTime, false));
        mysequence.Append(hostGameMenu.DOMoveX(leftMove, transferTime, false));
    }

    public void HostGameMenuToOnlineMenu()
    {
        Sequence mysequence = DOTween.Sequence();

        mysequence.Append(hostGameMenu.DOMoveX(-leftMove, transferTime, false));
        mysequence.Append(playOnlineMenu.DOMoveX(leftMove, transferTime, false));
    }
    /// <summary>
    /// JOIN GAME
    /// </summary>
    public void OnlineMenuToJoinGameMenu()
    {
        Sequence mysequence = DOTween.Sequence();

        mysequence.Append(playOnlineMenu.DOMoveX(-leftMove, transferTime, false));
        mysequence.Append(joinGameMenu.DOMoveX(leftMove, transferTime, false));
    }

    public void JoinGameMenuToOnlineMenu()
    {
        Sequence mysequence = DOTween.Sequence();

        mysequence.Append(joinGameMenu.DOMoveX(-leftMove, transferTime, false));
        mysequence.Append(playOnlineMenu.DOMoveX(leftMove, transferTime, false));
    }

    /// <summary>
    /// host the game/become the server
    /// </summary>
    public void CreateGameHostSession()
    {
        string password = hostGameMenu.GetChild(2).GetChild(1).GetComponent<Text>().text;
    }

    public void JoinGameServer()
    {
        string gameName = joinGameMenu.GetChild(1).GetChild(1).GetComponent<Text>().text;
        string password = joinGameMenu.GetChild(2).GetChild(1).GetComponent<Text>().text;
    }
    #endregion

    #region create menu navigation

    public void MainMenuToCreateMainMenu()
    {
        Sequence mysequence = DOTween.Sequence();

        mysequence.Append(MainMenu.DOMoveX(-leftMove, transferTime, false));
        mysequence.Append(createMainMenu.DOMoveX(leftMove, transferTime, false));
    }

    public void CreateMainMenuToMainMenu()
    {
        Sequence mysequence = DOTween.Sequence();

        mysequence.Append(createMainMenu.DOMoveX(-leftMove, transferTime, false));
        mysequence.Append(MainMenu.DOMoveX(leftMove, transferTime, false));
    }

    public void CreateMainMenuToCreateMapMenu()
    {
        Sequence mysequence = DOTween.Sequence();

        mysequence.Append(createMainMenu.DOMoveX(-leftMove, transferTime, false));
        mysequence.Append(createMapMenu.DOMoveX(leftMove, transferTime, false));


        Vector3 screenpos = new Vector3(Screen.width, Screen.height / 2, 0.0f);
        Vector3 cameraRightPain = Camera.main.ScreenToWorldPoint(screenpos);
        float xDistance = Vector3.Distance(BackgroundMapThing.position, cameraRightPain);
        Vector3 movePosition = new Vector3(BackgroundMapThing.position.x + (xDistance * 1.25f), BackgroundMapThing.position.y, BackgroundMapThing.position.z);

        BackgroundMapThing.DOMove(movePosition, 1, false);
    }

    public void GenerateMap()
    {

        bool createMap = true;
        if (createMapMenu.GetChild(5).GetChild(0).GetComponent<Text>().text == "CHOOSE MAP TYPE")
        {
            createMap = false;
            //display error message
        }
       
        if (createMapMenu.GetChild(3).GetChild(0).GetComponent<Text>().text == "MAP HEIGHT")
        {
            //return error
            createMap = false;
        }

       
        if (createMapMenu.GetChild(4).GetChild(0).GetComponent<Text>().text == "MAP HEIGHT")
        {
            createMap = false;
            
            //return error
        }

        int numX = 0;
        int numY = 0;

        if (createMap)
        {
            int.TryParse(createMapMenu.GetChild(3).GetChild(0).GetComponent<Text>().text, out numX);
            int.TryParse(createMapMenu.GetChild(4).GetChild(0).GetComponent<Text>().text, out numY);
            canvasCreationScript.GenerateGridWithDimentions(createMapMenu.GetChild(5).GetChild(0).GetComponent<Text>().text, numX, numY);
        }
       
    }

    public void CreateMapMenuToCreateMainMenu()
    {
        Sequence mysequence = DOTween.Sequence();

        mysequence.Append(createMapMenu.DOMoveX(-leftMove, transferTime, false));
        mysequence.Append(createMainMenu.DOMoveX(leftMove, transferTime, false));

        BackgroundMapThing.DOMove(CentreStartPosition, 1, false);
    }

    public void CreateMainMenuToCreateCampaignMenu()
    {
        Sequence mysequence = DOTween.Sequence();

        mysequence.Append(createMainMenu.DOMoveX(-leftMove, transferTime, false));
        mysequence.Append(createCampaignMenu.DOMoveX(leftMove, transferTime, false));

        Vector3 screenpos = new Vector3(Screen.width, Screen.height / 2, 0.0f);
        Vector3 cameraRightPain = Camera.main.ScreenToWorldPoint(screenpos);
        float xDistance = Vector3.Distance(BackgroundMapThing.position, cameraRightPain);
        Vector3 movePosition = new Vector3(BackgroundMapThing.position.x + xDistance, BackgroundMapThing.position.y, BackgroundMapThing.position.z);

        BackgroundMapThing.DOMove(movePosition, 1, false);

        
       
    }

    public void CreateCampaignMenuToCreateMainMenu()
    {
        Sequence mysequence = DOTween.Sequence();

        mysequence.Append(createCampaignMenu.DOMoveX(-leftMove, transferTime, false));
        mysequence.Append(createMainMenu.DOMoveX(leftMove, transferTime, false));
        

    }


    #endregion
}
