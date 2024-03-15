using UnityEngine;
using UnityEngine.UI;

public class PlayPanel : MonoBehaviour
{
    public CanvasGroup      canvasGroup;

    public Button pauseButton;
    public Button continueButton;

    private void Awake() {
        pauseButton.onClick.AddListener(HidePanel);
        continueButton.onClick.AddListener(ShowPanel);
    }

    public void HidePanel() {
        canvasGroup.alpha = .5f;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
    }
    public void ShowPanel() {
        canvasGroup.alpha = 1f;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
    }
}
