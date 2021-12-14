using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelManager : Singleton<LevelManager>
{
    public TMP_Text level;
    [SerializeField] private int currentLevel;
    private Dictionary<int, LevelData> myLevel = new Dictionary<int, LevelData>();
    public LevelData[] levelType;
    [SerializeField] private int deadCounter;


    private void Start()
    {
        PlayerPrefsManager.Instance.ResetLevel();
        DamageableObject.Dead += DeadCounterObserver;
        AddLevels();
        LevelCheck();
        SpawnObject();
    }

    private void SpawnObject()
    {
        ObjectPool.Instance.AllObjDeActived();
        for (int i = 0; i < myLevel[currentLevel].targetCount; i++)
        {
            GameObject obj = ObjectPool.Instance.GetPooledObject(myLevel[currentLevel].poolIndex);
            var calculatedPos = CalculateTargetPosition();
            //target coloru da değiştire biliriz..
            obj.transform.position = new Vector3(calculatedPos.x, obj.transform.position.y, calculatedPos.z);
            //get componant ile base class'a ulaşılabilir mi?
            // observer ile çözüldü

            foreach (Renderer renderer in obj.GetComponentsInChildren<Renderer>())
            {
                renderer.material = myLevel[currentLevel].material;
                //Break objeler SetActive false olduğu için materialı alamıyor. 
            }
        }
    }
    public void DeadCounterObserver(bool value)
    {
        if (value)
        {
            deadCounter++;
            if (deadCounter >= 5)
                NextLevel();
            //level success
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
        level.text = "Level " + currentLevel;
    }


    private void NextLevel()
    {
        deadCounter = 0;
        if (currentLevel < myLevel.Count)
            PlayerPrefsManager.Instance.SaveLevel(currentLevel + 1);
        LevelCheck();
        SpawnObject();

    }
}
