using TMPro;
using UnityEngine;

namespace Agava.IdleGame.Examples
{
    public class CurrencyView : MonoBehaviour
    {
        private const string _coin = " <sprite=0>";

        [SerializeField] private CurrencyHolder _holder;
        [SerializeField] private TMP_Text _currencyText;

        private void OnEnable()
        {
            _holder.BalanceChanged += OnBalanceChanged;
        }

        private void OnDisable()
        {
            _holder.BalanceChanged -= OnBalanceChanged;
        }

        private void Start()
        {
            OnBalanceChanged(_holder.Value);
        }

        private void OnBalanceChanged(int balance)
        {
            _currencyText.text = balance + _coin;
        }
    }
}