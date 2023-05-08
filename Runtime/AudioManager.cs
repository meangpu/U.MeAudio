using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    // AudioManager.instance?.Play(playName);

    [SerializeField] SOSound[] _sounds;
    public static AudioManager instance;
    private AudioSource[] _allAudioSources;
    [SerializeField] AudioSource _freeSource;


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
        if (_freeSource == null) _freeSource = gameObject.AddComponent<AudioSource>();

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
        soundObj.source.clip = soundObj.clip;
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
        SOSound soundObj = FindSound(soObj.name);
        soundObj.source.clip = soundObj.clip;
        soundObj.SetupSourceWithRandomVolAndPitch();
        soundObj.source.Play();
    }

    public void PlayChangeVol(string name, float newVolume)
    {
        SOSound soundObj = FindSound(name);
        soundObj.source.clip = soundObj.clip;
        soundObj.source.volume = newVolume;
        soundObj.source.Play();
    }

    public void PlayChangePitch(string name, float newPitch)
    {
        SOSound soundObj = FindSound(name);
        soundObj.source.clip = soundObj.clip;
        soundObj.source.pitch = newPitch;
        soundObj.source.Play();
    }

    public void PlayOneShot(string name)
    {
        SOSound soundObj = FindSound(name);
        soundObj.source.clip = soundObj.clip;
        soundObj.SetupSourceWithRandomVolAndPitch();
        soundObj.source.PlayOneShot(soundObj.clip);
    }


    public void PlayOneShot(string name, float newVolume, float newPitch)
    {
        SOSound soundObj = FindSound(name);
        soundObj.source.clip = soundObj.clip;
        soundObj.source.volume = newVolume;
        soundObj.source.pitch = newPitch;
        soundObj.source.PlayOneShot(soundObj.clip);
    }

    public void PlayOneShotChangeVolume(string name, float newVolume)
    {
        SOSound soundObj = FindSound(name);
        soundObj.source.clip = soundObj.clip;
        soundObj.source.pitch = newVolume;
        soundObj.source.PlayOneShot(soundObj.clip);
    }

    public void PlayOneShotChangePitch(string name, float newPitch)
    {
        SOSound soundObj = FindSound(name);
        soundObj.source.clip = soundObj.clip;
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

    public void PlayAudioClipAtPos(AudioClip _clip, Transform _trans, float _volume = 1, float min = 0.7f, float max = 1.5f)
    {
        transform.position = _trans.position;
        _freeSource.clip = _clip;
        _freeSource.volume = _volume;
        _freeSource.pitch = UnityEngine.Random.Range(min, max);
        _freeSource.spatialBlend = 1;
        _freeSource.Play();
    }

    public void PlayAudioClipOneShotAtPos(AudioClip _clip, Transform _trans, float _volume = 1, float min = 0.7f, float max = 1.5f)
    {
        transform.position = _trans.position;
        _freeSource.volume = _volume;
        _freeSource.pitch = UnityEngine.Random.Range(min, max);
        _freeSource.spatialBlend = 1;
        _freeSource.PlayOneShot(_clip);
    }


}
