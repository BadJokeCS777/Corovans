using UnityEngine;

internal class AlienDieAnimationListener : MonoBehaviour
{
    [SerializeField] private GameObject _gameObject;
    [SerializeField] private Alien _alien;

    private void Die()
    {
        Destroy(_gameObject);
    }

    private void BreakPlant()
    { 
        _alien.BreakPlant();
    }
}
