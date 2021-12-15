using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneLaodManager : MonoBehaviour
{
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
