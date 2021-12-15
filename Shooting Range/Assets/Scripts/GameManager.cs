using System.Collections;
using System.Collections.Generic;
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
    public GameObject pauseGameMenu;
    public GameObject pauseGameButtons;

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
    private void Start()
    {
        PlayerInput.OnPause += PauseGame;
    }
    private void OnDisable()
    {
        PlayerInput.OnPause -= PauseGame;
    }
    public void PauseGame()
    {
        if (isPlaying)
        {
            Time.timeScale = 0;
            isPlaying = false;
            //Cursor.lockState = CursorLockMode.None;
            pauseGameMenu.SetActive(true);
            pauseGameButtons.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            isPlaying = true;
            //Cursor.lockState = CursorLockMode.Locked;
            pauseGameMenu.SetActive(false);
            pauseGameButtons.SetActive(false);
        }
    }

}
