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
    private GameObject toolObject;

    public void InitTool(ToolCount toolData) {
        toolUseCount    = toolData.count;
        toolIcon.sprite = toolData.data.icon;
        toolObject      = toolData.data.prefab;

        toolButton.onClick.AddListener(UseTool);

        ChangeVisual();
    }

    private void UseTool(){
        toolUseCount--;
        ChangeVisual();

        Vector3 pz = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pz.z = 0;
        Vector3 point = pz;

        GameObject go = Instantiate(toolObject, point, Quaternion.identity);
    }
    private void ChangeVisual(){
        toolButton.interactable = toolUseCount > 0;
        toolCountText.text = $"X{toolUseCount}";
    }
}
