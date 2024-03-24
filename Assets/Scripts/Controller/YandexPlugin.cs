using YG;
using UnityEngine;

public class YandexPlugin : MonoBehaviour
{
    // public void ShowAd() {
    //     YandexGame.FullscreenShow();
    // }

#region RewardAD
        private void OnEnable() => YandexGame.RewardVideoEvent += Rewarded;
    
        // Отписываемся от события открытия рекламы в OnDisable
        private void OnDisable() => YandexGame.RewardVideoEvent -= Rewarded;
    
        // Подписанный метод получения награды
        void Rewarded(int id)
        {
                // Если ID = 1, то выдаём "+100 монет"
            if (id == 1)
                AddMoney();
    
                // Если ID = 2, то выдаём "+оружие".
                else if (id == 2)
                        AddWeapon();
        }
    
        private void AddWeapon()
        {
            Debug.Log("RewardWeapon");
        }
    
        private void AddMoney()
        {
            Debug.Log("RewardMoney");
        }
    
        // Метод для вызова видео рекламы
        public void ExampleOpenRewardAd(int id)
        {
                // Вызываем метод открытия видео рекламы
                YandexGame.RewVideoShow(id);
        }
#endregion

// #region CloudSave
//     public void LoadData() {
        //  var data = YandexGame.savesData.playerData;
//     }
//     public void SaveData() {
//         // YandexGame.savesData.playerData = 
//         YandexGame.SaveProgress();
//     }
// #endregion

// #region Lang
//     public void SetString() {
//         if (YandexGame.EnvironmentData.language == "ru") {
//             Debug.Log("я русский");
//         } else { 
//             Debug.Log("i'm Dolboeb");
//         }
//     }
// #endregion
}
