using System;
using Agava.IdleGame.Model;
using UnityEngine;

namespace Agava.IdleGame
{
    public class ObjectProducerZone : StackInteractableZone<StackPresenter>
    {
        [Header("Produced template")]
        [SerializeField] private StackableObjectPresenter _template;

        public event Action<StackableObject> GaveStackableObject;

        protected override bool CanInteract(StackPresenter enteredStack)
        {
            return enteredStack.CanAddToStack(_template.Layer);
        }

        protected override void InteractAction(StackPresenter enteredStack)
        {
            StackableObjectPresenter inst = Instantiate(_template, transform.position, Quaternion.identity);
            enteredStack.AddToStack(inst.Stackable);
            
            GaveStackableObject?.Invoke(inst.Stackable);
        }
    }
}