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
        panelHolder.SetActive(false);
    }

    public void SetResult(LevelData levelData) {
        this.levelID = levelData.levelID;
        if (levelData.starCount == 0) {
            resultText.text = "Вы проиграли!";
        } else {
            resultText.text = "Вы победили!";

            for(int i=0; i < levelData.starCount; i++) {
                starArray[i].ShowStar();
            }
        }
    } 

    public void ShowResult() {
        panelHolder.SetActive(true);
    }

    private void LoadMainMenu()    => SceneManager.LoadSceneAsync("MainMenu");
    private void RestartLevel()    => SceneManager.LoadSceneAsync($"Level_{levelID}");
    private void LoadNextLevel()    => SceneManager.LoadSceneAsync($"Level_{levelID + 1}");
}
