using UnityEngine;

public class ToolSetter : MonoBehaviour, IEventReceiver<ToolDrag>
{
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private Transform  toolRoot;
    [SerializeField] private GameObject  toolButtonPrefab;

#region UnityVoid
        private void Start()
        {
            EventBusHolder.Instance.EventBus.Register(this as IEventReceiver<ToolDrag>);
    
            LevelInfo levelInfo = SaveSystem.Instance.GetLevelInformation(1);
    
            foreach(ToolCount tc in levelInfo.toolSOArray) {
                GameObject go = Instantiate(toolButtonPrefab, toolRoot);
                go.GetComponent<ToolButton>().InitTool(tc);
            }
        }
        private void OnDisable()
        {
            EventBusHolder.Instance.EventBus.Unregister(this as IEventReceiver<ToolDrag>);
        }
#endregion

#region  CanvasGroup
        public void ShowToolGroup() {
            canvasGroup.interactable = true;
            canvasGroup.alpha = 1f;
        }
        public void HideToolGroup() {
            canvasGroup.alpha = 0f;
            canvasGroup.interactable = false;
        }
#endregion

#region EventBus
    public UniqueId Id { get; } = new UniqueId();
    public void OnEvent(ToolDrag @event) {
        if (@event.gameState == GameState.Slow) {
            HideToolGroup();
        } else {
            ShowToolGroup();
        }
    }
#endregion
}
