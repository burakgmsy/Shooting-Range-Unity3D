using UnityEngine;

public class PauseGame : MonoBehaviour
{



    public GameObject pauseGameMenu;
    public GameObject pauseGameButtons;
    private void OnEnable()
    {
        PlayerInput.OnPause += Pause;
    }
    void OnDisable()
    {
        PlayerInput.OnPause -= Pause;
    }
    public void Pause()
    {
        if (GameManager.Instance.isPlaying)
        {
            Time.timeScale = 0;
            GameManager.Instance.isPlaying = false;
            //Cursor.lockState = CursorLockMode.None;
            pauseGameMenu.SetActive(true);
            pauseGameButtons.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            GameManager.Instance.isPlaying = true;
            //Cursor.lockState = CursorLockMode.Locked;
            pauseGameMenu.SetActive(false);
            pauseGameButtons.SetActive(false);
        }
    }
}
