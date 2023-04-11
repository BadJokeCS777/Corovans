using DG.Tweening;
using UnityEngine;

public static class Extentions
{
    public static void EnableFade(this CanvasGroup canvasGroup, float duration)
    {
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
        canvasGroup.DOComplete(true);
        canvasGroup.DOFade(1f, duration);
    }

    public static void DisableFade(this CanvasGroup canvasGroup, float duration)
    {
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
        canvasGroup.DOComplete(true);
        canvasGroup.DOFade(0f, duration);
    }
}
