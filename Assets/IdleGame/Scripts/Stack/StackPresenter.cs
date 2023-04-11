using UnityEngine;
using UnityEngine.Events;
using Agava.IdleGame.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Agava.IdleGame
{
    public class StackPresenter : MonoBehaviour
    {
        [SerializeField] private StackView _view;
        [SerializeField, Min(0)] private int _capacity;
        [SerializeField] public StackableLayerMask _stackableTypes;

        private StackStorage _stack;

        public event UnityAction CapacityUpdated;
        public event UnityAction<StackableObject> Added;
        public event UnityAction<StackableObject> Removed;

        public int Count => _stack.Count;
        public int Capacity => _capacity;
        public int Layer => _stackableTypes.Value;
        public bool IsEmpty => _stack.Data.Any() == false;
        public bool IsFull => _stack.Data.Count() == _capacity;
        public IEnumerable<StackableObject> Data => _stack.Data;

        private void Awake()
        {
            Init();
        }

        public void Init()
        {
            _stack = new StackStorage(_capacity, _stackableTypes);
        }

        public bool CanAddToStack(int layer)
        {
            return _stack.CanAdd(layer);
        }

        public bool CanAddToStackOnly(int layer)
        {
            return _stack.CanAddOnly(layer);
        }

        public bool CanRemoveFromStack(StackableObject stackable)
        {
            return _stack.Contains(stackable);
        }

        public bool CanRemoveFromStack(int layer)
        {
            return _stack.Contains(layer);
        }

        public void AddToStack(StackableObject stackable)
        {
            if (CanAddToStack(stackable.Layer) == false)
                throw new InvalidOperationException();

            _stack.Add(stackable);
            _view.Add(stackable);
            Added?.Invoke(stackable);
        }

        public StackableObject RemoveAt(int index)
        {
            var stackable = _stack.RemoveAt(index);
            _view.Remove(stackable);

            Removed?.Invoke(stackable);
            return stackable;
        }

        public void RemoveFromStack(StackableObject stackable)
        {
            _stack.Remove(stackable);
            _view.Remove(stackable);

            Removed?.Invoke(stackable);
        }

        public StackableObject RemoveByLayer(int layer)
        {
            if (_stack.Contains(layer) == false)
            {
                throw new ArgumentException($"Stack doesn't contains layer: {layer}");
            }

            var stackable = _stack.RemoveByLayer(layer);
            _view.Remove(stackable);

            Removed?.Invoke(stackable);
            return stackable;
        }

        public int GetCount(int layer)
        {
            return _stack.GetCount(layer);
        }

        public void Clear()
        {
            while (_stack.Count > 0)
                Destroy(RemoveAt(0).View.gameObject);
        }

        protected void UpdateStackCapacity(int newCapacity)
        {
            _capacity = newCapacity;
            _stack = new StackStorage(_stack, newCapacity);
            CapacityUpdated?.Invoke();
        }
    }
}