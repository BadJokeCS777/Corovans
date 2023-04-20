﻿using UnityEngine;

internal class ShootSpeedChange : MonoBehaviour
{
    [SerializeField] private float _interval = 0.1f;
    [SerializeField] private GameObject[] _disables;

    private void Awake()
    {
        foreach (Turret scarecrow in FindObjectsOfType<Turret>())
        {
            scarecrow.SetShootInterval(_interval);
        }

        foreach (GameObject disable in _disables)
        {
            disable.SetActive(false);
        }
    }
}