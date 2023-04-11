using UnityEngine;

namespace Agava.IdleGame.Examples
{
    public class CameraFollower : MonoBehaviour
    {
        private const float SmoothingPower = 0.3f;

        [SerializeField] private Transform _target;

        private Vector3 _positionOffset;

        private void Awake()
        {
            _positionOffset = transform.position - _target.position;
        }

        private void LateUpdate()
        {
            Vector3 desiredPosition = _target.position + _positionOffset;
            transform.position = Vector3.Lerp(transform.position, desiredPosition, 1f / SmoothingPower * Time.deltaTime);
        }
    }
}