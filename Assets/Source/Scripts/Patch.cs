using Agava.IdleGame;
using Agava.IdleGame.Model;
using UnityEngine;

internal class Patch : MonoBehaviour
{
    [SerializeField] private GameObject _model;
    [SerializeField] private StackPresenter _stack;
    [SerializeField] private Trigger<StackPresenter> _trigger;
    [SerializeField] private ParticleSystem _breakEffect;

    private Plant _plant;

    public bool HasPlant => _plant != null;
    
    private void OnEnable()
    {
        _stack.Added += OnAdded;
    }

    private void OnDisable()
    {
        _stack.Added -= OnAdded;
    }

    private void Update()
    {
        if (_plant == null)
            return;
        
        if (_plant.Ready == false)
        {
            _plant.Tick();
        }
        else if (_plant.Enabled == false)
        {
            _plant.EnableProducer();
            _plant.Taken += OnPlantTaken;
        }
    }

    private void OnPlantTaken()
    {
        Break(false);
    }

    internal void Break(bool playEffect)
    {
        _plant.Break();
        _plant = null;
        
        _model.SetActive(true);
        _stack.Clear();
        _trigger.Enable();

        if (playEffect)
            _breakEffect.Play();
    }
    
    private void OnAdded(StackableObject rawSeed)
    {
        _model.SetActive(false);
        _trigger.Disable();
        _plant = Instantiate(((Seed) rawSeed).Plant, transform.position, Quaternion.identity, transform);
    }
}