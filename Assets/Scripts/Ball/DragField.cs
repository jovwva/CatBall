using UnityEngine;

public class DragField : MonoBehaviour, IEventReceiver<ToolDrag>
{
	[SerializeField] private float rotationsPerSecond = 0.1f;

#region UnityVoid
	private void Start() {
		EventBusHolder.Instance.EventBus.Register(this as IEventReceiver<ToolDrag>);
		SetState(0);
	}
	private void OnDisable() {
		EventBusHolder.Instance.EventBus.Unregister(this as IEventReceiver<ToolDrag>);
	}
	private void Update()
	{
		//Rotate the shield a bit every second
		float rZ = (rotationsPerSecond * Time.time * 360) % 360f;
		transform.rotation = Quaternion.Euler(0, 0, rZ);
	}
#endregion
#region EventBus
    public UniqueId Id { get; } = new UniqueId();
    public void OnEvent(ToolDrag @event) {
        if (@event.gameState == GameState.Slow) {
            SetState(0);
        } else {
            SetState(1);
        }
    }

	private void SetState(int lvl)
	{
		Material mat = this.GetComponent<Renderer>().material;
		//Adjust the texture offset to show different shield level
		mat.mainTextureOffset = new Vector2(0.2f * lvl, 0);
	}
#endregion
}
