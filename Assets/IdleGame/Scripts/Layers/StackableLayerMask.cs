using System;
using UnityEngine;

namespace Agava.IdleGame
{
    [Serializable]
    public struct StackableLayerMask
    {
#if UNITY_EDITOR
        private static StackableLayers _layersAsset = StackableLayers.GetAsset();
#endif

        [SerializeField] private int _value;

#if UNITY_EDITOR
        public static string[] Layers => _layersAsset.Layers;
#endif
        public int Value => _value;

#if UNITY_EDITOR
        public static string LayerToName(int layer)
        {
            return _layersAsset.LayerToName(layer);
        }

        public static int NameToLayer(string name)
        {
            return _layersAsset.NameToLayer(name);
        }
#endif

        public bool ContainsLayer(int layer)
        {
            return (_value & (1 << layer)) != 0;
        }
    }
}