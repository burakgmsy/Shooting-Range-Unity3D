using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    public Transform playerBody;
    float xRotation = 0f;
    private void Start()
    {
        PlayerInput.MouseVector += LookAround; //Observer DesingPattern
    }

    private void LookAround(Vector2 vector)
    {
        xRotation -= vector.y;
        xRotation = Mathf.Clamp(xRotation, -90, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up, vector.x);
    }
}
