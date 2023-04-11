using Agava.IdleGame;
using Agava.IdleGame.Model;
using UnityEngine;

public abstract class TimerTriggerZone<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] private float _waitTime = 1f;
    [SerializeField] private Trigger<T> _trigger;

    private Timer _timer = new Timer();

    private void OnEnable()
    {
        _trigger.Enter += OnPlayerEnter;
        _trigger.Exit += OnPlayerExit;
        _timer.Completed += OnTimerComplete;

        Enabled();
    }

    private void OnDisable()
    {
        _trigger.Enter -= OnPlayerEnter;
        _trigger.Exit -= OnPlayerExit;
        _timer.Completed -= OnTimerComplete;

        Disabled();
    }

    private void Update()
    {
        _timer.Tick(Time.deltaTime);
    }

    private void OnPlayerEnter(T player)
    {
        _timer.Start(_waitTime);
        OnEnter();
    }

    private void OnPlayerExit(T player)
    {
        _timer.Stop();
        OnExit();
    }

    protected virtual void Enabled() { }
    protected virtual void Disabled() { }
    protected virtual void OnEnter() { }
    protected virtual void OnExit() { }
    protected abstract void OnTimerComplete();
}
