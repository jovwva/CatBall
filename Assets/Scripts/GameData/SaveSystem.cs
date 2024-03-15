using System.Collections.Generic;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    public static SaveSystem Instance { get; private set; }
    [SerializeField] private LevelDataSO levelData;
    private PlayerData playerData;

    private void Awake() {
        if ( Instance != null ) {
            Debug.LogError("Another instance of SaveSystem already exists");
            Destroy(gameObject);
            return;
        }
        LoadProgress();
        Instance = this;
    }

#region SetData
    public void SetMoneyValue(int delta) => 
        playerData.moneyValue += delta;
    public void SetLevelData(LevelData levelData) =>
        playerData.levelsDataList.Find( d => d.id == levelData.id).starCount = levelData.starCount;
    public void SetItemData(ItemData itemData) =>
        playerData.itemsStateList.Find( d => d.itemID == itemData.itemID).itemState = itemData.itemState;
    public bool TrySetLevelAcces(int levelID) {
        LevelData data = GetLevelData(levelID);

        if (data != null && !data.access)
        {
            data.access = true;
            return true;
        }

        return false;
    }
    public bool TryFindLevel(int levelID) => GetLevelData(levelID) != null;

#endregion

#region GetData
    public LevelData        GetLevelData(int levelID)   => playerData.levelsDataList.Find( d => d.id == levelID);
    public ItemData         GetItemData(int itemID)     => playerData.itemsStateList.Find( d => d.itemID == itemID);
    public int              GetMoneyData()              => playerData.moneyValue;

    public List<LevelData>  GetLevelDataList()          => playerData.levelsDataList;
    public List<ItemData>   GetItemDataList()           => playerData.itemsStateList;

    public LevelInfo GetLevelInformation(int levelID)   => levelData.levelInfoList.Find( ld => ld.id == levelID);
#endregion

#region Save\Load
    public void SaveProgress() {
        string jsonString = JsonUtility.ToJson(playerData);
        PlayerPrefs.SetString("Progress", jsonString);
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
                new LevelData(1, 0, true),
                new LevelData(2, 0, false),
                new LevelData(3, 0, false),
                new LevelData(4, 0, false),
                new LevelData(5, 0, false),

                // Test data
                // new LevelData(1, 1, true),
                // new LevelData(2, 1, true),
                // new LevelData(3, 1, true),
                // new LevelData(4, 1, true),
                // new LevelData(5, 1, true),
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
