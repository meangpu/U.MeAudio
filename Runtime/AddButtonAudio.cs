using UnityEngine;
using UnityEngine.UI;

public class AddButtonAudio : MonoBehaviour
{
    Button[] _allBtnList;
    [SerializeField] SOSound audioObj;

    private void Start()
    {
        _allBtnList = Resources.FindObjectsOfTypeAll<Button>();
        foreach (Button _b in _allBtnList) _b.onClick.AddListener(PlaySound);
    }

    void PlaySound() => AudioManager.instance?.Play(audioObj);

}
