using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
internal class Scarecrow : MonoBehaviour
{
    [SerializeField] private float _shootInterval;
    [SerializeField, Range(0f, 1f)] private float _rotationSpeed;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private ScarecrowAnimator _animator;
    [SerializeField] private Bullet _bulletPrefab;

    private float _time = 0f;
    private List<Alien> _aliens = new();

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Alien alien))
            if (alien.Alive)
                _aliens.Add(alien);
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Alien alien))
            _aliens.Remove(alien);
    }

    private void Update()
    {
        Alien nearest = null;
        IEnumerable<Alien> aliens = _aliens.Where(a => a.Alive);

        if (aliens.Any())
        {
            nearest = Nearest(aliens);
            Vector3 direction = (nearest.transform.position - transform.position).normalized;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), _rotationSpeed);
        }

        if (_time >= _shootInterval)
        {
            _time = 0f;

            if (nearest == null)
                return;

            _animator.Shooting();
            Instantiate(_bulletPrefab, _shootPoint.position, Quaternion.identity)
                .Init(nearest);

            return;
        }

        _time += Time.deltaTime;
    }

    internal void SetShootInterval(float interval)
    {
        _shootInterval = interval;
    }
    
    private Alien Nearest(IEnumerable<Alien> aliens)
    {
        return aliens.OrderBy(a => (a.transform.position - transform.position).sqrMagnitude).First();
    }
}