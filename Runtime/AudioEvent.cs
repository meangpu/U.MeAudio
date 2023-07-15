using UnityEngine;

namespace Meangpu.Audio
{
    public abstract class AudioEvent : ScriptableObject
    {
        public abstract void Play(AudioSource source);
        public abstract void Stop(AudioSource source);
        public abstract void Play();
        public abstract void Play(float volume);
        public abstract void Stop();
    }
}