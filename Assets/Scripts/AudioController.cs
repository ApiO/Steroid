using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource gameAudioSource;
    public AudioSource palyerAudioSource;
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
        if (gameAudioSource != null)
        {
            gameAudioSource.mute = mute;
        }
        if (palyerAudioSource != null)
        {
            palyerAudioSource.mute = mute;
        }
    }
}
