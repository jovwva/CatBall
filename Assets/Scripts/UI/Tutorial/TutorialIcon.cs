using UnityEngine;

public class TutorialIcon : MonoBehaviour, IEventReceiver<ToolDrag>
{
    public int levelID;
    public GameObject sparks_1;
    public GameObject sparks_2;
    public GameObject sparks_3;
    public GameObject tetxHolder;
    public bool reqTurorial = false;
    public int trigerStep = 0;
    public TutorialTigger tutorialTigger;

    private void Start()
    {
        if (SaveSystem.Instance.GetLevelData(levelID).starCount == 0){
            reqTurorial = true;
            EventBusHolder.Instance.EventBus.Register(this as IEventReceiver<ToolDrag>);
            ActivateTrigger(0);
        }
    }

    private void OnDisable() {
        if (!reqTurorial) return;
        EventBusHolder.Instance.EventBus.Unregister(this as IEventReceiver<ToolDrag>);
    }

    public void ActivateTrigger(int id){
        if (trigerStep > id)
        {
            return;
        }

        if (!reqTurorial) return;
        switch(id) {
            case 0:
                sparks_1.SetActive(true);
                break;
            case 1:
                sparks_1.SetActive(false);
                sparks_2.SetActive(true);
                tutorialTigger.ChangeState(true);
                break;
            case 2:
                sparks_2.SetActive(false);
                sparks_3.SetActive(true);
                break;
            case 3:
                sparks_3.SetActive(false);
                tetxHolder.SetActive(true);
                break;
        }
        trigerStep = id;
    }

    #region EventBus
    public UniqueId Id { get; } = new UniqueId();
    public void OnEvent(ToolDrag @event) {
        if (@event.gameState == GameState.Slow) {
            ActivateTrigger(1);
        } else {
            ActivateTrigger(2);
        }
    }
#endregion
}
