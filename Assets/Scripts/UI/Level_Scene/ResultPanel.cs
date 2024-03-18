using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultPanel : MonoBehaviour
{
    public Button mainMenuButton;
    public Button restartButton;
    public Button nextLevelButton;

    public GameObject panelHolder;
    public StarInResult[] starArray = new StarInResult[3];
    public TextMeshProUGUI resultText;

    private int levelID;

    private void Awake() {
        mainMenuButton.onClick.AddListener(LoadMainMenu);
        restartButton.onClick.AddListener(RestartLevel);
        nextLevelButton.onClick.AddListener(LoadNextLevel);
    }

    private void Start() {
        HidePanel();
    }

    public void Init(LevelData levelData) {
        this.levelID = levelData.id;
        if (!levelData.access) {
            resultText.text = "Вы проиграли!";

            // if (SaveSystem.Instance.GetLevelData(levelData.id + 1)?.access == false) {
            nextLevelButton.interactable = false;
            // }
        } else {
            resultText.text = "Вы победили!";

            for(int i=0; i < levelData.starCount; i++) {
                starArray[i].ShowStar();
            }
        }
    } 

    public void HidePanel() {
        panelHolder.SetActive(false);
    }
    public void ShowPanel() {
        panelHolder.SetActive(true);
    }

    private void LoadMainMenu()    => SceneManager.LoadSceneAsync("MainMenu");
    private void RestartLevel()    => SceneManager.LoadSceneAsync($"Level_{levelID}");
    private void LoadNextLevel() {
        if (SaveSystem.Instance.TryFindLevel(levelID + 1)) {
            SceneManager.LoadSceneAsync($"Level_{levelID + 1}");
        } else {
            LoadMainMenu();
        }
    } 
}
