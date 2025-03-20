using UnityEngine;

public class MusicEvent : MonoBehaviour
{
    [SerializeField] private int clipNumber = 0;
    [SerializeField] private bool playOnAwake = false;

    private void Awake()
    {
        if (playOnAwake)
        {
            MusicManager.Instance?.PlayMusic(clipNumber);
        }
    }
}
