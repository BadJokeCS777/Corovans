using Agava.IdleGame;
using Agava.IdleGame.Model;
using UnityEngine;
using UnityEngine.UIElements;

internal class Market : MonoBehaviour
{
    [SerializeField] private CurrencyHolder _currencyHolder;
    [SerializeField] private StackPresenter _stack;

    private void OnEnable()
    {
        _stack.Added += OnAdded;
    }

    private void OnAdded(StackableObject stackable)
    {
        Harvest harvest = stackable as Harvest;

        _currencyHolder.Add(harvest.Price);
        _stack.RemoveFromStack(harvest);
    }
}
