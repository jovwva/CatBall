using System.Collections;
using UnityEngine;

public class GameplayController : MonoBehaviour, IEventReceiver<BallDestroyedEvent>, IEventReceiver<PipeEmptiedEvent>, IEventReceiver<BallApprovedEvent>
{
    [SerializeField] private EventBusHolder _eventBusHolder;
    [SerializeField] private SaveSystem     _saveSystem;
    [SerializeField] private bool levelPass = false;
    [Header("Level data")]
    public int levelID = 1;
    public int ballsCount;
    public int ballsWinCount;
    public int ballsDestroyed = 0;
    public float ballApproved = 0;

    [Header("UI Link")]
    public StarIndicator    starIndicator;
    public CanvasGroup      canvasGroup;
    public ResultPanel      resultPanel;

    private void Start()
    {
        _eventBusHolder.EventBus.Register(this as IEventReceiver<BallDestroyedEvent>);
        _eventBusHolder.EventBus.Register(this as IEventReceiver<BallApprovedEvent>);
        _eventBusHolder.EventBus.Register(this as IEventReceiver<PipeEmptiedEvent>);
    }

    private void OnDisable()
    {
        _eventBusHolder.EventBus.Unregister(this as IEventReceiver<BallDestroyedEvent>);
        _eventBusHolder.EventBus.Unregister(this as IEventReceiver<BallApprovedEvent>);
        _eventBusHolder.EventBus.Register(this as IEventReceiver<PipeEmptiedEvent>);
    }

    #region IEventReceiver
    public UniqueId Id { get; } = new UniqueId();
    public void OnEvent(BallDestroyedEvent @event) {
        BallDestroyed();
    } 
    public void OnEvent(PipeEmptiedEvent @event)  => Debug.Log($"В трубе {@event.PipeObject.name} закончились шарики!");

    public void OnEvent(BallApprovedEvent @event) {
        BallApproved();
    } 
    #endregion

    private void BallDestroyed() {
        ballsDestroyed++;

        if (ballsDestroyed >= ballsCount) {
            LevelPass();
        }
    }

    private void BallApproved() {
        ballApproved++;

        if (!levelPass)
        {
            float result = ballApproved / ballsWinCount;
            starIndicator.UpdateStarIndicator(result);

            if (result >= 1) {
                LevelPass();
            }
        }
        BallDestroyed();
    }

    public void LevelPass() {
        
        if (!levelPass) {
            levelPass = true;
            canvasGroup.alpha = 0.5f;
            StartCoroutine(ShowLevelResult());
        }
        
    }

    private IEnumerator ShowLevelResult()
    {
        int newStarCount = GetStarCount();

        Debug.Log($"TryToSave new data: {levelID}{newStarCount}");
        // Заменить
        resultPanel.SetResult(levelID, newStarCount);
        _saveSystem.SetLevelData(new LevelData(levelID, newStarCount));

        _saveSystem.SaveProgress();

        yield return new WaitForSeconds(.5f);
        resultPanel.ShowResult();
    }

    private int GetStarCount() {
        float result = ballApproved / ballsWinCount;

        if (result < .5f) {
            return 0;
        } else if (result < .65f){
            return 1;
        } else if (result < .85f) {
            return 2;
        } else {
            return 3;
        }
    }
}
