using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using Agava.IdleGame.Model;

namespace Agava.IdleGame
{
    public abstract class BuyZonePresenter : GUIDMonoBehaviour
    {
        [Space(10)]
        [SerializeField] private int _totalCost;
        [SerializeField] private Trigger<SoftCurrencyHolder> _trigger;
        [SerializeField] private BuyZoneView _view;
        [SerializeField] private UnlockableObject _unlockable;

        private BuyZone _buyZone;
        private Coroutine _tryBuy;

        public event UnityAction<BuyZonePresenter> FirstTimeUnlocked;
        public event UnityAction<BuyZonePresenter> Unlocked;

        public int TotalCost => _totalCost;
        public UnlockableObject UnlockableObject => _unlockable;
        public bool IsUnlocked => _buyZone != null && _buyZone.IsUnlocked;

        private void OnValidate()
        {
            _view?.RenderProgress(_totalCost, _totalCost);
        }

        private void Awake()
        {
            _buyZone = new BuyZone(_totalCost, GUID);
        }

        private void OnEnable()
        {
            _trigger.Enter += OnPlayerTriggerEnter;
            _trigger.Exit += OnPlayerTriggerExit;
            _buyZone.Unlocked += OnBuyZoneUnlocked;
            _buyZone.CostUpdated += UpdateCost;

            OnEnabled();
        }

        private void OnDisable()
        {
            _trigger.Enter -= OnPlayerTriggerEnter;
            _trigger.Exit -= OnPlayerTriggerExit;
            _buyZone.Unlocked -= OnBuyZoneUnlocked;
            _buyZone.CostUpdated -= UpdateCost;

            OnDisabled();
        }

        private void Start()
        {
            _buyZone.Load();
            UpdateCost();

            OnBuyZoneLoaded(_buyZone);
        }

        public void Init(int totalCost)
        {
            _totalCost = totalCost;
            _buyZone = new BuyZone(_totalCost, GUID);
            Start();
        }

        private void OnPlayerTriggerEnter(SoftCurrencyHolder moneyHolder)
        {
            if (_tryBuy != null)
                StopCoroutine(_tryBuy);

            _tryBuy = StartCoroutine(TryBuy(moneyHolder));
            OnEnter();
        }

        private void OnPlayerTriggerExit(SoftCurrencyHolder moneyHolder)
        {
            StopCoroutine(_tryBuy);
            _buyZone.Save();
            OnExit();
        }

        private void OnBuyZoneUnlocked(bool onLoad)
        {
            _trigger.Disable();
            _view.Hide();
            _unlockable.Unlock(transform, onLoad, GUID);

            Unlocked?.Invoke(this);
        }

        private IEnumerator TryBuy(SoftCurrencyHolder moneyHolder)
        {
            yield return null;

            while (true)
            {
                BuyFrame(_buyZone, moneyHolder);
                UpdateCost();

                yield return null;
            }
        }

        private void UpdateCost()
        {
            _view.RenderProgress(_buyZone.CurrentCost, _totalCost);
        }

        protected virtual void OnBuyZoneLoaded(BuyZone buyZone) { }
        protected virtual void OnEnabled() { }
        protected virtual void OnDisabled() { }
        protected virtual void OnEnter() { }
        protected virtual void OnExit() { }
        protected abstract void BuyFrame(BuyZone buyZone, SoftCurrencyHolder moneyHolder);
    }
}