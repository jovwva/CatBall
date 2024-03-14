using UnityEngine;

[CreateAssetMenu(fileName = "Tool", menuName = "ScriptableObjects/Tool's", order = 1)]
public class ToolSO : ScriptableObject
{
    public string toolName;

    public int          id;
    public GameObject   prefab;
    public Sprite       icon;
}
