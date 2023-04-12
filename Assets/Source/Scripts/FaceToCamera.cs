using UnityEngine;

internal class FaceToCamera : MonoBehaviour
{
    private Transform _camera;

    private void Awake()
    {
        _camera = Camera.main.transform;
    }

    private void LateUpdate()
    {
        transform.forward = _camera.forward;
    }
}