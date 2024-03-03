using System.Collections.Generic;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    public PlayerData playerData {private set; get;}

    private void Awake()
    {
        playerData = new PlayerData(
            new List<LevelData>(){
                new LevelData(1, 3),
                new LevelData(2, 2),
                new LevelData(3, 1),
                new LevelData(4, 0),
                new LevelData(5, 0),
            },
            new List<ItemData>(){
                new ItemData(0, ItemState.Selected),
                new ItemData(1, ItemState.Purchased),
                new ItemData(2, ItemState.Blocked), 
            },
            10000);
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
        playerData.levelsDataList[newLevelData.levelID] = newLevelData;
    }
    public LevelData LoadLevelData(int levelID) {
        return playerData.levelsDataList[levelID];
    }
}
