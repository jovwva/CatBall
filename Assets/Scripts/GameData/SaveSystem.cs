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
    public List<LevelData> GetLevelData()   => playerData.levelsDataList;
    public List<ItemData>  GetItemData()    => playerData.itemsStateList;
    public int              GetMoneyData()  => playerData.moneyValue;
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
#endregion
}
