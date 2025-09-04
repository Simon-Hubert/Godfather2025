using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioSource musicSource;
    public AudioClip mainTheme;
    public AudioSource sfxSource;
    public AudioClip[] sfxClips = new AudioClip[6];

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Start()
    {
        PlayMainTheme();
    }
    public void PlayMainTheme()
    {
        if (musicSource != null && mainTheme != null)
        {
            musicSource.clip = mainTheme;
            musicSource.loop = true;
            musicSource.Play();
        }
    }

    public void PlaySFX(int index)
    {
        if (sfxSource != null && index >= 0 && index < sfxClips.Length && sfxClips[index] != null)
        {
            sfxSource.PlayOneShot(sfxClips[index]);
        }
        else
        {
            Debug.LogWarning("SFX non assigné ou index invalide : " + index);
        }
    }
}
