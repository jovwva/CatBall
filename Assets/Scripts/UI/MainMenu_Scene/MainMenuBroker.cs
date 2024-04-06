using TMPro;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using YG;

public class MainMenuBroker : MonoBehaviour
{
    [Header("UI компоненты")]
    [SerializeField] private Button playButton;
    [SerializeField] private Button mapButton;
    // [SerializeField] private Button settingButton;
    [SerializeField] private Button shopButton;
    [SerializeField] private Button closeShopButton;
    [SerializeField] private TextMeshProUGUI playButtonText;
    [Space]
    [Header("Панели")]
    [SerializeField] private GameObject shopPanel;
    [SerializeField] private GameObject mainPanel;
    [Space]
    [SerializeField] private int lastLevelID = 0;

    void Start() {
        lastLevelID = SaveSystem.Instance.GetLevelDataArray().
            Where( ld => ld.access).OrderBy(ld => ld.starCount).First().id;

        if (YandexGame.EnvironmentData.language == "ru") {
            playButtonText.text = $"Уровень №{lastLevelID}";
        } else { 
            playButtonText.text = $"Level №{lastLevelID}";;
        }

        playButton.onClick.AddListener(LoadLastLevel);
        mapButton.onClick.AddListener(LoadMapLevel);
        // settingButton.onClick.AddListener(LoadMapLevel);
        shopButton.onClick.AddListener(OpenShopPanel);
        closeShopButton.onClick.AddListener(OpenMenuPanel);
    }

    private void LoadLastLevel()    => SceneManager.LoadSceneAsync($"Level_{lastLevelID}");
    private void LoadMapLevel()     => SceneManager.LoadSceneAsync("LevelsMap");
    private void OpenShopPanel()
    {
        shopPanel.SetActive(true);
        mainPanel.SetActive(false);
    }
    private void OpenMenuPanel()
    {
        mainPanel.SetActive(true);
        shopPanel.SetActive(false);
    }
}
