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
    public int           id;
    public ProductStatus itemState;

    public ItemData(int id, ProductStatus itemState)
    {
        this.id         = id;
        this.itemState  = itemState;
    }
}