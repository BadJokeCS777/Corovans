using Agava.IdleGame;
using Agava.IdleGame.Model;
using UnityEngine;

internal class WaterConsumption : MonoBehaviour
{
    [SerializeField] private StackPresenter _stack;
    [SerializeField] private Trigger<StackPresenter> _trigger;
    [SerializeField] private WaterDrop _waterDrop;

    public bool Covered { get; private set; } = false;

    internal void Init()
    {
        _stack.Added += OnAdded;
        _waterDrop.Show();
        _trigger.Enable();
    }

    private void OnAdded(StackableObject _)
    {
        _stack.Added -= OnAdded;
        _trigger.Disable();
        _waterDrop.Hide();

        Covered = true;
    }
}
