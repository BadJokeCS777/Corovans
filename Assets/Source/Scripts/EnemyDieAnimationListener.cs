using UnityEngine;

internal class EnemyDieAnimationListener : MonoBehaviour
{
    [SerializeField] private GameObject _gameObject;
    [SerializeField] private Enemy _alien;

    private void Die()
    {
        Destroy(_gameObject);
    }

    private void BreakPlant()
    { 
        _alien.BreakPlant();
    }
}
