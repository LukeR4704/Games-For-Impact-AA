using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioMixer mixer;

    private const float MUTED_DB = -80f;
    private const float NORMAL_DB = 0f;

    void Start()
    {
        bool musicOn = PlayerPrefs.GetInt("MusicOn", 1) == 1;
        bool sfxOn = PlayerPrefs.GetInt("SFXOn", 1) == 1;

        ToggleMusic(musicOn);
        ToggleSFX(sfxOn);
    }

    public void ToggleMusic(bool isOn)
    {
        mixer.SetFloat("MusicVolume", isOn ? NORMAL_DB : MUTED_DB);
        PlayerPrefs.SetInt("MusicOn", isOn ? 1 : 0);
    }

    public void ToggleSFX(bool isOn)
    {
        mixer.SetFloat("SFXVolume", isOn ? NORMAL_DB : MUTED_DB);
        PlayerPrefs.SetInt("SFXOn", isOn ? 1 : 0);
    }
}