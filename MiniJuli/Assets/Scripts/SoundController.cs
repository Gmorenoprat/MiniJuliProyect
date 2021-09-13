using UnityEngine;
public class SoundController { 
    AudioSource source;
    AudioClip[] clips;

    public SoundController(Character p)
    {
        clips = p.ClipsAudio;
        source = p.GetComponent<AudioSource>();
    }

    public void SoundPlay(int clip)
    {
        source.Stop();
        source.clip = clips[clip];
        source.Play();
    }
}
