using UnityEngine;
using UnityEditor;
using Agava.IdleGame;

namespace Agava.IdleGameEditor
{
    public class LayerObjectEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            GUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();
            if (GUILayout.Button("Add Layer..."))
            {
                EditorUtility.FocusProjectWindow();
                var asset = StackableLayers.GetAsset();
                EditorGUIUtility.PingObject(asset);
                Selection.activeObject = asset;
            }
            GUILayout.EndHorizontal();
        }
    }
}