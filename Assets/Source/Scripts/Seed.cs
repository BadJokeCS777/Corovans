using Agava.IdleGame.Model;
using UnityEngine;

internal class Seed : StackableObject
{
    public Plant Plant { get; }
    
    public Seed(Transform view, int layer, Plant plant) : base(view, layer)
    {
        Plant = plant;
    }
}