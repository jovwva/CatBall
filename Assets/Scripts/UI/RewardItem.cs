using UnityEngine.UI.Extensions.CasualGame;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RewardItem : MonoBehaviour
{
    [Header("Статичные эллементы")]
    [SerializeField] private Image              iconImage;
    [SerializeField] private TextMeshProUGUI    rewardValueText;
    [SerializeField] private UIParticleSystem   uIParticleSystem;
    [SerializeField] private GameObject         bonusPanel;

    // TODO Необходимо создать SO типа RewardType для удобной работы с rewardItem.

    /// <summary>
    /// Сетит данные в префаб Reward_Item.
    /// </summary>
    /// <param name="rewardValue"></param>
    public void SetData(int rewardValue)
    {
        // iconImage.sprite = ;
        rewardValueText.text = $"{rewardValue}";
        // uIParticleSystem.material = ;
    }
}
