using UnityEngine;

public class TriggerView : MonoBehaviour
{
    [SerializeField] private GameObject _lock;

    public void RenderEnable()
    {
        _lock.SetActive(true);
    }
    
    public void RenderDisable()
    {
        _lock.SetActive(false);
    }
}
