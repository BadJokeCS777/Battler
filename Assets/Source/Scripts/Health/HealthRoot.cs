using UnityEngine;

namespace HealthSystem
{
    public class HealthRoot : MonoBehaviour
    {
        [SerializeField, Min(0f)] private int _value = 10;
        [SerializeField] private HealthView _view;

        private Health _health;

        public int MaxValue => _health.MaxValue;
        public int Value => _health.Value;

        private void Awake()
        {
            _health = new Health(_value);
            _view.Init(_health);
        }

        public void TakeDamage(int damage)
        {
            _health.TakeDamage(damage);
        }
    }
}
