using UnityEditor;
using UnityEngine;

namespace Agava.IdleGame
{
    public class StackableLayerAttribute : PropertyAttribute { }

#if UNITY_EDITOR
    [CustomPropertyDrawer(typeof(StackableLayerAttribute))]
    public class StackableLayerAttributeDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var asset = StackableLayers.GetAsset();
            property.intValue = EditorGUI.Popup(position, label.text, property.intValue, asset.AllLayers);
        }
    }
#endif
}