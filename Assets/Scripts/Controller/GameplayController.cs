using System.Collections;
using UnityEngine;

public class GameplayController : MonoBehaviour, 
    IEventReceiver<BallDestroyedEvent>, IEventReceiver<PipeEmptiedEvent>, IEventReceiver<BallApprovedEvent>, IEventReceiver<ToolDrag>
{
    [SerializeField] private TimeScaleController timeController;
    [Header("Level data")]
    public int levelID = 1;
    private LevelInfo data;

    private int ballsDestroyed = 0;
    private float ballApproved = 0;
    private bool levelPass = false;
    

    [Space]
    // Рефакторинг!!!
    // Нужно придумать какой-то способ автоматизировать эту связь
    [Header("UI Link")]
    public StarIndicator    starIndicator;
    public CanvasGroup      canvasGroup;
    public ResultPanel      resultPanel;

    #region EventBus
        private void Start()
        {
            EventBusHolder.Instance.EventBus.Register(this as IEventReceiver<BallDestroyedEvent>);
            EventBusHolder.Instance.EventBus.Register(this as IEventReceiver<BallApprovedEvent>);
            EventBusHolder.Instance.EventBus.Register(this as IEventReceiver<PipeEmptiedEvent>);
            EventBusHolder.Instance.EventBus.Register(this as IEventReceiver<ToolDrag>);

            data  = SaveSystem.Instance.GetLevelInformation(levelID);
        }
    
        private void OnDisable()
        {
            EventBusHolder.Instance.EventBus.Unregister(this as IEventReceiver<BallDestroyedEvent>);
            EventBusHolder.Instance.EventBus.Unregister(this as IEventReceiver<BallApprovedEvent>);
            EventBusHolder.Instance.EventBus.Unregister(this as IEventReceiver<PipeEmptiedEvent>);
            EventBusHolder.Instance.EventBus.Unregister(this as IEventReceiver<ToolDrag>);
        }
    #endregion

    #region IEventReceiver
    public UniqueId Id { get; } = new UniqueId();
    public void OnEvent(BallDestroyedEvent @event)  => BallDestroyed();
    public void OnEvent(PipeEmptiedEvent @event)    => Debug.Log($"В трубе {@event.PipeObject.name} закончились шарики!");
    public void OnEvent(BallApprovedEvent @event)   => BallApproved();
    public void OnEvent(ToolDrag @event)            => timeController.ChangeGameState(@event.gameState);
    #endregion

    private void BallDestroyed() {
        ballsDestroyed++;

        if (ballsDestroyed >= data.ballsStock) {
            LevelPass();
        }
    }

    private void BallApproved() {
        ballApproved++;

        if (!levelPass)
        {
            float result = ballApproved / data.threeStarReqValue;
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

        LevelData levelData = new LevelData(levelID, newStarCount, true);
        resultPanel.SetResult(levelData);
        CheckLevelResult(levelData);

        yield return new WaitForSeconds(.5f);
        resultPanel.ShowResult();
    }

    private void CheckLevelResult(LevelData levelData) {
        bool needSave = false;
        LevelData oldData = SaveSystem.Instance.GetLevelData(levelData.id);
        
        // Проверка следующего уровня
        if (SaveSystem.Instance.TrySetLevelAcces(levelData.id + 1)) {
            needSave = true;
        }
        if (oldData.starCount < levelData.starCount) {
            SaveSystem.Instance.SetLevelData(levelData);
            needSave = true;
        }

        if (needSave) SaveSystem.Instance.SaveProgress();
    }

    private int GetStarCount() {
        
        if (ballApproved >= data.threeStarReqValue) {
            return 3;
        } else if (ballApproved >= data.twoStarReqValue) {
            return 2;
        } else if (ballApproved >= data.oneStarReqValue) {
            return 1;
        } else {
            return 0;
        }
        // float result = ballApproved / data.threeStarReqValue;

        // if (result < .5f) {
        //     return 0;
        // } else if (result < .65f){
        //     return 1;
        // } else if (result < .85f) {
        //     return 2;
        // } else {
        //     return 3;
        // }
    }
}
