using System.Linq;
using UnityEngine;

internal class SpawnCondition : MonoBehaviour
{
    [SerializeField] private KeyCode _spawnKey = KeyCode.Alpha0;
    [SerializeField] private EnemySpawner _spawner;

    private void Update()
    {
        if (Input.GetKeyDown(_spawnKey) == false)
            return;
        
        enabled = false;
        Spawn();
    }

    private void Spawn()
    {
        _spawner.Spawn(FindObjectsOfType<Patch>().Where(p => p.HasPlant));
    }
}