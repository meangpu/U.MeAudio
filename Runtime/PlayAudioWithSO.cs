using UnityEngine;

public class PlayAudioWithSO : MonoBehaviour
{
    [SerializeField] SOSound sound;
    [SerializeField] bool playOnStart;

    private void Start()
    {
        if (playOnStart) PlaySound();
    }

    public void PlaySound() => AudioManager.instance?.Play(sound);
}
