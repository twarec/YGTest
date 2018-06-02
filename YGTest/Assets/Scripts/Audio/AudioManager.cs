using UnityEngine;
using DG.Tweening;

public class AudioManager : MonoBehaviour {
    private static AudioManager audioManager;
    private AudioSource audioSource;
    [Range(0,1)]
    public float FXVolume;

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
    private AudioClip
        DestroySquare,
        CreateSquare,
        LowTimeTick,
        UpdateColorCircle;
    #region Other metods
    public static void PlayDestroySquare()
    {
        audioManager.audioSource.PlayOneShot(audioManager.DestroySquare, audioManager.FXVolume);
    }
    public static void PlayCreateSquare()
    {
        audioManager.audioSource.PlayOneShot(audioManager.CreateSquare, audioManager.FXVolume);
    }
    public static void PlayLowTimeTick()
    {
        audioManager.audioSource.PlayOneShot(audioManager.LowTimeTick, audioManager.FXVolume);
    }
    public static void PlayUpdateColorCircle()
    {
        audioManager.audioSource.PlayOneShot(audioManager.UpdateColorCircle, audioManager.FXVolume);
    }
    #endregion
}
