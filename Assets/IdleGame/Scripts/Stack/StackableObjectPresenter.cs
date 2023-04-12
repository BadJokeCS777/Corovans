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
            _stackable = CreateStackable();
            OnAwake(_stackable);
        }

        protected virtual StackableObject CreateStackable()
        {
            return new StackableObject(transform, _layer);
        }

        protected virtual void OnAwake(StackableObject stackableObject) {}
    }
}