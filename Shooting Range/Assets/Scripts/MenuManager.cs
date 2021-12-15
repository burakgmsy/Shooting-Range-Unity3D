using UnityEngine;
public class MenuManager : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject inGameMenu;
    public GameObject startChild;
    public GameObject startButtonChild;
    public GameObject levelManagerObject;
    public GameObject continueButton;
    public GameObject continueObj;
    public bool isPlaying;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }
    public void StartGame()
    {
        startButtonChild.SetActive(true);
        startChild.SetActive(true);
        if (PlayerPrefsManager.Instance.GetLevel() < 2)
        {
            continueButton.SetActive(false);
            continueObj.SetActive(false);
        }
    }
    public void NewGame()
    {
        PlayerPrefsManager.Instance.ResetLevel();
        PlayingGame();

        //ingame actived
        //mainmenu close
    }

    public void ContinueGame()
    {
        PlayingGame();
    }

    public void PlayingGame()
    {
        GameManager.Instance.isMainMenu = false;
        inGameMenu.SetActive(true);
        mainMenu.SetActive(false);
        levelManagerObject.SetActive(true);
        GameManager.Instance.isPlaying = true;
        isPlaying = true;
        Cursor.lockState = CursorLockMode.Locked;
    }




}
