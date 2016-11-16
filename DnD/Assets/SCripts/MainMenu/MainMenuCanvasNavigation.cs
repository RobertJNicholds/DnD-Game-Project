using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuCanvasNavigation : MonoBehaviour {

    float leftMove = 0.0f;
    float transferTime = 0.5f;
    Vector3 p = Vector3.zero;
    [SerializeField]
    Transform MainMenu = null;
    Vector3 mmStartValue;
    [SerializeField]
    Transform playOnlineMenu = null;
    [SerializeField]
    Transform hostGameMenu = null;
    [SerializeField]
    Transform joinGameMenu = null;

    // Use this for initialization
    void Start() {

        MainMenu.gameObject.SetActive(true);
        playOnlineMenu.gameObject.SetActive(true);
        hostGameMenu.gameObject.SetActive(true);
        joinGameMenu.gameObject.SetActive(true);

        mmStartValue = MainMenu.GetComponent<RectTransform>().position;
        p = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height / 2, Camera.main.nearClipPlane));
        leftMove = mmStartValue.x - p.x;

        playOnlineMenu.position += new Vector3(-leftMove * 2, 0, 0);
        hostGameMenu.position += new Vector3(-leftMove * 2, 0, 0);
        joinGameMenu.position += new Vector3(-leftMove * 2, 0, 0);
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
}
