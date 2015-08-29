using UnityEngine;

public class VFXSoundController : MonoBehaviour
{

    void Start()
    {
        var audioControllerObject = GameObject.FindWithTag("AudioController");
        var audioController = audioControllerObject.GetComponent<AudioController>();
        if (audioController == null)
        {
            Debug.Log("Cannot find 'AudioController' script");
        }

        GetComponent<AudioSource>().mute = audioController.mute;
    }
}
