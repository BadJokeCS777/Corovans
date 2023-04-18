using UnityEngine;

internal class ShootSpeedChange : MonoBehaviour
{
    [SerializeField] private float _interval = 0.1f;
    [SerializeField] private GameObject[] _disables;

    private void Awake()
    {
        foreach (Scarecrow scarecrow in FindObjectsOfType<Scarecrow>())
        {
            scarecrow.SetShootInterval(_interval);
        }

        foreach (GameObject disable in _disables)
        {
            disable.SetActive(false);
        }
    }
}