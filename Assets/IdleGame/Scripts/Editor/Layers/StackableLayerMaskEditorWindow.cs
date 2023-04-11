using Agava.IdleGame;
using UnityEditor;

namespace Agava.IdleGameEditor
{
    public class StackableLayerMaskEditorWindow : EditorWindow
    {
        private static string AssetPath => StackableLayers.AssetPath;

        [MenuItem("IdleGame/Layers")]
        public static void Open()
        {
            var asset = AssetDatabase.LoadAssetAtPath<StackableLayers>(AssetPath);

            if (asset == null)
            {
                asset = CreateInstance<StackableLayers>();
                AssetDatabase.CreateAsset(asset, AssetPath);
                AssetDatabase.SaveAssets();
            }

            EditorUtility.FocusProjectWindow();
            Selection.activeObject = asset;
        }
    }
}