using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using YG;

public class LevelMapBroker : MonoBehaviour
{
    [Header("UI компоненты")]
    public Button mainMenuButton;

    private void Awake() {
        mainMenuButton.onClick.AddListener(LoadMainMenu);
    }

    private void LoadMainMenu()
    {
        EventBusHolder.Instance.EventBus.Raise(new ButtonClick( ButtonType.ActionButton ));
        SceneManager.LoadSceneAsync("MainMenu");
    } 
}
