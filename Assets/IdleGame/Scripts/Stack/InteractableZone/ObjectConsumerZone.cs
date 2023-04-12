using Agava.IdleGame.Model;
using UnityEngine;

namespace Agava.IdleGame
{
    public class ObjectConsumerZone : StackInteractableZone<StackPresenter>
    {
        [SerializeField] private StackPresenter _selfStack;

        protected override bool CanInteract(StackPresenter enteredStack)
        {
            if (enteredStack.Count == 0)
                return false;

            foreach (var item in enteredStack.Data)
                if (_selfStack.CanAddToStack(item.Layer))
                    return true;

            return false;
        }

        protected override void InteractAction(StackPresenter enteredStack)
        {
            int index = 0;
            foreach (var item in enteredStack.Data)
            {
                if (_selfStack.CanAddToStack(item.Layer))
                    break;

                index++;
            }

            if (index >= enteredStack.Count)
                return;// throw new InvalidOperationException();

            var stackable = enteredStack.RemoveAt(index);
            _selfStack.AddToStack(stackable);
        }
    }
}