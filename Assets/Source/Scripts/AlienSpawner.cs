using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

internal class AlienSpawner : MonoBehaviour
{
    [SerializeField] private int _maxCount = 3;
    [SerializeField] private float _spawnTime = 10f;
    [SerializeField] private Alien _alienPrefab;
    [SerializeField] private Transform[] _spawnPoints;

    private float _time = 0f;
    private List<Alien> _list = new();

    private void Update()
    {
        if (_time < _spawnTime)
        {
            _time += Time.deltaTime;
            return;
        }

        var targets = FindObjectsOfType<Patch>().Where(t => t.HasPlant);

        if (targets.Count() > 0 && _list.Count < _maxCount)
        {
            Transform point = _spawnPoints[Random.Range(0, _spawnPoints.Length)];
            Patch target = targets.OrderBy(t => (t.transform.position - point.position).sqrMagnitude).First();
            Vector3 direction = (target.transform.position - point.position).normalized;
            Alien alien = Instantiate(_alienPrefab, point.position, Quaternion.LookRotation(direction));

            alien.Died += OnDied;
            alien.Init(target);

            _list.Add(alien);
            _time = 0f;
        }
    }

    private void OnDied(Alien alien)
    {
        alien.Died -= OnDied;
        _list.Remove(alien);
    }
}
