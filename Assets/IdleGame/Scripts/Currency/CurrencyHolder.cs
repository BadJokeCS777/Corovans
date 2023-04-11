using Agava.IdleGame.Model;
using UnityEngine;
using UnityEngine.Events;

namespace Agava.IdleGame
{
    public abstract class CurrencyHolder : MonoBehaviour
    {
        [SerializeField] private int _startValue;
        
        private Currency _currency;

        public event UnityAction<int> BalanceChanged;
        public event UnityAction CurrencyAdded;

        protected abstract Currency InitCurrency();

        public int Value => _currency.Value;
        public bool HasMoney => _currency.Value > 0;

        private void OnEnable()
        {
            _currency = InitCurrency();
            int addValue = _currency.HasSave ? 0 : _startValue;
            
            _currency.Load();
            _currency.Add(addValue);
            
            _currency.Changed += OnBalanceChanged;
        }

        private void OnDisable()
        {
            _currency.Changed -= OnBalanceChanged;
            _currency.Save();
        }

        public void Add(int value)
        {
            _currency.Add(value);
            CurrencyAdded?.Invoke();
        }

        public void Spend(int value)
        {
            _currency.Spend(value);
        }

        private void OnBalanceChanged()
        {
            BalanceChanged?.Invoke(_currency.Value);
            _currency.Save();
        }
    }
}