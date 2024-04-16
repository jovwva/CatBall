using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
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

    public UlimatePanel ulimatePanel;
    [SerializeField] private RewardPanel rewardPanel;
    [SerializeField] private GameObject  winPanel;

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
        levelID = levelData.id;
        
        if (!levelData.access) {
            if (YandexGame.EnvironmentData.language == "ru") {
                resultText.text = "Вы проиграли!";
            } else { 
                resultText.text = "You lose!";
            }

            nextLevelButton.interactable = false;
        } else {
            if (YandexGame.EnvironmentData.language == "ru") {
                resultText.text = "Вы победили!";
            } else { 
                resultText.text = "You win!";
            }

            rewardPanel.InirRewardPanel(levelData.starCount);
            winPanel.SetActive(true);
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

    private void LoadMainMenu()    => ulimatePanel.Init(levelID, ButtonVoid.MainMenu);
    private void RestartLevel()    => ulimatePanel.Init(levelID, ButtonVoid.Restart);
    private void LoadNextLevel()   {
            var eventParams = new Dictionary<string, string>{ { "LevelPass", $"Level_{levelID}" } };
            YandexMetrica.Send("triggers", eventParams);

            ulimatePanel.Init(levelID, ButtonVoid.NextLevel);
    } 
}
