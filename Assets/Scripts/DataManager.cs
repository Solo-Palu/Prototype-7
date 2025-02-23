using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public string playerName;
    public string bestPlayerName;
    public int bestScore;
    private string saveFilePath;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        saveFilePath = Application.persistentDataPath + "/savefile.json";
        LoadData();
    }

    [System.Serializable]
    class SaveData
    {
        public string bestPlayerName;
        public int bestScore;
    }

    public void SaveNewData()
    {
        SaveData data = new SaveData
        {
            bestPlayerName = bestPlayerName,
            bestScore = bestScore
        };

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(saveFilePath, json);
    }

    public void LoadData()
    {
        if (File.Exists(saveFilePath))
        {
            string json = File.ReadAllText(saveFilePath);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            bestPlayerName = string.IsNullOrEmpty(data.bestPlayerName) ? "None" : data.bestPlayerName;
            bestScore = data.bestScore;
        } else
        {
            bestPlayerName = "none";
            bestScore = 0;
        }
    }
}
