using UnityEngine;

namespace Agava.IdleGame.Examples
{
    public class JoystickInput : PlayerInput
    {
        [SerializeField] private Joystick _joystick;

        private Transform _mainCamera;

        private void Awake()
        {
            _mainCamera = Camera.main.transform;
        }

        public override Vector2 Direction => Quaternion.Euler(0f, 0f, -_mainCamera.eulerAngles.y) * _joystick.Direction.normalized;
    }
}