using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Agava.IdleGame.Model;

namespace Agava.IdleGame
{
    public class TimerView : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _timerCanvasGroup;
        [SerializeField] private Image _timerImage;
        [SerializeField] private float _fadeDuration = 0.5f;

        private ITimer _timer;

        private void OnEnable()
        {
            _timerCanvasGroup.alpha = 0f;

            if (_timer != null)
                SubscribeTimeEvents();
        }

        private void OnDisable()
        {
            if (_timer != null)
                UnsubscribeTimeEvents();
        }

        public void Init(ITimer timer)
        {
            if (_timer != null)
                UnsubscribeTimeEvents();

            _timer = timer;
            SubscribeTimeEvents();
        }

        private void OnTimerStart()
        {
            _timerCanvasGroup.DOKill();
            _timerCanvasGroup.DOFade(1, _fadeDuration);
        }

        private void OnTimerUpdate()
        {
            _timerImage.fillAmount = (_timer.TotalTime - _timer.TimeLeft) / _timer.TotalTime;
        }

        private void OnTimerStopped()
        {
            _timerCanvasGroup.DOKill();
            _timerCanvasGroup.DOFade(0, _fadeDuration);

            _timerImage.fillAmount = 0f;
        }

        private void OnTimerCompleted()
        {
            _timerCanvasGroup.DOKill();
            _timerCanvasGroup.DOFade(0, _fadeDuration);

            _timerImage.fillAmount = 0f;
        }

        private void SubscribeTimeEvents()
        {
            _timer.Started += OnTimerStart;
            _timer.Updated += OnTimerUpdate;
            _timer.Stopped += OnTimerStopped;
            _timer.Completed += OnTimerCompleted;
        }

        private void UnsubscribeTimeEvents()
        {
            _timer.Started -= OnTimerStart;
            _timer.Updated -= OnTimerUpdate;
            _timer.Stopped -= OnTimerStopped;
            _timer.Completed -= OnTimerCompleted;
        }
    }
}