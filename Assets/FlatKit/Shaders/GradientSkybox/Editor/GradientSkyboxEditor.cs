using UnityEngine;
using UnityEditor;

public class GradientSkyboxEditor : UnityEditor.MaterialEditor {

    public override void OnInspectorGUI() {
        serializedObject.Update();

		SerializedProperty theShader = serializedObject.FindProperty ("m_Shader"); 

		if (isVisible && !theShader.hasMultipleDifferentValues && theShader.objectReferenceValue != null) {
            EditorGUI.BeginChangeCheck();

			base.OnInspectorGUI();

            if (EditorGUI.EndChangeCheck()) {
				MaterialProperty dirPitch = GetMaterialProperty(targets, "_DirectionPitch");
				MaterialProperty dirYaw = GetMaterialProperty(targets, "_DirectionYaw");

                float dirPitchRad = dirPitch.floatValue * Mathf.Deg2Rad;
                float dirYawRad = dirYaw.floatValue * Mathf.Deg2Rad;
                
                Vector4 direction = new Vector4(Mathf.Sin(dirPitchRad) * Mathf.Sin(dirYawRad), Mathf.Cos(dirPitchRad), 
				                            Mathf.Sin(dirPitchRad) * Mathf.Cos(dirYawRad), 0.0f);
                GetMaterialProperty(targets, "_Direction").vectorValue = direction;

                PropertiesChanged();
            }
        }
    }

}
