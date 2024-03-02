using UnityEngine;

public class StarIndicator : MonoBehaviour
{
    public Transform starImage;

    private void Start() {
        UpdateStarIndicator(0f);
    }
    public void UpdateStarIndicator(float starScale) {
        starImage.localScale = Vector3.one * starScale;
    }
}
