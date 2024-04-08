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
    [SerializeField] private Image[]    starObjectArray = new Image[3]; 
    [SerializeField] private Sprite          starOnSprite;

    private LevelPanel LevelPanel;
    private int levelID;

    public void InitButton(LevelData levelData, LevelPanel loadLevel) {
        this.levelID    = levelData.id;
        buttonText.text = levelData.id.ToString();
        gameObject.name = $"LevelButton_{levelData.id}";

        if (!levelData.access ) {
            button.onClick.AddListener(ShowBlockAnim);
            lockedRoot.SetActive(true);
        } else {
            button.onClick.AddListener(LoadLevel);
            unlockedRoot.SetActive(true);

            if (levelData.starCount > 0) {
                for (int i = 0; i < levelData.starCount; i++) {
                    starObjectArray[i].sprite = starOnSprite;
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
