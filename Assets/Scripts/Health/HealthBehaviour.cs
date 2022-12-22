using UnityEngine;
using UnityEngine.Events;

namespace Health
{
    public class HealthBehaviour : MonoBehaviour
    {
        [SerializeField] private int maxHealth;
        [SerializeField] private UnityEvent<int> _onDamageTaken;
        [SerializeField] private UnityEvent<int> _onHealthGained;

        private Health _health;
        public Health Health { get => _health; }
        
        private void Start()
        {
            _health = new Health(maxHealth);
            _health.OnDamageTaken += OnDamageTaken;
            _health.OnHealthGained += OnHealthGained;
        }

        private void OnDamageTaken(int amount)
		{
            _onDamageTaken?.Invoke(amount);
        }

        private void OnHealthGained(int amount)
		{
            _onHealthGained?.Invoke(amount);
        }
    }
}
