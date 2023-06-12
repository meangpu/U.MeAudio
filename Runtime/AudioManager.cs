using UnityEngine;
using System.Collections;
using System;

public class AudioManager : MonoBehaviour
{
    // AudioManager.instance?.Play(playName);
    // SoSoundObj.Play();

    [SerializeField] SOSound[] _sounds;
    public static AudioManager instance;
    private AudioSource[] _allAudioSources;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        foreach (SOSound s in _sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.SetupSourceWithRandomVolAndPitch();
            s.source.clip = s.clip;
            s.source.outputAudioMixerGroup = s.mixerGroup;
            s.source.spatialBlend = s.blend;
            s.source.loop = s.loop;
        }
    }

    SOSound FindSound(string soundName)
    {
        SOSound foundSound = Array.Find(_sounds, sound => sound.name == soundName);
        if (foundSound == null)
        {
            Debug.Log("No Sound Found");
            return null;
        }
        return foundSound;
    }

    public void Play(string name)
    {
        SOSound soundObj = FindSound(name);
        soundObj.SetupSourceWithRandomVolAndPitch();
        soundObj.source.Play();
    }

    public void Play(string name, float newVolume, float newPitch)
    {
        SOSound soundObj = FindSound(name);
        soundObj.source.clip = soundObj.clip;
        soundObj.source.volume = newVolume;
        soundObj.source.pitch = newPitch;
        soundObj.source.Play();
    }

    public void Play(SOSound soObj)
    {
        soObj.SetupSourceWithRandomVolAndPitch();
        soObj.source.Play();
    }

    public void PlayOneShot(string name)
    {
        SOSound soundObj = FindSound(name);
        if (soundObj.source == null)
        {
            Debug.Log("No Audio SOurce");
            return;
        }
        soundObj.SetupSourceWithRandomVolAndPitch();
        soundObj.source.PlayOneShot(soundObj.clip);
    }

    public void PlayOneShot(SOSound soundObj)
    {
        if (soundObj.source == null)
        {
            Debug.Log("No Audio SOurce");
            return;
        }
        soundObj.SetupSourceWithRandomVolAndPitch();
        soundObj.source.PlayOneShot(soundObj.clip);
    }

    public void PlayOneShot(string name, float newVolume, float newPitch)
    {
        SOSound soundObj = FindSound(name);
        if (soundObj.source == null)
        {
            Debug.Log("No Audio SOurce");
            return;
        }
        soundObj.source.clip = soundObj.clip;
        soundObj.source.volume = newVolume;
        soundObj.source.pitch = newPitch;
        soundObj.source.PlayOneShot(soundObj.clip);
    }

    public void PlayOneShot(SOSound soObj, float newVolume, float newPitch)
    {
        SOSound soundObj = FindSound(soObj.name);
        soundObj.source.clip = soundObj.clip;
        soundObj.source.volume = newVolume;
        soundObj.source.pitch = newPitch;
        soundObj.source.PlayOneShot(soundObj.clip);
    }

    public void StopAllSound()
    {
        _allAudioSources = FindObjectsOfType<AudioSource>();
        foreach (AudioSource audio in _allAudioSources)
        {
            audio.Stop();
        }
    }

    public void MuteSourceByName(string soundName)
    {
        FindSound(soundName).source.volume = 0;
    }

    public void SetSourceVolumeByName(string soundName, int newVol)
    {
        FindSound(soundName).source.volume = newVol;
    }

    public void ResetVolumeByName(string soundName)
    {
        FindSound(soundName).SetupSourceWithRandomVolAndPitch();
    }

    // public static IEnumerator FadeOut(SOSound audioSource, float FadeTime = 1.3f)
    // {
    //     SOSound soundObj = FindSound(audioSource.name);
    //     float startVolume = soundObj.source.volume;
    //     while (soundObj.source.volume > 0)
    //     {
    //         audioSource.volume -= startVolume * Time.deltaTime / FadeTime;
    //         yield return null;
    //     }
    //     audioSource.Stop();
    // }

    // public static IEnumerator FadeIn(SOSound audioSource, float FadeTime = 1.3f)
    // {
    //     audioSource.Play();
    //     audioSource.volume = 0f;
    //     while (audioSource.volume < 1)
    //     {
    //         audioSource.volume += Time.deltaTime / FadeTime;
    //         yield return null;
    //     }
    // }

    // void Start()
    // {
    //     soudtrackAudioSource = GetComponent<AudioSource>();
    // }

    // StartCoroutine(AudioHelper.FadeIn(soudtrackAudioSource, fadeTime));
    // StartCoroutine(AudioHelper.FadeOut(soudtrackAudioSource, fadeTime));
}
