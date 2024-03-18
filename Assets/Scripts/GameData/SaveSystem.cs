using System.Collections.Generic;
using UnityEngine;
using YG;

public class SaveSystem : MonoBehaviour
{
    public static SaveSystem Instance { get; private set; }
    [SerializeField] private LevelDataSO levelData;

    private void Awake() {
        if ( Instance != null ) {
            Debug.LogError("Another instance of SaveSystem already exists");
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

#region SetData
    public void SetMoneyValue(int delta) => 
        YandexGame.savesData.moneyValue += delta;
    public void SetLevelData(LevelData levelData) =>
        YandexGame.savesData.levelsDataList.Find( d => d.id == levelData.id).starCount = levelData.starCount;
    public void SetItemData(ItemData itemData) =>
        YandexGame.savesData.itemsStateList.Find( d => d.itemID == itemData.itemID).itemState = itemData.itemState;
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
    public LevelData        GetLevelData(int levelID)   => YandexGame.savesData.levelsDataList.Find( d => d.id == levelID);
    public ItemData         GetItemData(int itemID)     => YandexGame.savesData.itemsStateList.Find( d => d.itemID == itemID);
    public int              GetMoneyData()              => YandexGame.savesData.moneyValue;

    public List<LevelData>  GetLevelDataList()          => YandexGame.savesData.levelsDataList;
    public List<ItemData>   GetItemDataList()           => YandexGame.savesData.itemsStateList;

    public LevelInfo GetLevelInformation(int levelID)   => levelData.levelInfoList.Find( ld => ld.id == levelID);
#endregion

#region TrySaveData
    public void SaveProgress() {
        YandexGame.SaveProgress();
    }
#endregion
}
