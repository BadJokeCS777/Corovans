using Agava.IdleGame;
using Agava.IdleGame.Model;
using UnityEngine;

internal class HarvestPresenter : StackableObjectPresenter
{
    [SerializeField] private int _price = 100;

    protected override StackableObject CreateStackable()
    {
        return new Harvest(transform, Layer, _price);
    }
}