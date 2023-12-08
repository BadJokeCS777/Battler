using UnityEngine;

public class TargetSelectingTest : MonoBehaviour
{
    [SerializeField] private AbilityTarget[] _targets;

    private PlayerTargetList _targetList;
    
    private void Start()
    {
        _targetList = new PlayerTargetList(_targets);
        _targetList.Select();
    }

    private void Update()
    {
        if (_targetList.Target == null)
            return;
        
        Debug.Log(_targetList.Target);
        _targetList.ApplySelecting();
        enabled = false;
    }
}