using UnityEngine;

public class MusicBroker : MonoBehaviour
{
    public static MusicBroker Instance { get; private set; }

    [SerializeField] private AudioSource commonSource;

    private float volume = 1f;

    private void Awake()
    {
        if ( Instance != null ) 
        {
            return;
        }

        Instance = this;
    }  

    private void Start()
    {
        ChangeVolume(SaveSystem.Instance.GetMusicValue());
    }

    public void ChangeVolume(float newVolume)
    {
        volume = newVolume;
        commonSource.volume = volume;
    }
}
