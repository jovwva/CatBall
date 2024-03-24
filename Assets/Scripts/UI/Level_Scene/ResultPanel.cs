using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using YG;

public class ResultPanel : MonoBehaviour
{
    public Button mainMenuButton;
    public Button restartButton;
    public Button nextLevelButton;

    public GameObject panelHolder;
    public StarInResult[] starArray = new StarInResult[3];
    public TextMeshProUGUI resultText;
    public GameObject blockZone;

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
            if (YandexGame.EnvironmentData.language == "ru") {
                resultText.text = "Вы проиграли!";
            } else { 
                resultText.text = "You lose!";
            }

            // if (SaveSystem.Instance.GetLevelData(levelData.id + 1)?.access == false) {
            nextLevelButton.interactable = false;
            // }
        } else {
            if (YandexGame.EnvironmentData.language == "ru") {
                resultText.text = "Вы победили!";
            } else { 
                resultText.text = "You win!";
            }

            for(int i=0; i < levelData.starCount; i++) {
                starArray[i].ShowStar();
            }
        }
    } 

    public void HidePanel() {
        blockZone.SetActive(false);
        panelHolder.SetActive(false);
    }
    public void ShowPanel() {
        blockZone.SetActive(true);
        panelHolder.SetActive(true);
    }

    private void LoadMainMenu()    => SceneManager.LoadScene("MainMenu");
    private void RestartLevel()    => SceneManager.LoadScene($"Level_{levelID}");
    private void LoadNextLevel() {
        if (SaveSystem.Instance.TryFindLevel(levelID + 1)) {
            SceneManager.LoadScene($"Level_{levelID + 1}");
        } else {
            LoadMainMenu();
        }
    } 
}
