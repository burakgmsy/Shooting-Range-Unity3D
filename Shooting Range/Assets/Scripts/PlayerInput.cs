using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float mouseSensitivity = 150f; // remove GameManager


    //Observer DesingPattern
    public static event Action<Vector2> MouseVector;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        MouseVector?.Invoke(new Vector2(mouseX, mouseY));
    }

}
