using UnityEngine;

public class EpilogueMusic : MonoBehaviour
{
    [SerializeField] private AudioSource epilogueMusic;

    void Start()
    {
        if (ContinueMusic.Instance != null)
        {
            ContinueMusic.Instance.StopAllAudio();
            Destroy(ContinueMusic.Instance.gameObject);
        }

        epilogueMusic.Play();
    }
}