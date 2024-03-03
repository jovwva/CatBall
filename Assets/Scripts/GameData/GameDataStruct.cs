using System.Collections.Generic;

[System.Serializable]
public struct LevelData
{
    public int levelID;
    public int starCount;

    public LevelData(int levelID, int starCount)
    {
        this.levelID    = levelID;
        this.starCount  = starCount;
    }
}

public enum ItemState {
    Blocked,
    Purchased,
    Selected,
}
[System.Serializable]
public struct ItemData
{
    public int          itemID;
    public ItemState    itemState;

    public ItemData(int itemID, ItemState itemState)
    {
        this.itemID     = itemID;
        this.itemState  = itemState;
    }
}
[System.Serializable]
public struct PlayerData 
{
    public List<LevelData> levelsDataList;
    public List<ItemData> itemsStateList;
    public int moneyValue;

    public PlayerData(List<LevelData> levelsDataList, List<ItemData> itemsStateList, int moneyValue)
    {
        this.levelsDataList = levelsDataList;
        this.itemsStateList = itemsStateList;
        this.moneyValue     = moneyValue;
    }
}