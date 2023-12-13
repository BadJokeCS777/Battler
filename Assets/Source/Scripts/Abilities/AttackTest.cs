using System.Collections;
using UnityEngine;

public class AttackTest : MonoBehaviour
{
    [SerializeField] private MeleeAttack _attack;
    [SerializeField] private AbilityTarget[] _targets;
    
    private IEnumerator Start()
    {
        PlayerTargetList targetList = new(_targets);
        targetList.Select();

        yield return new WaitWhile(() => targetList.Target == null);
        
        _attack.Apply(targetList.Target);
    }
}