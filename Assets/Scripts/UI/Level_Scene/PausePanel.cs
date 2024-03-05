using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PausePanel : MonoBehaviour
{
    public Button pauseButton;
    public Button mainMenuButton;
    public Button restartButton;
    public Button resumeButton;
    public TextMeshProUGUI levelNameText;

    public GameObject pauseHolder;

    private int levelID = 100;

    private void Awake() {
        mainMenuButton.onClick.AddListener(LoadMainMenu);
        restartButton.onClick.AddListener(RestartLevel);
        resumeButton.onClick.AddListener(ResumeToGame);
        pauseButton.onClick.AddListener(ShowPanel);
    }

    private void Start() {
        levelNameText.text = $"Уровень №{levelID}";
        HidePanel();
    }

    private void ShowPanel() {
        Time.timeScale = 0;
        pauseHolder.SetActive(true);
    } 
    private void HidePanel() {
        Time.timeScale = 1;
        pauseHolder.SetActive(false);
    } 

    private void LoadMainMenu()    => SceneManager.LoadSceneAsync("MainMenu");
    private void RestartLevel()    => SceneManager.LoadSceneAsync($"Level_{levelID}");
    private void ResumeToGame()    => HidePanel();
}
