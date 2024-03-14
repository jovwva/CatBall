using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolSetter : MonoBehaviour
{
    [SerializeField] private LevelDataSO levelData;

    [SerializeField] private Transform  toolRoot;
    [SerializeField] private GameObject  toolButtonPrefab;

    private void Start()
    {
        LevelInfo levelInfo = levelData.levelInfoList.Find(l => l.id == 1);

        foreach(ToolCount tc in levelInfo.toolSOArray) {
            GameObject go = Instantiate(toolButtonPrefab, toolRoot);
            go.GetComponent<ToolButton>().InitTool(tc);
        }
    }
}
