using UnityEngine;

public delegate void VoidEventHandler();

public class AudioController : MonoBehaviour
{
    public AudioSource gameAudioSource;
    public AudioSource palyerAudioSource;
    public event VoidEventHandler MuteChanged;
    public bool muteOnStart;

    public bool mute
    {
        get;
        private set;
    }

    void Start()
    {
        if (!muteOnStart) return;
        ToggleMute();
    }

    // Update is called once per frame
    void Update()
    {
        // Mutes-Unmutes the sound from this object each time the user presses space.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ToggleMute();
        }
    }

    private void ToggleMute()
    {
        mute = !mute;
        gameAudioSource.mute = mute;
        palyerAudioSource.mute = mute;
    }
}
