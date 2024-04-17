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
    [SerializeField] private Button shopButton;
    [SerializeField] private Button closeShopButton;
    [SerializeField] private TextMeshProUGUI playButtonText;
    [Space]
    [Header("Панели")]
    [SerializeField] private GameObject shopPanel;
    [SerializeField] private GameObject mainPanel;

    private SoundBroker soundBroker;
    private int lastLevelID = 0;

    private void Awake()
    {
        Time.timeScale = 1;
    }
    void Start() 
    {
        lastLevelID = SaveSystem.Instance.GetLevelDataArray().
            Where( ld => ld.access).OrderBy(ld => ld.starCount).First().id;

        if (YandexGame.EnvironmentData.language == "ru") {
            playButtonText.text = $"Уровень №{lastLevelID}";
        } else { 
            playButtonText.text = $"Level №{lastLevelID}";;
        }
        soundBroker = SoundBroker.Instance;

        playButton.onClick.AddListener(LoadLastLevel);
        mapButton.onClick.AddListener(LoadMapLevel);

        shopButton.onClick.AddListener(OpenShopPanel);
        shopButton.onClick.AddListener( ()=>  soundBroker.PlaySound(SoundBroker.SoundType.PanelOpen) );

        closeShopButton.onClick.AddListener(OpenMenuPanel);
        closeShopButton.onClick.AddListener( ()=>  soundBroker.PlaySound(SoundBroker.SoundType.PanelClose) );
    }

    private void LoadLastLevel()    => LoadScene($"Level_{lastLevelID}");
    private void LoadMapLevel()     => LoadScene("LevelsMap");
    
    private void LoadScene(string sceneName)
    {
        soundBroker.PlaySound(SoundBroker.SoundType.ButtonClick);
        SceneManager.LoadSceneAsync(sceneName);
    }

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
