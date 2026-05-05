using UnityEngine;

public class ContinueMusic : MonoBehaviour
{
    public static ContinueMusic Instance;

    [Header("Audio Sources")]
    public AudioSource musicSource;
    public AudioSource ambienceSource;

    [Header("Default Audio")]
    [SerializeField] private AudioClip defaultMusic;
    [SerializeField] private AudioClip defaultAmbience;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        PlayMusic(defaultMusic);
        PlayAmbience(defaultAmbience);
    }

    public void PlayMusic(AudioClip music)
    {
        if (music == null) return;

        if (musicSource.clip == music && musicSource.isPlaying)
            return;

        musicSource.clip = music;
        musicSource.loop = true;
        musicSource.Play();
    }

    public void PlayAmbience(AudioClip ambience)
    {
        if (ambience == null) return;

        if (ambienceSource.clip == ambience && ambienceSource.isPlaying)
            return;

        ambienceSource.clip = ambience;
        ambienceSource.loop = true;
        ambienceSource.Play();
    }
}