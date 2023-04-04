using UnityEngine;

public class AudioManager : MonoBehaviour 
{

    private static AudioManager _instance;
    public static AudioManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("AudioManager is Null");
            }
            return _instance;
        }
    }

    [SerializeField] 
    private AudioSource _voiceOver;
    [SerializeField]
    private AudioSource _music;

    private void Awake()
    {
        _instance = this;
    }

    public void PlayVoiceOver(AudioClip clipToPlay)
    {
        _voiceOver.clip = clipToPlay;
        _voiceOver.Play();
    }
    public void PlayMusic()
    {
        _music.Play();
    }
}
