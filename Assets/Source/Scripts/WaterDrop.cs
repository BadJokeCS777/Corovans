using DG.Tweening;
using UnityEngine;

internal class WaterDrop : MonoBehaviour
{
    [SerializeField] private float _pulseDuration;
    [SerializeField, Min(1f)] private float _pulseScale = 1.25f;

    private Tween _pulsing;

    internal void Show()
    {
        gameObject.SetActive(true);
        transform.localScale = Vector3.one;
        _pulsing = transform
            .DOScale(_pulseScale, _pulseDuration * 0.5f)
            .SetLoops(-1, LoopType.Yoyo);
    }

    internal void Hide()
    {
        gameObject.SetActive(false);

        _pulsing.Kill();
    }
}