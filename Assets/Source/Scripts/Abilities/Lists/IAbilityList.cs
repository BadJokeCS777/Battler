public interface IAbilityList
{
    bool AbilityFinished { get; }

    void Init();
    void StartSelecting();
    void ApplySelectedTo(IDamageTarget damageTarget);
}