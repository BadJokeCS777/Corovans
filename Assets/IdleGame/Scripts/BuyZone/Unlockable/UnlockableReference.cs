using UnityEngine;
using UnityEngine.Events;

namespace Agava.IdleGame
{
    public abstract class UnlockableReference<T> : UnlockableObject where T : MonoBehaviour
    {
        [SerializeField] private T _template;

        public event UnityAction<T, bool, string> Unlocked;

        public override GameObject Unlock(Transform parent, bool onLoad, string guid)
        {
            T inst = Instantiate(_template, parent);
            Unlocked?.Invoke(inst, onLoad, guid);

            return inst.gameObject;
        }
    }
}