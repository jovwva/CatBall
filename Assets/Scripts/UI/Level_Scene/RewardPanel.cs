using UnityEngine;

public class RewardPanel : MonoBehaviour
{
    [SerializeField] private Transform  rewardHolder;
    [SerializeField] private GameObject rewardPrefab;
    [SerializeField] private RewardItem rewardItem;

    //TODO Необходимо пересобрать логику работы данного класса. В данный момент он будет сетить данные в единственный заранее заготовленный префаб награды
    // однако в дальнешем в случае расширения пула наград (больше 1) нужно будет переделать.

    /// <summary>
    /// Начинает процесс рассчета и вручения награды игроку взависимости от количества полученных звезд.
    /// </summary>
    /// <param name="starCount"></param>
    public void InirRewardPanel(int starCount)
    {
        gameObject.SetActive(true);

        int reward = CalculateReward(starCount);

        SaveSystem.Instance.TrySetMoneyValue(reward);
        rewardItem?.SetData(reward);
    }

    /// <summary>
    /// Возвращает целочисленное занчение награды в зависимости от количества полученных звезд.
    /// </summary>
    /// <param name="starCount"></param>
    /// <returns></returns>
    private int CalculateReward(int starCount) 
    {
        switch (starCount)
        {
            case 1: 
                return 50;
            case 2:
                return 75;
            default:
                return 125;
        }
    }
}
