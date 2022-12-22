using System;
using UnityEngine;

namespace Health
{
	public class Health
	{
		private int _maxHealth;
		private int _currentHealth;

		public int MaxHealth { get => _maxHealth; }
		public int CurrentHealth { get => _currentHealth; }

		public event Action<int> OnDamageTaken;
		public event Action<int> OnHealthGained;
		public event Action OnDeath;

		public Health(int maxHealth)
		{
			_maxHealth = maxHealth;
			_currentHealth = maxHealth;
		}

		public void TakeDamage(int amount)
		{
			if (_currentHealth <= 0) { return; }

			_currentHealth = Mathf.Max(0, _currentHealth - amount);
			OnDamageTaken?.Invoke(_currentHealth);

			if (_currentHealth <= 0)
			{
				OnDeath?.Invoke();
			}
		}

		public void Heal(int amount)
		{
			_currentHealth = Mathf.Min(_maxHealth, _currentHealth + amount);
			OnHealthGained?.Invoke(_currentHealth);
		}

		public void IncreaseMaxHealth(int amount)
		{
			_maxHealth += amount;
		}
	}

}