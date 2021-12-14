using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    [SerializeField] private int currentLevel;
    private Dictionary<int, LevelData> myLevel = new Dictionary<int, LevelData>();
    public List<DamageableObject> objList;
    public LevelData[] levelType;
    [SerializeField] private int deadCounter;


    private void Start()
    {
        DamageableObject.Dead += DeadCounterObserver;
        AddLevels();
        LevelCheck();
        SpawnObject();
    }

    private void SpawnObject()
    {
        for (int i = 0; i < myLevel[currentLevel].targetCount; i++)
        {
            GameObject obj = ObjectPool.Instance.GetPooledObject(myLevel[currentLevel].poolIndex);
            var calculatedPos = CalculateTargetPosition();
            obj.transform.position = new Vector3(calculatedPos.x, obj.transform.position.y, calculatedPos.z);
            //get componant ile base class'a ulaşılabilir mi?
            // observer ile çözüldü
        }
    }
    public void DeadCounterObserver(bool value)
    {
        if (value)
        {
            deadCounter++;
            if (deadCounter >= 5)
                Debug.Log("NextLevel");
        }


    }
    public void CheckObject()
    {
        foreach (DamageableObject obj in objList)
        {
            Debug.Log(obj.CurrentHp);
        }
    }
    private Vector3 CalculateTargetPosition()
    {
        var zPos = Random.Range(-19, 15);
        var xPos = Random.Range(-6, 6);
        return new Vector3(xPos, 0, zPos);
    }
    private void AddLevels()
    {
        for (int i = 0; i < levelType.Length; i++)
        {
            myLevel.Add(i + 1, levelType[i]);
        }
    }

    private void LevelCheck()
    {
        foreach (var level in myLevel)
        {
            if (PlayerPrefsManager.Instance.GetLevel() == level.Key)
            {
                currentLevel = level.Key;
                break;
            }
        }
        DisplayLevel();
    }

    private void DisplayLevel()
    {
        Debug.Log(currentLevel);

        Debug.Log(myLevel[currentLevel].levelIndex);
    }


    private void NextLevel()
    {
        if (currentLevel < myLevel.Count)
            PlayerPrefsManager.Instance.SaveLevel(currentLevel + 1);

    }
}
