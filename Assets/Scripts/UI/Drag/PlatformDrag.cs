using UnityEngine;

public abstract class PlatformDrag : MonoBehaviour
{
    public virtual void StartDrag() {
        EventBusHolder.Instance.EventBus.Raise(new ToolDrag(GameState.Slow));
    }
    public virtual void EndDrag() {
        EventBusHolder.Instance.EventBus.Raise(new ToolDrag(GameState.Normal));
    }
}