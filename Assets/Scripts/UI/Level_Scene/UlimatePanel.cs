using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class UlimatePanel : MonoBehaviour
{
    [SerializeField] private Button actionButton;

    private int levelID;
    private bool isWorking = false;
    
    public void Init(int levelID, ButtonVoid buttonVoid)
    {

        if (isWorking) return;
        
        isWorking = true;
        this.levelID = levelID;

        if (YandexGame.timerShowAd >= YandexGame.Instance.infoYG.fullscreenAdInterval)
        {
            YandexGame.FullscreenShow();
            gameObject.SetActive(true);
            DeferredAction(buttonVoid);
        }
        else 
        {
            ImmediateAction(buttonVoid);
        }
    }

    private void ImmediateAction(ButtonVoid buttonVoid)
    {
        switch (buttonVoid)
        {
            case ButtonVoid.MainMenu:
                LoadMainMenu();
                break;
            case ButtonVoid.NextLevel:
                LoadNextLevel();
                break;
            case ButtonVoid.Restart:
                RestartLevel();
                break;
        }
    }
    private void DeferredAction(ButtonVoid buttonVoid)
    {
        switch (buttonVoid)
        {
            case ButtonVoid.MainMenu:
                actionButton.onClick.AddListener(LoadMainMenu);
                break;
            case ButtonVoid.NextLevel:
                actionButton.onClick.AddListener(LoadNextLevel);
                break;
            case ButtonVoid.Restart:
                actionButton.onClick.AddListener(RestartLevel);
                break;
        }
    }

    private void LoadMainMenu()    => LoadScene("MainMenu");
    private void RestartLevel()    => LoadScene($"Level_{levelID}");
    private void LoadNextLevel() {
        if (SaveSystem.Instance.TryFindLevel(levelID + 1)) {
            LoadScene($"Level_{levelID + 1}");
        } else {
            LoadScene($"Level_{Random.Range(5,14)}");
        }
    } 

    private void LoadScene(string sceneName)
    {
        Time.timeScale = 1;
        EventBusHolder.Instance.EventBus.Raise(new ButtonClick( ButtonType.ActionButton ));
        SceneManager.LoadSceneAsync(sceneName);
    }
}

public enum ButtonVoid {
    MainMenu,
    Restart,
    NextLevel,
}
