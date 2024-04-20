using UnityEngine;
using UnityEngine.UI;

namespace Meangpu.Audio
{
    public class AddButtonAudio : MonoBehaviour
    {
        Button[] _allBtnList;
        [SerializeField] SOSound _clickSound;

        private void Start()
        {
            _allBtnList = Resources.FindObjectsOfTypeAll<Button>();
            foreach (Button _b in _allBtnList)
            {
                _b.onClick.AddListener(PlayClickSound);
            }
        }

        void PlayClickSound() => _clickSound?.PlayOneShot();
    }
}