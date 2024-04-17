using System.Collections.Generic;
using UnityEngine;

public class SoundBroker : MonoBehaviour
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
    private void Start()
    {
        // DeliveryManager.Instance.OnRecipeSucces += DeliveryManager_OnRecipeSucces;
        // DeliveryManager.Instance.OnRecipeFailed += DeliveryManager_OnRecipeFailed;
        // CuttingCounter.OnAnyCut += CuttingCounter_OnAnyCut;
        // BaseCounter.OnAnyObjectPlaceHere += BaseCounter_OnAnyObjectPlaceHere;
        // TrashCounter.OnAnyObjectTrashed += TrashCounter_OnAnyObjectTrash;
    }

    // private void TrashCounter_OnAnyObjectTrash(object sender, EventArgs e)
    // {
    //     TrashCounter trashCounter = sender as TrashCounter;
    //     PlaySound(audioClipRefSO.trash, trashCounter.transform.position);
    // }

    public void PlaySound(SoundType soundType)
    {
        if (soundDictionary.ContainsKey(soundType))
        {
            audioSource.clip = soundDictionary[soundType];
            audioSource.Play();
        }
    }
}
