using System.Collections;
using UnityEngine;

public class Character : MonoBehaviour, IDamageTarget
{
    [SerializeField] private AbilityTarget _target;
    [SerializeField] private Ability[] _abilities;
    [SerializeField] private AbilityListView _abilityListView;

    private IAbilityList _abilityList;
    private ITargetList _targetList;

    public bool AbilityInUse { get; private set; } = false;
    public bool Dead { get; private set; }
    public Vector3 Position => transform.position;

    public void Init()
    {
        _target.Init(this);
        _abilityList = new PlayerAbilityList(_abilities, _abilityListView);
        _abilityList.Init();
    }

    public void SetTargetList(ITargetList targetList)
    {
        _targetList = targetList;
    }

    public void StartTurn()
    {
        StartCoroutine(Turning());
    }

    public void TakeDamage(int value)
    {
        Debug.Log("Took damage: " + value);
    }

    private IEnumerator Turning()
    {
        AbilityInUse = true;
        _abilityList.StartSelecting();
        _targetList.Select();

        yield return new WaitUntil(() => _targetList.Target != null);

        _abilityList.ApplySelectedTo(_targetList.Target);
        _targetList.Reset();
        
        yield return new WaitUntil(() => _abilityList.AbilityFinished);
        
        //TODO: _initiative.Reset();
        AbilityInUse = false;
    }
}