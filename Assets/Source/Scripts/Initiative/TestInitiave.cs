using UnityEngine;

public class TestInitiave : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private InitiativeView _view;

    private Initiative _initiative;
    
    private void Start()
    {
        _initiative = new Initiative(_speed, _view);
    }

    private void Update()
    {
        _initiative.Update();
    }
}
