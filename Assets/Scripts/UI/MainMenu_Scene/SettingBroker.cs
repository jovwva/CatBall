using UnityEngine;
using UnityEngine.UI;
using YG;

public class SettingBroker : MonoBehaviour
{
    private float soundValue;
    private float musicvalue;
    private bool IsSaveReq = false;

    [SerializeField] private Slider soundSlider;
    [SerializeField] private Slider musicSlider;

    public void Start()
	{
        soundSlider.value = SaveSystem.Instance.GetSoundValue();
		soundSlider.onValueChanged.AddListener (delegate {ChangeSound ();});
    
        musicSlider.value = SaveSystem.Instance.GetMusicValue();
        musicSlider.onValueChanged.AddListener (delegate {ChangeMusic ();});
	}

    private void ChangeSound()
    {
        soundValue = soundSlider.value;
        YandexGame.savesData.SoundValue = soundValue;
        SoundBroker.Instance.ChangeVolume(soundValue);
        IsSaveReq = true;
    }
    private void ChangeMusic()
    {
        musicvalue = musicSlider.value;
        YandexGame.savesData.MusicValue = musicvalue;
        MusicBroker.Instance.ChangeVolume(musicvalue);
        IsSaveReq = true;
    }

    void OnDisable()
    {
        if (IsSaveReq)
        {
            IsSaveReq = false;
            SaveSystem.Instance.SaveProgress();
        }
    }
}
