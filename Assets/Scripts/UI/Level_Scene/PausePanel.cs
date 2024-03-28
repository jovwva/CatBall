using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using YG;

public class PausePanel : MonoBehaviour
{
    public Button pauseButton;

    public Button mainMenuButton;
    public Button restartButton;
    public Button resumeButton;
    
    public TextMeshProUGUI levelNameText;

    public GameObject pauseHolder;
    public GameObject blockZone;

    public UlimatePanel ulimatePanel;

    private int levelID = 100;

    private void Awake() {
        mainMenuButton.onClick.AddListener(LoadMainMenu);
        restartButton.onClick.AddListener(RestartLevel);
        resumeButton.onClick.AddListener(ResumeToGame);
        
        pauseButton.onClick.AddListener(ShowPanel);
    }

    private void Start() {
        HidePanel();
    }

    public void Init(int id) {
        levelID = id;
        if (YandexGame.EnvironmentData.language == "ru") {
            levelNameText.text = $"Уровень №{id}";
        } else { 
            levelNameText.text = $"Level №{id}";;
        }
    }

    private void ShowPanel() {
        Time.timeScale = 0;
        blockZone.SetActive(true);
        pauseHolder.SetActive(true);
    } 
    private void HidePanel() {
        Time.timeScale = 1;
        blockZone.SetActive(false);
        pauseHolder.SetActive(false);
    } 

    private void LoadMainMenu()    => ulimatePanel.Init(levelID, ButtonVoid.MainMenu);
    // SceneManager.LoadSceneAsync("MainMenu");
    private void RestartLevel()    => ulimatePanel.Init(levelID, ButtonVoid.Restart);
    // SceneManager.LoadSceneAsync($"Level_{levelID}");
    private void ResumeToGame()    => HidePanel();
}
