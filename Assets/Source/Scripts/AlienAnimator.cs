using UnityEngine;

internal class AlienAnimator : MonoBehaviour
{
    private readonly int Moving = Animator.StringToHash(nameof(Moving));
    private readonly int Shoot = Animator.StringToHash(nameof(Shoot));
    private readonly int Die = Animator.StringToHash(nameof(Die));
    private readonly int RightDamage = Animator.StringToHash(nameof(RightDamage));
    private readonly int Hit = Animator.StringToHash(nameof(Hit));

    [SerializeField] private Animator _animator;

    internal void SetMoving(bool isMoving)
    {
        _animator.SetBool(Moving, isMoving);
    }

    internal void EnableShoot()
    {
        _animator.SetTrigger(Shoot);
    }

    internal void TakeDamage()
    {
        _animator.SetBool(RightDamage, Random.value > 0.5f);
        _animator.SetTrigger(Hit);
    }

    internal void SetDie()
    {
        _animator.SetTrigger(Die);
    }
}