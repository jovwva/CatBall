using System.Collections.Generic;
using UnityEngine;

public class SoundBroker : MonoBehaviour, IEventReceiver<BallApprovedEvent>, IEventReceiver<BallDestroyedEvent>
{
    public static SoundBroker Instance { get; private set; }
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip[] audioClipArray;

    // private float volume = 1f;
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
    }
    private void OnDestroy()
    {
        EventBusHolder.Instance.EventBus.Unregister(this as IEventReceiver<BallApprovedEvent>);
        EventBusHolder.Instance.EventBus.Unregister(this as IEventReceiver<BallDestroyedEvent>);
    }

    public UniqueId Id { get; } = new UniqueId();
    public void OnEvent(BallDestroyedEvent @event)
    {
        Debug.Log("SoundBroker BallDestroyedEvent!");
        PlaySound(SoundType.BallWarning);
    }
    public void OnEvent(BallApprovedEvent @event)
    {
        Debug.Log("SoundBroker BallApprovedEvent!");
        PlaySound(SoundType.BallAprove);
    } 
#endregion

    public void PlaySound(SoundType soundType)
    {
        if (soundDictionary.ContainsKey(soundType))
        {
            audioSource.clip = soundDictionary[soundType];
            audioSource.Play();
        }
    }
}
