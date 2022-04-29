using UnityEngine;

public class music : MonoBehaviour
{
    private AudioSource audioSource;

    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    public void PlayMusic()
    {
        if (audioSource.isPlaying) { return; }
        else { audioSource.Play(); }
    }

    public void StopMusic()
    {
        audioSource.Stop();
    }
}
