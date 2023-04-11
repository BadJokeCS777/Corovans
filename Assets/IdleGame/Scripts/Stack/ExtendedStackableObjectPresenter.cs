using Agava.IdleGame.Model;
using UnityEngine;

namespace Agava.IdleGame
{
    public abstract class ExtendedStackableObjectPresenter<T> : StackableObjectPresenter where T : class
    {
        [SerializeField] private T _TValue;
        
        protected override void OnAwake(StackableObject stackableObject)
        {
            SetStackable(new ExtendedStackableObject<T>(stackableObject, _TValue));
        }
    }
}
