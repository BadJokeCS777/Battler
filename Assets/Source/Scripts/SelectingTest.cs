using UnityEngine;

public class SelectingTest : MonoBehaviour
{
    [SerializeField] private Character _player;
    [SerializeField] private Character _enemy;
    [SerializeField] private AbilityTarget[] _targets;

    private void Start()
    {
        _player.Init();
        _enemy.Init();
        
        PlayerTargetList playerTargetList = new(_targets);
        _player.SetTargetList(playerTargetList);
        _player.StartTurn();
    }
}