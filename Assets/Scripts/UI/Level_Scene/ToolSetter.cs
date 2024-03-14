using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolSetter : MonoBehaviour, IEventReceiver<ToolDrag>
{
    [SerializeField] private LevelDataSO levelData;
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private Transform  toolRoot;
    [SerializeField] private GameObject  toolButtonPrefab;

    private void Start()
    {
        EventBusHolder.Instance.EventBus.Register(this as IEventReceiver<ToolDrag>);

        LevelInfo levelInfo = levelData.levelInfoList.Find(l => l.id == 1);

        foreach(ToolCount tc in levelInfo.toolSOArray) {
            GameObject go = Instantiate(toolButtonPrefab, toolRoot);
            go.GetComponent<ToolButton>().InitTool(tc);
        }
    }
    private void OnDisable()
    {
        EventBusHolder.Instance.EventBus.Unregister(this as IEventReceiver<ToolDrag>);
    }

    public void ShowToolGroup() {
        canvasGroup.interactable = true;
        canvasGroup.alpha = 1f;
    }
    public void HideToolGroup() {
        canvasGroup.alpha = 0f;
        canvasGroup.interactable = false;
    }


    public UniqueId Id { get; } = new UniqueId();
    public void OnEvent(ToolDrag @event) {
        if (@event.gameState == GameState.Slow) {
            HideToolGroup();
        } else {
            ShowToolGroup();
        }
    }
}
