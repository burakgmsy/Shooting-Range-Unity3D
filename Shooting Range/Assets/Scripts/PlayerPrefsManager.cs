using UnityEngine;

public class PlayerPrefsManager : Singleton<PlayerPrefsManager>
{
    private const string LEVEL_PREFS = "Level";

    public void SaveLevel(int level)
    {
        PlayerPrefs.SetInt(LEVEL_PREFS, level);
    }
    public int GetLevel()
    {
        if (!PlayerPrefs.HasKey(LEVEL_PREFS))
        {
            PlayerPrefs.SetInt(LEVEL_PREFS, 1);
        }

        return PlayerPrefs.GetInt(LEVEL_PREFS);
    }
}
