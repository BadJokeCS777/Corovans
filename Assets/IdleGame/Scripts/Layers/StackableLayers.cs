using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Agava.IdleGame
{
    public class StackableLayers : ScriptableObject
    {
        public const string AssetPath = "Assets/Resources/StackableLayers.asset";
        public const int LayersCount = sizeof(int) * 8;

        [SerializeField] private string[] _layers = new string[LayersCount];

        public string[] Layers => _layers.Where(layer => string.IsNullOrEmpty(layer) == false).ToArray();
        public string[] AllLayers => _layers;

        private void Awake()
        {
            _layers[0] = "Default Stackable";
        }

        public string LayerToName(int layer)
        {
            return _layers[layer];
        }

        public int NameToLayer(string name)
        {
            for (int i = 0; i < _layers.Length; i++)
                if (_layers[i] == name)
                    return i;

            return -1;
        }

#if UNITY_EDITOR
        public static StackableLayers GetAsset()
        {
            return AssetDatabase.LoadAssetAtPath<StackableLayers>(AssetPath);
        }
#endif
    }
}