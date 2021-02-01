using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

/*
 * Save and load player data from persistent data path
 */

public class PlayerProfileHandler : MonoBehaviour
{
    string JSONString;

    PlayerSaveData saveData;

    public static PlayerProfileHandler Instance;

    public int CurrentHiScore
    {
        get
        {
            return saveData.CurrentHighScore;
        }
    }

    public int SessionScore
    {
        get
        {
            return saveData.SessionScore;
        }
    }

    private void Awake()
    {
        Load();

        UpdateSessionScore(0);

        Instance = this;
    }

    public void Save()
    {
        JSONString = JsonUtility.ToJson(saveData);
        File.WriteAllText(Application.persistentDataPath + "/AsteroidSave.json", JSONString);
    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/AsteroidSave.json"))
        {
            JSONString = File.ReadAllText(Application.persistentDataPath + "/AsteroidSave.json");
            saveData = JsonUtility.FromJson<PlayerSaveData>(JSONString);
        }
        else
        {
            saveData = new PlayerSaveData();

            Save();
        }
    }

    public void UpdateSessionScore(int NewScore)
    {
        if(NewScore > CurrentHiScore)
        {
            saveData.CurrentHighScore = NewScore;
        }

        saveData.SessionScore = NewScore;

        Save();
    }
}

[System.Serializable]
public class PlayerSaveData
{
    public int CurrentHighScore;
    public int SessionScore;
}
