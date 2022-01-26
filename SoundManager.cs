using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    public AudioClip TapSound;
    public AudioClip PowerUpCollected;
    public AudioClip DamageTaken;

    [SerializeField] private AudioSource soundManager;

    public static void Play(AudioClip audio)
    {
        Instance.soundManager.clip = audio;
        Instance.soundManager.Play();
    }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
