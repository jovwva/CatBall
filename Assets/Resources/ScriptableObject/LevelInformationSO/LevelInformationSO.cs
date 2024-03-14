using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "ScriptableObjects/LevelData's", order = 1)]
public class LevelDataSO : ScriptableObject
{
    public List<LevelInfo> levelInfoList;
}

[System.Serializable]
public  struct LevelInfo
{
    public int         id;
    
    public int         oneStarReqValue;
    public int         twoStarReqValue;
    public int         threeStarReqValue;

    public ToolCount[]    toolSOArray;
}
[System.Serializable]
public struct ToolCount 
{
    public string name;
    public ToolSO data;
    public int    count;
}
