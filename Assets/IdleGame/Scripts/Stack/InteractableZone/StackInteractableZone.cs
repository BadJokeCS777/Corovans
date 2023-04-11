using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using Agava.IdleGame.Model;
using System.Collections.Generic;
using System.Linq;

namespace Agava.IdleGame
{
    public abstract class StackInteractableZone<T> : MonoBehaviour where T : StackPresenter
    {
        [SerializeField, Min(0f)] private float _interactionTime = 0.1f;
        [SerializeField] private Trigger<T> _trigger;

        private Timer _timer = new Timer();
        private List<StackPresenter> _enteredStacks = new List<StackPresenter>();
        private Coroutine _waitCoroutine;

        public ITimer Timer => _timer;
        protected virtual float InteracionTime => _interactionTime;

        private void OnEnable()
        {
            _trigger.Enter += OnEnter;
            _trigger.Exit += OnExit;
            _timer.Completed += OnTimeOver;
        }

        private void OnDisable()
        {
            _trigger.Enter -= OnEnter;
            _trigger.Exit -= OnExit;
            _timer.Completed -= OnTimeOver;

            StackPresenter[] stacks = _enteredStacks.ToArray();
            foreach (StackPresenter stack in stacks)
            {
                OnExit(stack);
            }
            
            _enteredStacks.Clear();
        }

        private void Update()
        {
            _timer.Tick(Time.deltaTime);
        }

        private void OnEnter(StackPresenter enteredStack)
        {
            if (_enteredStacks.Contains(enteredStack))
                return;
            
            if (_enteredStacks.Count == 0)
            {
                if (CanInteract(enteredStack))
                    _timer.Start(InteracionTime);
                else
                    _waitCoroutine = StartCoroutine(WaitUntilCanInteract(() => _timer.Start(InteracionTime)));
            }
            
            _enteredStacks.Add(enteredStack);
        }

        private void OnExit(StackPresenter otherStack)
        {
            if (_enteredStacks.Contains(otherStack) == false)
                return;
            
            _enteredStacks.Remove(otherStack);

            if (_enteredStacks.All(CanInteract) && _waitCoroutine != null)
            {
                StopCoroutine(_waitCoroutine);

                if (_enteredStacks.Count > 0)
                    _timer.Start(InteracionTime);
            }

            if (_enteredStacks.Count == 0)
                _timer.Stop();
        }

        private void OnTimeOver()
        {
            StackPresenter[] interacts = _enteredStacks.Where(CanInteract).ToArray();
            foreach (StackPresenter stack in interacts)
            {
                InteractAction(stack);
            }

            _waitCoroutine = StartCoroutine(WaitUntilCanInteract(() => _timer.Start(InteracionTime)));
        }

        private IEnumerator WaitUntilCanInteract(UnityAction finalAction)
        {
            yield return null;
            yield return new WaitUntil(() => _enteredStacks.Any(CanInteract));
            finalAction?.Invoke();
        }

        protected abstract void InteractAction(StackPresenter enteredStack);
        protected abstract bool CanInteract(StackPresenter enteredStack);
    }
}