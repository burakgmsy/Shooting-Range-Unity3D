using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    //Observer DesingPattern
    public static event Action<Vector2> MouseVector;
    public static event Action OnShootSingle = delegate { };
    public static event Action OnShootAuto = delegate { };
    public static event Action OnReload = delegate { };
    public static event Action OnSwitch = delegate { };
    public static event Action OnRevive = delegate { };
    public static event Action OnPause = delegate { };
    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * GameManager.Instance.mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * GameManager.Instance.mouseSensitivity * Time.deltaTime;
        if (GameManager.Instance.isPlaying)
        {
            Cursor.lockState = CursorLockMode.Locked;
            MouseVector?.Invoke(new Vector2(mouseX, mouseY));
            Time.timeScale = 1;

            if (Input.GetKeyDown(GameManager.Instance.shootKey))
                OnShootSingle();

            if (Input.GetKey(GameManager.Instance.shootKey))
                OnShootAuto();

            if (Input.GetKeyDown(GameManager.Instance.reloadKey))
                OnReload();

            if (Input.GetKeyDown(GameManager.Instance.switchKey))
                OnSwitch();

            if (Input.GetKeyDown(GameManager.Instance.reviveKey))
                OnRevive();

        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
        if (Input.GetKeyDown(GameManager.Instance.pauseKey) && !GameManager.Instance.isMainMenu)
            OnPause();



    }


}
