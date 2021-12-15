using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class GameManager : Singleton<GameManager>
{

    public float mouseSensitivity = 150f;
    public bool isPlaying;
    public KeyCode reloadKey;
    public KeyCode shootKey;
    public KeyCode switchKey;
    public KeyCode reviveKey;
    public KeyCode pauseKey;

    [Header("In Game UI MANAGER")]
    public TMP_Text levelText;
    public TMP_Text levelSuccess = null;
    public TMP_Text cuurentAmmo;
    public TMP_Text ReloadText;

    
    public void DisplayLevel(int level)
    {
        levelText.text = "Level " + level;
    }
    public void DisplayLevelSuccess(string value)
    {
        levelSuccess.text = value;
    }
    public void DisplayAmmo(int currentAmmo, int maxAmmo)
    {
        cuurentAmmo.text = "Ammo: " + currentAmmo + " / " + maxAmmo;
    }
    public void DisplayReloading(string value)
    {
        ReloadText.text = value;
    }
    public void MainMenu()
    {
        SceneManager.LoadScene((int)Scene.GameScene);
    }
    public void TraningMode()
    {
        Cursor.lockState = CursorLockMode.Locked;
        SceneManager.LoadScene((int)Scene.TraningScene);
    }
    public void ExitGame()
    {
        Application.Quit();
    }

}
