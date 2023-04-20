using UnityEngine;

internal class TurretAnimator : MonoBehaviour
{
    private readonly int Shoot = Animator.StringToHash(nameof(Shoot));
    
    [SerializeField] private Animator _animator;

    internal void Shooting()
    {
        _animator.SetTrigger(Shoot);
    }
}