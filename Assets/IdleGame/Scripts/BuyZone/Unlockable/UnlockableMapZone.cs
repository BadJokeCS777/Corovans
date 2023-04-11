using UnityEngine;

namespace Agava.IdleGame
{
    public class UnlockableMapZone : UnlockableObject
    {
        [SerializeField] private GameObject _mapRoot;

        public override GameObject Unlock(Transform parent, bool onLoad, string guid)
        {
            _mapRoot.SetActive(true);
            return _mapRoot;
        }
    }
}