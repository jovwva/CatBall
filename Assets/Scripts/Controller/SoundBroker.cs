using System.Collections.Generic;
using UnityEngine;

public class SoundBroker : MonoBehaviour, IEventReceiver<BallApprovedEvent>, IEventReceiver<BallDestroyedEvent>, IEventReceiver<ButtonClick>
{
    public static SoundBroker Instance { get; private set; }
    [SerializeField] private AudioSource commonSource;
    [SerializeField] private AudioSource warningSource;
    [SerializeField] private AudioSource aproveSource;

    [SerializeField] private AudioClip[] audioClipArray;

    private float volume = 1f;
    public enum SourceType
    {
        Common,
        Warning,
        Aprove,
    }
    public enum SoundType
    {
        PanelOpen,
        PanelClose,
        CoinTransfer,
        LevelWin,
        LevelFail,
        BallAprove,
        BallSpawn,
        BallWarning,
        ButtonClick,
    }
    private Dictionary<SoundType, AudioClip> soundDictionary;

    private void Awake()
    {
        transform.SetParent(null);
        if ( Instance != null ) 
        {
            Destroy(gameObject);
            return;
        }

        soundDictionary = new Dictionary<SoundType, AudioClip>
        {
            { SoundType.PanelOpen,      audioClipArray[0] },
            { SoundType.PanelClose,     audioClipArray[1] },
            { SoundType.CoinTransfer,   audioClipArray[2] },
            { SoundType.LevelWin,       audioClipArray[3] },
            { SoundType.LevelFail,      audioClipArray[4] },
            { SoundType.BallAprove,     audioClipArray[5] },
            { SoundType.BallSpawn,      audioClipArray[6] },
            { SoundType.BallWarning,    audioClipArray[7] }, 
            { SoundType.ButtonClick,    audioClipArray[8] }, 
        };

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }    

#region IEventReceiver
    private void Start()
    {
        EventBusHolder.Instance.EventBus.Register(this as IEventReceiver<BallApprovedEvent>);
        EventBusHolder.Instance.EventBus.Register(this as IEventReceiver<BallDestroyedEvent>);
        EventBusHolder.Instance.EventBus.Register(this as IEventReceiver<ButtonClick>);
    
        volume = SaveSystem.Instance.GetSoundValue();
    }
    private void OnDestroy()
    {
        EventBusHolder.Instance.EventBus.Unregister(this as IEventReceiver<BallApprovedEvent>);
        EventBusHolder.Instance.EventBus.Unregister(this as IEventReceiver<BallDestroyedEvent>);
        EventBusHolder.Instance.EventBus.Unregister(this as IEventReceiver<ButtonClick>);
    }

    public UniqueId Id { get; } = new UniqueId();
    
    public void OnEvent(BallDestroyedEvent @event)
    {
        PlaySound(SoundType.BallWarning, SourceType.Warning);
    }
    public void OnEvent(BallApprovedEvent @event)
    {
        PlaySound(SoundType.BallAprove, SourceType.Aprove);
    } 
    public void OnEvent(ButtonClick @event)
    {
        switch (@event.buttonState ) 
        {
            case ButtonType.CloseButton:
                PlaySound(SoundType.PanelClose);
                break;
            case ButtonType.OpenButton:
                PlaySound(SoundType.PanelOpen);
                break;
            case ButtonType.CoinTransferButton:
                PlaySound(SoundType.CoinTransfer);
                break;
            default:
                PlaySound(SoundType.ButtonClick);
                break;
        }
    } 
#endregion

    public void PlaySound(SoundType soundType, SourceType sourceType = SourceType.Common)
    {
        if (soundDictionary.ContainsKey(soundType))
        {
            AudioSource source;
            switch (sourceType)
            {
                case SourceType.Warning:
                    source = warningSource;
                    break;
                case SourceType.Aprove:
                    source = aproveSource;
                    break;
                default:
                    source = commonSource;
                    break;
            }
            source.clip = soundDictionary[soundType];
            source.volume = volume;
            source.Play();
        }
    }

    public void ChangeVolume(float newVolume)
    {
        volume = newVolume;
    }
}
