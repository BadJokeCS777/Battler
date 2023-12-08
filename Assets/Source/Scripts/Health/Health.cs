using System;

namespace HealthSystem
{
    internal class Health
    {
        public event Action ValueChanged;
        
        public Health(int maxValue)
        {
            Value = maxValue;
            MaxValue = maxValue;
        }

        internal int MaxValue { get; }
        internal int Value { get; private set; }

        internal void TakeDamage(int damage)
        {
            if (damage < 0)
                throw new ArgumentException("Damage must be greater zero");
            
            Value -= damage;

            if (Value < 0)
                Value = 0;
            
            ValueChanged?.Invoke();
        }
    }
}
