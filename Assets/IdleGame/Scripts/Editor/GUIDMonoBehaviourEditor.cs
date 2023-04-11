using UnityEngine;
using UnityEditor;
using Agava.IdleGame;

namespace Agava.IdleGameEditor
{
    [CustomEditor(typeof(GUIDMonoBehaviour), true)]
    public class GUIDMonoBehaviourEditor : Editor
    {
        private GUIDMonoBehaviour _target;

        private void Awake()
        {
            _target = target as GUIDMonoBehaviour;
        }

        public override void OnInspectorGUI()
        {
            GUILayout.BeginHorizontal();

            if (GUILayout.Button("Generate GUID"))
                _target.RegenerateGUID();
            if (GUILayout.Button("Copy GUID"))
                _target.CopyToClipboard();

            GUILayout.EndHorizontal();

            EditorUtility.SetDirty(_target);

            base.OnInspectorGUI();
        }
    }
}