using TMPro;
using UnityEngine;

public class ResultPanel : MonoBehaviour
{
    public GameObject panelHolder;
    public StarInResult[] starArray = new StarInResult[3];
    public TextMeshProUGUI resultText;

    private void Start() {
        panelHolder.SetActive(false);
    }

    public void SetResult(int starCount) {
        if (starCount == 0) {
            resultText.text = "Вы проиграли!";
        } else {
            resultText.text = "Вы победили!";

            for(int i=0; i < starCount; i++) {
                starArray[i].ShowStar();
            }
        }
    } 

    public void ShowResult() {
        panelHolder.SetActive(true);
    }
}
