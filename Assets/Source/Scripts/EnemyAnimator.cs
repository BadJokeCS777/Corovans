using UnityEngine;

internal class EnemyAnimator : MonoBehaviour
{
    private readonly int Moving = Animator.StringToHash(nameof(Moving));
    private readonly int Punch = Animator.StringToHash(nameof(Punch));
    private readonly int HitTaken = Animator.StringToHash(nameof(HitTaken));
    private readonly int Dead = Animator.StringToHash(nameof(Dead));

    [SerializeField] private Animator _animator;

    internal void SetMoving(bool isMoving)
    {
        _animator.SetBool(Moving, isMoving);
    }

    internal void EnableShoot()
    {
        _animator.SetTrigger(Punch);
    }

    internal void TakeDamage()
    {
        _animator.SetTrigger(HitTaken);
    }

    internal void SetDie()
    {
        _animator.SetBool(Dead, true);
    }
}