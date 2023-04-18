using System;
using Agava.IdleGame;
using Agava.IdleGame.Model;
using UnityEngine;

internal class Plant : MonoBehaviour
{
    [SerializeField] private float _growTime = 3f;
    [SerializeField] private float _startScale = 0f;
    [SerializeField] private float _targetScale = 1f;
    [SerializeField] private Transform _model;
    [SerializeField] private WaterConsumption _waterConsumption;
    [SerializeField] private ObjectProducerZone _producer;
    [SerializeField] private Trigger<StackPresenter> _trigger;
    
    private float _progress = 0f;

    public bool Ready => _progress >= 1f;
    public bool Enabled { get; private set; } = false;

    public event Action Taken;

    private void Awake()
    {
        _model.localScale = Vector3.one * _startScale;
        _trigger.Disable();
        _waterConsumption.Init();
    }

    internal void Tick()
    {
        if (_waterConsumption.Covered == false)
            return;

        _progress += Time.deltaTime / _growTime;
        _model.localScale = Mathf.Lerp(_startScale,_targetScale, _progress) * Vector3.one;
    }

    internal void Break()
    {
        _producer.GaveStackableObject -= OnGaveStackableObject;
        _trigger.Disable();
        
        Destroy(gameObject);
    }
    
    internal void EnableProducer()
    {
        Enabled = true;
        
        _trigger.Enable();
        _producer.GaveStackableObject += OnGaveStackableObject;
    }

    private void OnGaveStackableObject(StackableObject _)
    {
        Taken?.Invoke();
    }
}
