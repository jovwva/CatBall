using System.Collections.Generic;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    private PlayerData playerData;
    public void SaveLevelData(int levelID, int starCount)
    {
        if (playerData.levelsDataList[levelID].starCount < starCount)
        {
            LevelData newLevelData = new LevelData(levelID, starCount);

            playerData.levelsDataList[levelID] = newLevelData;
        }
    }
    public int LoadLevelData(int levelID)
    {
        return playerData.levelsDataList[levelID].starCount;
    }
}
