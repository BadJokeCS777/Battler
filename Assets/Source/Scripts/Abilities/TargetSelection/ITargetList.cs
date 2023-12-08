public interface ITargetList
{
    IDamageTarget Target { get; }

    void Select();
    void ApplySelecting();
}