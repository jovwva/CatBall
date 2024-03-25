using YG;
using UnityEngine;

public class SkipLevelRewardPanel : MonoBehaviour
{
    public GameObject resultPanelGO;
    public ResultPanel resultPanel;

    public void HidePanel() {
        gameObject.SetActive(false);
        resultPanelGO.SetActive(true);
    }
    public void ShowPanel() {
        resultPanelGO.SetActive(false);
        gameObject.SetActive(true);
    }
    public void ShowReward() => YandexGame.RewVideoShow(1);

    private void Rewarded(int id)
    {
        if (id == 1)
            SkipLevel();
    }

    private void SkipLevel() {
        resultPanel.RewardSkipLvl();
    }

    private void OnEnable() => YandexGame.RewardVideoEvent += Rewarded;
    private void OnDisable() => YandexGame.RewardVideoEvent -= Rewarded;
}
