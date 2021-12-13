using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public float mouseSensitivity = 150f; // remove GameManager
    public KeyCode reloadKey; // game manager
    public KeyCode shootKey; // game manager
    public KeyCode switchKey; // game manager
}
