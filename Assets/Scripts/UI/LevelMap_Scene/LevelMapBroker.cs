using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class LevelMapBroker : MonoBehaviour
{
    [Header("UI компоненты")]
    public Button mainMenuButton;

    private void Awake() {
        mainMenuButton.onClick.AddListener(LoadMainMenu);
    }

    private void LoadMainMenu()    => SceneManager.LoadSceneAsync("MainMenu");
}
