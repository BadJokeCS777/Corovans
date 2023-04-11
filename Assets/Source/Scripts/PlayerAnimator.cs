using UnityEngine;

internal class PlayerAnimator : MonoBehaviour
{
    private readonly int Speed = Animator.StringToHash(nameof(Speed));

    [SerializeField] private Animator _animator;

    internal void SetSpeed(float speed)
    {
        _animator.SetFloat(Speed, speed);
    }
}