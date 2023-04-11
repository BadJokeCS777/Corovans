using UnityEngine;

namespace Agava.IdleGame
{
    public abstract class UnlockableObject : MonoBehaviour
    {
        public abstract GameObject Unlock(Transform parent, bool onLoad, string guid);
    }
}