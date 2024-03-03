using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    [Header("UI Объекты")]
    [SerializeField] private Button button;
    [SerializeField] private TextMeshProUGUI buttonText;
    [Space]
    [Header("Объекты")]
    [SerializeField] private GameObject      lockedRoot;
    [SerializeField] private GameObject      unlockedRoot;
    [SerializeField] private GameObject[]    starObjectArray = new GameObject[3]; 

    private LevelPanel LevelPanel;
    private int levelID;

    public void InitButton(LevelData levelData, LevelPanel loadLevel) {
        this.levelID    = levelData.levelID;
        buttonText.text = levelData.levelID.ToString();
        gameObject.name = $"LevelButton_{levelData.levelID}";

        if (levelData.starCount == -1) {
            button.onClick.AddListener(ShowBlockAnim);
            lockedRoot.SetActive(true);
        } else {
            button.onClick.AddListener(LoadLevel);
            unlockedRoot.SetActive(true);
            
            if (levelData.starCount > 0) {
                for (int i = 0; i < levelData.starCount; i++) {
                    starObjectArray[i].SetActive(true);
                }
            }
            
        }

        LevelPanel = loadLevel;
    }

    private void LoadLevel() {
        LevelPanel.LoadLevel(levelID);
    }
    private void ShowBlockAnim()
    {
        Debug.Log($"Уровень недоступен!");
    }
}
