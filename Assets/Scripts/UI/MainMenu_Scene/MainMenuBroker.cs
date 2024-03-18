using TMPro;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class MainMenuBroker : MonoBehaviour
{
    [Header("UI компоненты")]
    public Button playButton;
    public Button mapButton;
    public Button settingButton;
    public Button shopButton;
    public TextMeshProUGUI playButtonText;
    [Space]
    public int lastLevelID = 0;

    void Start() {
        lastLevelID = SaveSystem.Instance.GetLevelDataArray().
            Where( ld => ld.access).OrderBy(ld => ld.starCount).First().id;

        playButtonText.text = $"Уровень {lastLevelID}";
        playButton.onClick.AddListener(LoadLastLevel);

        mapButton.onClick.AddListener(LoadMapLevel);
        // settingButton.onClick.AddListener(LoadMapLevel);
        // shopButton.onClick.AddListener(LoadMapLevel);
    }

    private void LoadLastLevel()    => SceneManager.LoadSceneAsync($"Level_{lastLevelID}");
    private void LoadMapLevel()     => SceneManager.LoadSceneAsync("LevelsMap");
}
