using UnityEngine;
using DG.Tweening;

public class AudioManager : MonoBehaviour {
    private static AudioManager audioManager;
    private AudioSource audioSource;


    #region AudioBackground
    [SerializeField]
    private AudioClip PlayBackground;
    #endregion
    private void Awake()
    {
        if (audioManager)
        {
            Destroy(gameObject);
        }
        else
        {
            audioSource = GetComponent<AudioSource>();
            audioManager = this;
            DontDestroyOnLoad(audioManager);
            OnLevelWasLoaded(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void LoadAudioBackground(AudioClip audioClip)
    {
        DOTween.To(() => audioSource.volume, x => audioSource.volume = x, 0, .5f)
            .OnKill(() =>
            {
                audioSource.clip = audioClip;
                audioSource.Play();
                DOTween.To(() => audioSource.volume, x => audioSource.volume = x, 1, .5f);
            });
    }
    private void OnLevelWasLoaded(int level)
    {
        string nameScene = UnityEngine.SceneManagement.SceneManager.GetSceneByBuildIndex(level).name;
        switch (nameScene)
        {
            case "SampleScene":
                LoadAudioBackground(PlayBackground);
                break;
        }
    }


    [SerializeField]
    private AudioSource FXAudioSource;
    [Range(0, 1)]
    public float FXVolume;
    [SerializeField]
    private AudioClip
        DestroySquare,
        CreateSquare,
        LowTimeTick,
        UpdateColorCircle;
    #region Other metods
    public static void PlayDestroySquare()
    {
        if (audioManager)
            audioManager.FXAudioSource.PlayOneShot(audioManager.DestroySquare, audioManager.FXVolume);
    }
    public static void PlayCreateSquare()
    {
        if (audioManager)
            audioManager.FXAudioSource.PlayOneShot(audioManager.CreateSquare, audioManager.FXVolume);
    }
    public static void PlayLowTimeTick()
    {
        if (audioManager)
            audioManager.FXAudioSource.PlayOneShot(audioManager.LowTimeTick, audioManager.FXVolume);
    }
    public static void PlayUpdateColorCircle()
    {
        if (audioManager)
            audioManager.FXAudioSource.PlayOneShot(audioManager.UpdateColorCircle, audioManager.FXVolume);
    }
    #endregion
}
