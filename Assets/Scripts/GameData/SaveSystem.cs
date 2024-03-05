using System.Collections.Generic;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    private PlayerData playerData;

    private void Awake() {
        LoadProgress();
    }

#region SetData
    public void SetMoneyValue(int delta) => 
        playerData.moneyValue += delta;
    public void SetLevelData(LevelData levelData) =>
        playerData.levelsDataList.Find( d => d.levelID == levelData.levelID).starCount = levelData.starCount;
    public void SetItemData(ItemData itemData) =>
        playerData.itemsStateList.Find( d => d.itemID == itemData.itemID).itemState = itemData.itemState;
#endregion

#region GetData
    public LevelData        GetLevelData(int levelID)   => playerData.levelsDataList.Find( d => d.levelID == levelID);
    public ItemData         GetItemData(int itemID)     => playerData.itemsStateList.Find( d => d.itemID == itemID);
    public int              GetMoneyData()              => playerData.moneyValue;

    public List<LevelData>  GetLevelDataList()          => playerData.levelsDataList;
    public List<ItemData>   GetItemDataList()           => playerData.itemsStateList;
#endregion

#region Save\Load
    public void SaveProgress() {
        string jsonString = JsonUtility.ToJson(playerData);
        PlayerPrefs.SetString("Progress", jsonString);
        Debug.Log("Новые данные сохранены!");
    }
    public void LoadProgress() {
        string jsonString = PlayerPrefs.GetString("Progress", "null");
        JsonConversion(jsonString);
    }
    private void JsonConversion(string value) {
        if (value != "null") {
            playerData = JsonUtility.FromJson<PlayerData>(value);
        } else {
            playerData = new PlayerData(
            new List<LevelData>(){
                new LevelData(1, 2),
                new LevelData(2, 2),
                new LevelData(3, 0),
                new LevelData(4, 1),
                new LevelData(5, 0),
            },
            new List<ItemData>(){
                new ItemData(0, ItemState.Selected),
                new ItemData(1, ItemState.Purchased),
                new ItemData(2, ItemState.Blocked), 
            },
            10000);
            SaveProgress();
        }  
    }
#endregion
}
