using UnityEngine;

namespace Agava.IdleGame.Examples
{
    public class KeyboardInput : PlayerInput
    {
        private Vector2 _direction = Vector2.zero;

        public override Vector2 Direction => _direction;

        private void Update()
        {
            _direction.x = Input.GetAxis("Horizontal");
            _direction.y = Input.GetAxis("Vertical");
        }
    }
}