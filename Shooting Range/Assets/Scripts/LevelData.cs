using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Level Data", menuName = "Level Data")]
public class LevelData : ScriptableObject
{
    public int levelIndex;
    public int targetCount;
    public int poolIndex;
    public Color targetColor;
}
