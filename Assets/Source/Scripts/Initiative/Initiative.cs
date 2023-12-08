public class Initiative
{
    private readonly float _speed;
    private readonly InitiativeView _view;

    public float Value { get; private set; }
    
    public Initiative(float speed, InitiativeView view)
    {
        _speed = speed;
        _view = view;
        
        Reset();
    }

    public void Update()
    {
        UpdateValue(Value + _speed);
    }

    public void Reset()
    {
        UpdateValue(0f);
    }

    private void UpdateValue(float newValue)
    {
        Value = newValue;
        _view.Render(newValue);
    }
}