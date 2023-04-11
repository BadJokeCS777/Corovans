using System;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Agava.IdleGame
{
    public class GUIDMonoBehaviour : MonoBehaviour
    {
#if UNITY_EDITOR
        [ReadOnly]
#endif
        [SerializeField] private string _guid;

        public string GUID => _guid;

#if UNITY_EDITOR
        [ContextMenu("Regenerate GUID")]
        public void RegenerateGUID()
        {
            _guid = Guid.NewGuid().ToString();
            EditorUtility.SetDirty(gameObject);
        }

        [ContextMenu("Copy GUID to clipboard")]
        public void CopyToClipboard()
        {
            GUIUtility.systemCopyBuffer = _guid;
            Debug.Log($"GUID: {_guid} copied to clipboard");
        }
#endif
    }
}