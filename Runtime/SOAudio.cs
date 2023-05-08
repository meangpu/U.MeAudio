using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu(fileName = "SOAudio", menuName = "Meangpu/SOAudio")]
public class SOAudio : ScriptableObject
{
    public string audioDes;
    public AudioClip Clip;
    public AudioMixerGroup MixerGroup;

    [MinMaxSlider(0f, 1f, "MaxVolume", "VolumeRange")]
    public float MinVolume = 0.6f;
    [HideInInspector]
    public float MaxVolume = 0.8f;

    [MinMaxSlider(0.1f, 3f, "MaxPitch", "PitchRange")]
    public float MinPitch = 0.8f;
    [HideInInspector]
    public float MaxPitch = 1.2f;

    [Range(0, 1)]
    public float Blend;

    public bool Loop;
    [HideInInspector]
    public AudioSource source;


}