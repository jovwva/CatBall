using UnityEngine;

public class BallDestroyer : MonoBehaviour
{
    [SerializeField] private EventBusHolder _busHolder;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Сообщает, что синий мячик был уничтожен!
        _busHolder.EventBus.Raise(new BallDestroyedEvent(BallType.BlueBall));
        Destroy(other.gameObject);
    }
}
