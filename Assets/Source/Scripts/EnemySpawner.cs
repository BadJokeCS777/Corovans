using System.Collections.Generic;
using System.Linq;
using UnityEngine;

internal class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy[] _enemyPrefabs;
    [SerializeField] private Transform[] _spawnPoints;

    internal void Spawn(IEnumerable<Patch> targets)
    {
        foreach (Transform point in _spawnPoints)
        {
            Patch target = targets.OrderBy(t => (t.transform.position - point.position).sqrMagnitude).First();
            Vector3 direction = (target.transform.position - point.position).normalized;
            Instantiate(
                    _enemyPrefabs[Random.Range(0, _enemyPrefabs.Length)], 
                    point.position, 
                    Quaternion.LookRotation(direction))
                .Init(target);
        }
    }
}