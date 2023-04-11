using UnityEngine;
using UnityEngine.UI;

namespace Agava.IdleGame.Examples
{
    [RequireComponent(typeof(Button))]
    public class AddCurrencyButton : MonoBehaviour
    {
        [SerializeField] private SoftCurrencyHolder _currencyHolder;
        [SerializeField] private int _addValue = 10;

        private Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(OnButtonClicked);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnButtonClicked);
        }

        private void OnButtonClicked()
        {
            _currencyHolder.Add(_addValue);
        }
    }
}