using YG;
using UnityEngine;
using System.Collections.Generic;

public class GameplayController : MonoBehaviour, 
    IEventReceiver<BallDestroyedEvent>, IEventReceiver<PipeEmptiedEvent>, IEventReceiver<BallApprovedEvent>, IEventReceiver<ToolDrag>
{
    [SerializeField] private TimeScaleController timeController;
    [SerializeField] private CanvasBroker     canvasBroker;
    [Header("Level data")]
    public int levelID = 1;
    private LevelInfo data;

    private int ballsDestroyed = 0;
    private float ballApproved = 0;
    private bool levelPass = false;

    #region EventBus
        private void Start()
        {
            EventBusHolder.Instance.EventBus.Register(this as IEventReceiver<BallDestroyedEvent>);
            EventBusHolder.Instance.EventBus.Register(this as IEventReceiver<BallApprovedEvent>);
            EventBusHolder.Instance.EventBus.Register(this as IEventReceiver<PipeEmptiedEvent>);
            EventBusHolder.Instance.EventBus.Register(this as IEventReceiver<ToolDrag>);

            data  = SaveSystem.Instance.GetLevelInformation(levelID);
            canvasBroker.InitAll(levelID);
            
            var eventParams = new Dictionary<string, string>{ { "LevelsStart", $"Level_{levelID}" } };
            YandexMetrica.Send("triggers", eventParams);
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
            canvasBroker.ShowApproval(result);

            if (result >= 1) {
                LevelPass();
            }
        }
        BallDestroyed();
    }

    public void LevelPass() {
        if (!levelPass) {
            levelPass = true;
            ShowLevelResult();
        }
    }

    private void ShowLevelResult() {
        int newStarCount = GetStarCount();
        LevelData levelData = new LevelData(levelID, newStarCount, newStarCount > 0);

        canvasBroker.ShowLevelResult(levelData);
        CheckLevelResult(levelData);
    }

    private void CheckLevelResult(LevelData levelData) {
        bool needSave = false;
        if (levelData.access == false) return;
        
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
    }
}
