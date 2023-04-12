using Agava.IdleGame;
using Agava.IdleGame.Model;
using UnityEngine;

internal class SeedPresenter : StackableObjectPresenter
{
    [SerializeField] private Plant _plantPrefab;

    protected override StackableObject CreateStackable()
    {
        return new Seed(transform, Layer, _plantPrefab);
    }
}