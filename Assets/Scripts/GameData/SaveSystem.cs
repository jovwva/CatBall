using System.Linq;
using UnityEngine;
using YG;

public class SaveSystem : MonoBehaviour
{
    public static SaveSystem Instance { get; private set; }
    [SerializeField] private LevelDataSO levelData;
    [SerializeField] private ShopAssortment  colorAssortment;
    [SerializeField] private ShopAssortment  shapeAssortment;

    private int levelCount = 18;
    private int itemCount = 13;
    private int colorId = 0;
    private int shapeId = 3;

#region MonoBehaviour
    
    private void Awake() 
    {
        transform.SetParent(null);
        if ( Instance != null ) 
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
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
            }
            YandexGame.savesData.levelsDataArray = newLevelsDataArray;
            SaveProgress();
        }

        if (YandexGame.savesData.itemDataArray.Length != itemCount) {

            ItemData[] newItemDataArray = new ItemData[itemCount];
            int oldLenght = YandexGame.savesData.itemDataArray.Length;

            for (int i = 0; i < itemCount; i++) {
                if (i < oldLenght) {
                    newItemDataArray[i] = YandexGame.savesData.itemDataArray[i];
                } else {
                    newItemDataArray[i] = new ItemData(i, ProductStatus.CanBuy);
                }
            }
            YandexGame.savesData.itemDataArray = newItemDataArray;
            SaveProgress();
        }

        colorId = YandexGame.savesData.colorId;
        shapeId = YandexGame.savesData.shapeId;
    }
    
#endregion

#region SetData
    public void SetLevelData(LevelData levelData) =>
        YandexGame.savesData.levelsDataArray.Where( d => d.id == levelData.id).First().starCount = levelData.starCount;
    public void SetItemData(ItemData itemData) =>
        YandexGame.savesData.itemDataArray.Where( d => d.id == itemData.id).First().itemState = itemData.itemState;
    public void TrySetLevelAcces(int levelID) {
        LevelData data = GetLevelData(levelID);

        if (data != null && !data.access)
            data.access = true;
    }
    public bool TryFindLevel(int levelID) => GetLevelData(levelID) != null;
    public bool TrySetMoneyValue(int moneyDelta) 
    {
        if (moneyDelta < 0 && Mathf.Abs(moneyDelta) > YandexGame.savesData.moneyValue)
        {
            Debug.Log("Недостаточно средств!");
            return false;
        }
        else
        {
            Debug.Log("Транзакция осуществлена!");
            YandexGame.savesData.moneyValue += moneyDelta;
            return true;
        }
    }
    public void  SetBackColor(int id) 
    {
        colorId = id;
        YandexGame.savesData.colorId = id;
    } 
    public void  SetBackShape(int id)
    {
        shapeId = id;
        YandexGame.savesData.shapeId = id;
    } 

    public void CLearYGS() 
    {
        YandexGame.ResetSaveProgress();
        SaveProgress();
    } 

#endregion

#region GetData
    public LevelData        GetLevelData(int id)   => YandexGame.savesData.levelsDataArray.Where( d => d.id == id ).FirstOrDefault();
    public ItemData         GetItemData(int id)    => YandexGame.savesData.itemDataArray.Where( d => d.id == id ).FirstOrDefault();
    public int              GetMoneyValue()        => YandexGame.savesData.moneyValue;

    public LevelData[]      GetLevelDataArray()    => YandexGame.savesData.levelsDataArray;
    public ItemData[]       GetItemDataArray()     => YandexGame.savesData.itemDataArray;

    public LevelInfo GetLevelInformation(int levelID)   => levelData.levelInfoList.Find( ld => ld.id == levelID);

    public Color    GetBackColor()
    {
        ItemColorSO itemColor = (ItemColorSO)colorAssortment.itemList.Where( d => d.id == colorId).FirstOrDefault();
        return itemColor.color;
    } 
    public Texture  GetBackShape() 
    {
        ItemShapeSO itemShape = (ItemShapeSO)shapeAssortment.itemList.Where( d => d.id == shapeId).FirstOrDefault();
        return itemShape.shapeTexture;
    }

    public int GetBackColorId() => colorId;
    public int GetBackShapeId() => shapeId;
#endregion

#region TrySaveData
    public void SaveProgress() => YandexGame.SaveProgress();
#endregion
}
