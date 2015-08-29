using UnityEngine;

public class VFXSoundController : MonoBehaviour
{
    private AudioController _audioController;

    void Start()
    {
        var audioControllerObject = GameObject.FindWithTag("AudioController");
        if (audioControllerObject == null) return;

        _audioController = audioControllerObject.GetComponent<AudioController>();
        if (_audioController == null)
        {
            Debug.Log("Cannot find 'AudioController' script");
        }
        else
        {
            _audioController.MuteChanged += UpdateAudioSource;
        }
    }

    void UpdateAudioSource()
    {
        Debug.Log("roger!");
        var audioSource = GetComponent<AudioSource>();
        if (GetComponent<AudioSource>() != null)
        {
            audioSource.playOnAwake = !_audioController.mute;
        }
    }
}
