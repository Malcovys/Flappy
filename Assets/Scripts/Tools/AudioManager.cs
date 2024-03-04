using UnityEngine;

public enum AudioType
{
    Wing,
    Point,
    Hit,
    Die,
    Swoosh
}

public enum AudioSourceType
{
    Game,
    Player
}

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public float volume;

    public AudioSource gameSource;
    public AudioSource playerSource;

    [System.Serializable]
    public struct AudioData
    {
        public AudioClip clip;
        public AudioType type;
    }

    public AudioData[] audioData;
    
    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        gameSource.volume = volume;
        playerSource.volume = volume;
    }

    public void PlaySound(AudioType type, AudioSourceType sourceType)
    {
        AudioClip clip = GetClip(type);

        if (sourceType == AudioSourceType.Game)
        {
            gameSource.PlayOneShot(clip);
        }
        else if (sourceType == AudioSourceType.Player)
        {
            playerSource.PlayOneShot(clip);
        }
    }

    AudioClip GetClip(AudioType type)
    {
        foreach (AudioData data in audioData)
        {
            if(data.type == type)
                return data.clip;
        }

        Debug.LogError("AudioManager: No clip found for type " + type);
        return null;
    }
}
