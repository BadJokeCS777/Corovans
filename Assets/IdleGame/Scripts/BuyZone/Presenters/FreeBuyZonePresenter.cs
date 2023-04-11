using Agava.IdleGame.Model;
using UnityEngine;

namespace Agava.IdleGame
{
    public class FreeBuyZonePresenter : BuyZonePresenter
    {
        [Space(5)]
        [SerializeField] private FadingButton _unlockButton;

        private BuyZone _freeBuyZone;

        protected override void OnEnabled()
        {
            _unlockButton.Clicked += OnRewardButtonClicked;
        }

        protected override void OnDisabled()
        {
            _unlockButton.Clicked -= OnRewardButtonClicked;
        }

        protected override void OnBuyZoneLoaded(BuyZone buyZone)
        {
            _freeBuyZone = buyZone;
        }

        protected override void OnEnter()
        {
            _unlockButton.Enable();
        }

        protected override void OnExit()
        {
            _unlockButton.Disable();
        }

        private void OnRewardButtonClicked()
        {
            var rewardedAdShown = true; // Implement you'r show reward ad logic
            if (rewardedAdShown)
            {
                _freeBuyZone.ReduceCost(_freeBuyZone.TotalCost);
                _freeBuyZone.Save();
            }
        }

        protected override void BuyFrame(BuyZone buyZone, SoftCurrencyHolder moneyHolder) { }
    }
}