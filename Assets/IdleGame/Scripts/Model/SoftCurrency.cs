
namespace Agava.IdleGame.Model
{
    public class SoftCurrency : Currency
    {
        private const string SaveKey = nameof(SoftCurrency);

        public SoftCurrency()
            : base(SaveKey)
        { }
    }
}