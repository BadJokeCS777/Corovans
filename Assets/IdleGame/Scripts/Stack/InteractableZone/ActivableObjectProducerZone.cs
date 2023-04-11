using System;

namespace Agava.IdleGame
{
    public class ActivableObjectProducerZone : ObjectProducerZone
    {
        private bool _isActive = true;

        public event Action ActivityChanged;

        public bool IsActive => _isActive;

        public void SetActive(bool isActive)
        {
            _isActive = isActive;
            ActivityChanged?.Invoke();
        }

        protected override bool CanInteract(StackPresenter enteredStack)
        {
            return base.CanInteract(enteredStack) && _isActive;
        }
    }
}