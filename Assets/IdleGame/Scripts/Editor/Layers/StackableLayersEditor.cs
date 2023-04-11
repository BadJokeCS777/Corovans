using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using Agava.IdleGame;

namespace Agava.IdleGameEditor
{
    [CustomEditor(typeof(StackableLayers))]
    public class StackableLayersEditor : Editor
    {
        private StackableLayers _layers;
        private SerializedProperty _layersArray;

        private void Awake()
        {
            _layers = target as StackableLayers;

            var array = _layers.GetType()
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .First(field => field.FieldType == typeof(string[]));
            _layersArray = serializedObject.FindProperty(array.Name);
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            GUI.enabled = false;
            EditorGUILayout.PropertyField(_layersArray.GetArrayElementAtIndex(0), new GUIContent($"Stackable {0}"));
            GUI.enabled = true;

            for (int i = 1; i < _layersArray.arraySize; i++)
                EditorGUILayout.PropertyField(_layersArray.GetArrayElementAtIndex(i), new GUIContent($"Stackable {i}"));

            serializedObject.ApplyModifiedProperties();
            EditorUtility.SetDirty(_layers);
        }
    }
}