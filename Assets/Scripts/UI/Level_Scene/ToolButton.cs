using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ToolButton : MonoBehaviour
{
    [Header("UI Компоненты")]
    [SerializeField] private Button     toolButton;
    [SerializeField] private Image      toolIcon;
    [SerializeField] private TextMeshProUGUI toolCountText;

    private int toolUseCount = 0;

    public void InitTool(Sprite icon, int count) {
       
        toolUseCount    = count;
        toolIcon.sprite = icon;

        toolButton.onClick.AddListener(UseTool);

        ChangeVisual();
    }

    private void UseTool(){
        toolUseCount--;
        ChangeVisual();
        Debug.Log("Инструмент использован");
    }
    private void ChangeVisual(){
        toolButton.interactable = toolUseCount > 0;
        toolCountText.text = $"X{toolUseCount}";
    }
}
