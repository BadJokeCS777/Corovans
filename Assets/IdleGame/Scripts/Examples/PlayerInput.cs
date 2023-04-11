using UnityEngine;

namespace Agava.IdleGame.Examples
{
    public abstract class PlayerInput : MonoBehaviour
    {
        public abstract Vector2 Direction { get; }
    }
}