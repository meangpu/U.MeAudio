using UnityEngine;
using System;

namespace Meangpu.Audio
{
    public class FindSound
    {
        SOSound[] _sounds;
        SOSound FindSoundByName(string soundName)
        {
            SOSound foundSound = Array.Find(_sounds, sound => sound.name == soundName);
            if (foundSound == null)
            {
                Debug.Log("No Sound Found");
                return null;
            }
            return foundSound;
        }
    }
}