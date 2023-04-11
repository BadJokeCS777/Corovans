using System;
using UnityEngine;
using Agava.IdleGame.Model;
using DG.Tweening;

namespace Agava.IdleGame
{
    public class TrashZone : StackInteractableZone<StackPresenter>
    {
        [SerializeField] private StackableLayerMask _layers;

        protected override bool CanInteract(StackPresenter enteredStack)
        {
            foreach (var item in enteredStack.Data)
                if (_layers.ContainsLayer(item.Layer))
                    return true;

            return false;
        }

        protected override void InteractAction(StackPresenter enteredStack)
        {
            StackableObject removedObject = null;
            foreach (var item in enteredStack.Data)
            {
                if (_layers.ContainsLayer(item.Layer))
                {
                    removedObject = item;
                    break;
                }
            }

            if (removedObject == null)
                throw new InvalidOperationException("Can't remove object from stack");

            enteredStack.RemoveFromStack(removedObject);
            removedObject.View.DOMove(transform.position, 1f).OnComplete(() => Destroy(removedObject.View.gameObject));
        }
    }
}