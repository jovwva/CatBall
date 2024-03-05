using System.Collections.Generic;

public enum ItemState {
    Blocked,
    Purchased,
    Selected,
}

[System.Serializable]
public class LevelData {
    public int levelID;
    public int starCount;

    public LevelData(int levelID, int starCount)
    {
        this.levelID    = levelID;
        this.starCount  = starCount;
    }
}

[System.Serializable]
public class ItemData {
    public int          itemID;
    public ItemState    itemState;

    public ItemData(int itemID, ItemState itemState)
    {
        this.itemID     = itemID;
        this.itemState  = itemState;
    }
}

[System.Serializable]
public class PlayerData {
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