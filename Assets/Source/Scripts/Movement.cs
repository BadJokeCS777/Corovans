using Agava.IdleGame.Examples;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
internal class Movement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _model;
    [SerializeField] private PlayerInput _input;
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private PlayerAnimator _animator;

    private void Update()
    {
        if (_agent.enabled == false)
            return;

        Vector3 rawDirection = new(_input.Direction.x, 0f, _input.Direction.y);
        float finalSpeed = _speed * rawDirection.magnitude;

        _animator.SetSpeed(finalSpeed);
        _agent.Move(finalSpeed * Time.deltaTime * rawDirection);

        if (finalSpeed > 0f)
            _model.rotation = Quaternion.LookRotation(rawDirection);
    }
}