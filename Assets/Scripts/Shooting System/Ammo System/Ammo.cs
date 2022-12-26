using System;
using UnityEngine;

namespace ShootSystem
{
    public class Ammo
    {
        private int _ammoCapacity;
        private float _currentAmmoCount;

        public event Action OnAmmoCapcityUpdate;

        public float CurrentAmmoCount { get => _currentAmmoCount; }

        public Ammo(int ammoCapacity)
        {
            _ammoCapacity = ammoCapacity;
            _currentAmmoCount = ammoCapacity;
        }

        public bool TryConsumeAmmo(int amount)
        {
            if (amount > _currentAmmoCount) return false;

            _currentAmmoCount -= amount;
            return true;
        }

        public void RefillAmmo(float deltaTime)
        {
            _currentAmmoCount = Mathf.Min(_ammoCapacity, _currentAmmoCount + deltaTime);
        }

        public void AddAmmoCapacity(int increaseAmount)
        {
            _ammoCapacity += increaseAmount;
            OnAmmoCapcityUpdate?.Invoke();
        }
    }
}
