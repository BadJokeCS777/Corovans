using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


    [CustomEditor(typeof(RampAsset))]
    public class RampAssetEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            if (GUILayout.Button("Bake"))
                Bake();
        }
        void Bake()
        {
            RampAsset r = target as RampAsset;
            Texture2D t = new Texture2D(r.size, r.size, TextureFormat.ARGB32, mipChain: true);
            Color[] p = t.GetPixels();
            for (int x = 0; x < r.size; x++)
                for (int y = 0; y < r.size; y++)
                    p[r.up ? y + (r.size - x - 1) * r.size : x + y * r.size] = r.gradient.Evaluate(x * 1f / r.size);
            t.SetPixels(p);
            t.Apply();
            byte[] bytes = t.EncodeToPNG();
            string path = AssetDatabase.GetAssetPath(r).Replace(".asset", "") + ".png";
            if (!r.overwriteExisting)
                path = AssetDatabase.GenerateUniqueAssetPath(path);
            System.IO.File.WriteAllBytes(path, bytes);
            AssetDatabase.Refresh();
        }
    }
