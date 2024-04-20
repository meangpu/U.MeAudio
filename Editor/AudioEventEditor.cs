using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Meangpu.Audio
{
    [CustomEditor(typeof(AudioEvent), true)]
    public class AudioEventEditor : Editor
    {
        [SerializeField] private AudioSource _previewer;

        public void OnEnable()
        {
            _previewer = EditorUtility.CreateGameObjectWithHideFlags("Audio preview", HideFlags.HideAndDontSave, typeof(AudioSource)).GetComponent<AudioSource>();
        }

        public void OnDisable()
        {
            DestroyImmediate(_previewer.gameObject);
        }

        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            EditorGUI.BeginDisabledGroup(serializedObject.isEditingMultipleObjects);
            if (GUILayout.Button("Preview-Audio"))
            {
                ((AudioEvent)target).Play(_previewer);
            }
            if (GUILayout.Button("Stop-Audio"))
            {
                ((AudioEvent)target).Stop(_previewer);
            }
            EditorGUI.EndDisabledGroup();
        }
    }
}