using UnityEngine;
using UnityEngine.AI;

internal class Alien : MonoBehaviour
{
    [SerializeField, Min(0f)] private float _offset = 0.75f;
    [SerializeField, Min(0f)] private float _shootInterval = 0.75f;
    [SerializeField, Min(0f)] private float _speed = 7f;
    [SerializeField, Min(0f)] private int _health = 5;
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private Transform _transform;
    [SerializeField] private AlienAnimator _animator;

    private float _interval = 0f;
    private Patch _target;

    public bool Alive => _health > 0;

    private void Update()
    {
        if (_target == null || Alive == false)
        {
            _animator.SetMoving(false);
            return;
        }

        if ((_target.transform.position - transform.position).magnitude > _offset)
        {
            Vector3 direction = (_target.transform.position - transform.position).normalized;
            Vector3 offset = _speed * Time.deltaTime * direction;

            _agent.Move(offset);
            _transform.forward = direction;
            _animator.SetMoving(true);
            return;
        }

        _animator.SetMoving(false);
        _interval += Time.deltaTime;

        if (_interval > _shootInterval)
        {
            _interval = 0f;
            _animator.EnableShoot();
        }
    }

    internal void Init(Patch target)
    {
        _target = target;
    }

    internal void TakeDamage(int amount)
    {
        _health -= amount;
        _animator.TakeDamage();

        if (_health <= 0)
        {
            _agent.enabled = false;
            _animator.SetDie();
        }
    }

    internal void BreakPlant()
    {
        if(_target != null)
            if (_target.HasPlant)
                _target.Break();

        _target = null;
    }
}
