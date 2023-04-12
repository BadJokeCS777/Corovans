using Agava.IdleGame.Model;
using UnityEngine;

internal class Harvest : StackableObject
{
    public int Price { get; }
    
    public Harvest(Transform view, int layer, int price) : base(view, layer)
    {
        Price = price;
    }
}