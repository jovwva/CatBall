using System.Collections.Generic;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    public PlayerData playerData;

    private void Awake()
    {
        LoadProgress();
    }

    public void TrySaveLevelData(int levelID, int starCount)
    {
        if (playerData.levelsDataList[levelID].starCount < starCount)
        {
            LevelData newLevelData = new LevelData(levelID, starCount);
            SaveLevelData(newLevelData);
        }
    }

    private void SaveLevelData( LevelData newLevelData ) {
        if (playerData.levelsDataList[newLevelData.levelID].starCount == 0) {
            playerData.levelsDataList[newLevelData.levelID + 1] = 
                new LevelData(newLevelData.levelID + 1, 0);
        }
        playerData.levelsDataList[newLevelData.levelID] = newLevelData;    
        SaveProgress();    
    }
    public LevelData LoadLevelData(int levelID) {
        return playerData.levelsDataList[levelID];
    }

    private void SaveProgress()
    {
        string jsonString = JsonUtility.ToJson(playerData);
        PlayerPrefs.SetString("Progress", jsonString);
    }
    private void LoadProgress()
    {
        string jsonString = PlayerPrefs.GetString("Progress", "null");
        JsonConversion(jsonString);
    }
    private void JsonConversion(string value)
    {
        if (value != "null") {
            playerData = JsonUtility.FromJson<PlayerData>(value);
            Debug.Log("Данные успешно загружены");
        } else {
            playerData = new PlayerData(
            new List<LevelData>(){
                new LevelData(1, 3),
                new LevelData(2, 2),
                new LevelData(3, 1),
                new LevelData(4, 0),
                new LevelData(5, -1),
            },
            new List<ItemData>(){
                new ItemData(0, ItemState.Selected),
                new ItemData(1, ItemState.Purchased),
                new ItemData(2, ItemState.Blocked), 
            },
            10000);
            SaveProgress();
            Debug.Log("Данные не обнаруженны, создаю новое сохранение");
        }  
    }
}
