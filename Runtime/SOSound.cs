using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu(fileName = "SOSound", menuName = "Meangpu/SOSound")]
public class SOSound : AudioEvent
{
    public string audioDes;

    public AudioClip[] _clip;
    public AudioClip clip
    {
        get => _clip[Random.Range(0, _clip.Length)];
    }

    public AudioMixerGroup mixerGroup;

    [MinMaxSlider(0f, 1f, "maxVolume", "VolumeRange")]
    public float minVolume = 0.6f;
    [HideInInspector]
    public float maxVolume = 0.8f;

    [MinMaxSlider(0.1f, 3f, "maxPitch", "PitchRange")]
    public float minPitch = 0.8f;
    [HideInInspector]
    public float maxPitch = 1.2f;

    [Range(0, 1)]
    public float blend;

    public bool loop;
    [HideInInspector]
    public AudioSource source;

    public float GetVolume() => Random.Range(minVolume, maxVolume);
    public float GetPitch() => Random.Range(minPitch, maxPitch);

    public void SetupSourceWithRandomVolAndPitch()
    {
        source.clip = _clip[Random.Range(0, _clip.Length)];
        source.volume = GetVolume();
        source.pitch = GetPitch();
    }

    public override void Play(AudioSource source)
    {
        if (_clip.Length == 0)
        {
            Debug.Log("No Audio Clip Detect");
            return;
        }
        source.clip = _clip[Random.Range(0, _clip.Length)];
        source.volume = GetVolume();
        source.pitch = GetPitch();
        source.Play();
    }

    public override void Play()
    {
        if (_clip.Length == 0)
        {
            Debug.Log("No Audio Clip Detect");
            return;
        }
        SetupSourceWithRandomVolAndPitch();
        source.Play();
    }

    public void PlayOneShot()
    {
        if (_clip.Length == 0)
        {
            Debug.Log("No Audio Clip Detect");
            return;
        }
        SetupSourceWithRandomVolAndPitch();
        source.PlayOneShot(source.clip);
    }

    public override void Stop(AudioSource source) => source.Stop();
    public override void Stop() => source.Stop();
}
