using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu(fileName = "SOSound", menuName = "Meangpu/SOSound")]
public class SOSound : ScriptableObject
{
    public string audioDes;
    public AudioClip clip;
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
        source.volume = GetVolume();
        source.pitch = GetPitch();
    }

}