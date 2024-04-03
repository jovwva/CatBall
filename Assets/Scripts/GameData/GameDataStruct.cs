public enum ItemState {
    Blocked,
    Purchased,
    Selected,
}

[System.Serializable]
public class LevelData {
    public int  id;
    public bool access;
    public int  starCount;

    public LevelData(int id, int starCount, bool access)
    {
        this.id         = id;
        this.access     = access;
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