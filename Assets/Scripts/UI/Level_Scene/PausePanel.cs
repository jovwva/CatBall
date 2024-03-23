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
    public GameObject blockZone;

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
        levelNameText.text = $"Уровень №{id}";
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

    private void LoadMainMenu()    => SceneManager.LoadSceneAsync("MainMenu");
    private void RestartLevel()    => SceneManager.LoadSceneAsync($"Level_{levelID}");
    private void ResumeToGame()    => HidePanel();
}
