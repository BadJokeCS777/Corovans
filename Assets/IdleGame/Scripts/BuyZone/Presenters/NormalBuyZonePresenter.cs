using UnityEngine;
using Agava.IdleGame.Model;

namespace Agava.IdleGame
{
    public class NormalBuyZonePresenter : BuyZonePresenter
    {
        [Space(5)]
        [SerializeField] private bool _alwaysUnlocked = false;

        private int _reduceValue = 1;

        protected override void OnBuyZoneLoaded(BuyZone buyZone)
        {
            if (_alwaysUnlocked && buyZone.CurrentCost > 0)
            {
                buyZone.ReduceCost(buyZone.CurrentCost);
                buyZone.Save();
            }
        }

        protected override void BuyFrame(BuyZone buyZone, SoftCurrencyHolder moneyHolder)
        {
            if (moneyHolder.HasMoney == false)
                return;

            _reduceValue = Mathf.Clamp((int)(TotalCost * 1.5f * Time.deltaTime), 1, TotalCost);
            if (buyZone.CurrentCost < _reduceValue)
                _reduceValue = buyZone.CurrentCost;

            _reduceValue = Mathf.Clamp(_reduceValue, 1, moneyHolder.Value);

            buyZone.ReduceCost(_reduceValue);
            moneyHolder.Spend(_reduceValue);
        }
    }
}