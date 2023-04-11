using UnityEngine;

namespace Agava.IdleGame
{
    public class StackInteractableTimeView : MonoBehaviour
    {
        [SerializeField] private StackInteractableZone<StackPresenter> _stackInteractableZone;
        [SerializeField] private TimerView _timerView;

        private void Start()
        {
            _timerView.Init(_stackInteractableZone.Timer);
        }
    }
}