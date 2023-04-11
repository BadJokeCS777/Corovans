using Agava.IdleGame.Model;
using UnityEngine;

namespace Agava.IdleGame
{
    public class StackableObjectPresenter : MonoBehaviour
    {
        [SerializeField]
        [StackableLayer] private int _layer;

        private StackableObject _stackable;

        public StackableObject Stackable => _stackable;
        public int Layer => _stackable?.Layer ?? _layer;

        private void Awake()
        {
            SetStackable(new StackableObject(transform, _layer));
            OnAwake(_stackable);
        }

        protected void SetStackable(StackableObject stackable)
        {
            _stackable = stackable;
        }

        protected virtual void OnAwake(StackableObject stackableObject) {}
    }
}