using UnityEngine;
using System.Collections;
using DG.Tweening;
public class MainMenuCanvasNavigation : MonoBehaviour {

    float leftMove = 0.0f;
    float transferTime = 0.5f;
    Vector3 p = Vector3.zero;
    [SerializeField]
    Transform MainMenu = null;
    Vector3 mmStartValue;
    [SerializeField]
    Transform HostGameMenu1 = null;

	// Use this for initialization
	void Start () {
        mmStartValue = MainMenu.GetComponent<RectTransform>().position;
        p = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height / 2, Camera.main.nearClipPlane));
        leftMove = mmStartValue.x - p.x;
        HostGameMenu1.position += new Vector3(-leftMove * 2,0,0);
	}
    public void ExitGame()
    {
        Application.Quit();
    }

    public void BackToMenuFromHostGame()
    {
        Sequence mysequence = DOTween.Sequence();

        mysequence.Append(HostGameMenu1.DOMoveX(-leftMove, transferTime, false));
        mysequence.Append(MainMenu.DOMoveX(leftMove, transferTime, false));
    }

    #region host game functions
    public void MainMenuToHostGameMenu1()
    {
        Sequence mysequence = DOTween.Sequence();

        mysequence.Append(MainMenu.DOMoveX(-leftMove, transferTime, false));
        mysequence.Append(HostGameMenu1.DOMoveX(leftMove, transferTime, false));
    }
    #endregion
}
