using UnityEngine;

public abstract class AudioEvent : ScriptableObject
{
    public abstract void Play(AudioSource source);
    public abstract void Play();
    public abstract void Stop(AudioSource source);
    public abstract void Stop();
}