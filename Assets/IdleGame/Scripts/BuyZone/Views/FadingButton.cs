using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Agava.IdleGame
{
    [RequireComponent(typeof(Button))]
    public class FadingButton : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private float _fadeDuration = 0.5f;

        private Button _button;
        
        public event UnityAction Clicked;

        public bool CanClick { get; private set; }

        private void Awake()
        {
            _button = GetComponent<Button>();
            _canvasGroup.DisableFade(_fadeDuration);
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(OnButtonClick);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnButtonClick);
        }

        public void Enable()
        {
            CanClick = true;
            _canvasGroup.EnableFade(_fadeDuration);
        }

        public void Disable()
        {
            CanClick = false;
            _canvasGroup.DisableFade(_fadeDuration);
        }

        private void OnButtonClick()
        {
            Clicked?.Invoke();
        }
    }
}