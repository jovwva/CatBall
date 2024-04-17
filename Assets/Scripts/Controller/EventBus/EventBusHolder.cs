using UnityEngine;

public class EventBusHolder : MonoBehaviour
{
    public static EventBusHolder Instance { get; private set; }
    public EventBus EventBus { get; private set; }

    private void Awake() 
    {
        if ( Instance != null ) 
        {
            Destroy(gameObject);
            return;
        }
        EventBus = new EventBus();
        Instance = this;
        DontDestroyOnLoad(gameObject);
	}
}