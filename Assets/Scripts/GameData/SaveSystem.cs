using System.Linq;
using UnityEngine;
using YG;

public class SaveSystem : MonoBehaviour
{
    public static SaveSystem Instance { get; private set; }
    [SerializeField] private LevelDataSO levelData;
    private int levelCount = 18;

    private void Awake() {
        if ( Instance != null ) {
            Debug.LogError("Another instance of SaveSystem already exists");
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
    private void Start() {
        if (YandexGame.savesData.levelsDataArray.Length != levelCount) {

            LevelData[] newLevelsDataArray = new LevelData[levelCount];
            int oldLenght = YandexGame.savesData.levelsDataArray.Length;

            for (int i = 0; i < levelCount; i++) {
                if (i < oldLenght) {
                    newLevelsDataArray[i] = YandexGame.savesData.levelsDataArray[i];
                } else {
                    newLevelsDataArray[i] = new LevelData(i + 1, 0, false);
                }
                // YandexGame.savesData.levelsDataArray[i] = new LevelData(i + 1, 0, false);
            }
            YandexGame.savesData.levelsDataArray = newLevelsDataArray;
            SaveProgress();
        }
    }

#region SetData
    public void SetLevelData(LevelData levelData) =>
        YandexGame.savesData.levelsDataArray.Where( d => d.id == levelData.id).First().starCount = levelData.starCount;
    // public void SetItemData(ItemData itemData) =>
    //     YandexGame.savesData.itemsStateList.Find( d => d.itemID == itemData.itemID).itemState = itemData.itemState;
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
    public bool TrySetMoneyValue(int moneyDelta) 
    {
        if (moneyDelta < 0 && Mathf.Abs(moneyDelta) > YandexGame.savesData.moneyValue)
        {
            return false;
        }
        else
        {
            YandexGame.savesData.moneyValue += moneyDelta;
            return true;
        }
    }

    public void CLearYGS() {
        YandexGame.ResetSaveProgress();
        SaveProgress();
    } 

#endregion

#region GetData
    public LevelData        GetLevelData(int levelID)   => YandexGame.savesData.levelsDataArray.Where( d => d.id == levelID).FirstOrDefault();
    // public ItemData         GetItemData(int itemID)     => YandexGame.savesData.itemsStateList.Find( d => d.itemID == itemID);
    public int              GetMoneyValue()              => YandexGame.savesData.moneyValue;

    public LevelData[]      GetLevelDataArray()         => YandexGame.savesData.levelsDataArray;
    // public List<ItemData>   GetItemDataList()           => YandexGame.savesData.itemsStateList;

    public LevelInfo GetLevelInformation(int levelID)   => levelData.levelInfoList.Find( ld => ld.id == levelID);
#endregion

#region TrySaveData
    public void SaveProgress() => YandexGame.SaveProgress();
#endregion
}
