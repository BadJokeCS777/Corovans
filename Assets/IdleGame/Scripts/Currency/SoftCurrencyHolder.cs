using Agava.IdleGame.Model;

namespace Agava.IdleGame
{
    public class SoftCurrencyHolder : CurrencyHolder
    {
        protected override Currency InitCurrency() => new SoftCurrency();
    }
}