using UnityEngine;

internal class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Alien _target;

    private void Update()
    {
        if (_target == null)
            return;

        Vector3 targetPosition = _target.transform.position;
        targetPosition.y = transform.position.y;

        if ((targetPosition - transform.position).magnitude < 0.35f)
        {
            _target.TakeDamage(1);
            Destroy(gameObject);
            return;
        }

        Vector3 direction = (targetPosition - transform.position).normalized;
        transform.forward = direction;
        transform.Translate(_speed * Time.deltaTime * direction, Space.World);
    }

    internal void Init(Alien target)
    {
        _target = target;
    }
}