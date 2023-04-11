using System;
using UnityEngine;

namespace Agava.IdleGame.Model
{
    [Serializable]
    public class BuyZone : SavedObject<BuyZone>
    {
        [SerializeField] private DynamicCost _dynamicCost;

        public BuyZone(int totalCost, string guid)
            : base(guid)
        {
            _dynamicCost = new DynamicCost(totalCost);
            IsUnlocked = _dynamicCost.CurrentCost == 0;
        }

        public event Action CostUpdated;
        public event Action<bool> Unlocked;

        public int TotalCost => _dynamicCost.TotalCost;
        public int CurrentCost => _dynamicCost.CurrentCost;
        public bool IsUnlocked { get; private set; }

        public void ReduceCost(int value)
        {
            _dynamicCost.Subtract(value);
            CostUpdated?.Invoke();

            if (_dynamicCost.CurrentCost == 0)
            {
                IsUnlocked = true;
                Unlocked?.Invoke(false);
            }
        }

        protected override void OnLoad(BuyZone loadedObject)
        {
            _dynamicCost = loadedObject._dynamicCost;

            if (_dynamicCost.CurrentCost == 0)
            {
                IsUnlocked = true;
                Unlocked?.Invoke(true);
            }
        }
    }
}