using UnityEngine;
using TMPro;

public class BuyZoneView : MonoBehaviour
{
    private const string _coin = " <sprite=0>";

    [SerializeField] private TMP_Text _currentCost;
    [SerializeField] private SlicedFilledImage _filledImage;

    public void RenderProgress(int value, int maxValue)
    {
        _currentCost.text = value + _coin;

        if (_filledImage != null)
            _filledImage.fillAmount = 1 - (value / (float)maxValue);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
