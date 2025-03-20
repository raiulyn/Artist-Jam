using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance { get; private set; }
    [SerializeField] private AudioSource audioSource;
    public AudioClip[] musicClips;
    [SerializeField] private bool playOnAwake = true;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            if(playOnAwake)
            {
                PlayMusic(0);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayMusic(int clipNumber)
    {
        audioSource.clip = musicClips[clipNumber];
        audioSource.Play();
    }
    public void StopMusic()
    {
        audioSource.Stop();
    }
    public void PauseMusic()
    {
        audioSource.Pause();
    }
}
