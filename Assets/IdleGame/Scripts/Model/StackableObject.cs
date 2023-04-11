using UnityEngine;

namespace Agava.IdleGame.Model
{
    public class StackableObject
    {
        public readonly Transform View;
        public int Layer;

        public StackableObject(Transform view, int layer)
        {
            View = view;
            Layer = layer;
        }
    }

    public class ExtendedStackableObject<T> : StackableObject where T : class
    {
        public readonly T TValue;
        
        public ExtendedStackableObject(Transform view, int layer, T Tvalue) : base(view, layer)
        {
            TValue = Tvalue;
        }

        public ExtendedStackableObject(StackableObject stackableObject, T Tvalue) : 
            base(stackableObject.View, stackableObject.Layer)
        {
            TValue = Tvalue;
        } 
    }
}