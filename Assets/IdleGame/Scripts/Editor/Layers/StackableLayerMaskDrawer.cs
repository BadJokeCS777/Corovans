using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using Agava.IdleGame;

namespace Agava.IdleGameEditor
{
    [CustomPropertyDrawer(typeof(StackableLayerMask))]
    public class StackableLayerMaskDrawer : PropertyDrawer
    {
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return base.GetPropertyHeight(property, label);
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var field = typeof(StackableLayerMask)
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .First(field => field.FieldType == typeof(int));

            var value = property.FindPropertyRelative(field.Name);

            EditorGUI.BeginProperty(position, label, property);
            {
                EditorGUI.BeginDisabledGroup(false);
                {
                    value.intValue = StackableLayerMaskExtention.LayerMaskField(position, label.text, value.intValue);
                }
                EditorGUI.EndDisabledGroup();
            }
            EditorGUI.EndProperty();
        }
    }
}