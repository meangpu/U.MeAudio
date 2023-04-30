using UnityEngine;
using UnityEngine.Audio;
using System;

[Serializable]
public class Sound : ISerializationCallbackReceiver
{
    public string audioName;
    public AudioClip clip;
    public AudioMixerGroup mixerGroup;
    [Range(0, 1)]
    public float volume = 1f;
    [Range(0.1f, 3f)]
    public float pitch = 1;
    [Range(0, 1)]
    public float blend;
    public bool loop;
    [HideInInspector]
    public AudioSource source;
    [SerializeField] private bool _serialized = false;

    public void OnBeforeSerialize()
    {
    }

    public void OnAfterDeserialize()
    {
        if (_serialized == false)
        {
            volume = 1;
            pitch = 1;
            _serialized = true;
        }
    }


}
