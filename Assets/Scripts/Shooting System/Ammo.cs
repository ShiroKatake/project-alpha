using System;
using UnityEngine;

public class Ammo
{
    private int _ammoCapacity;
    private float _currentAmmoCount;
    
    private float _currentAmmoCharge;

    public event Action OnAmmoCapcityUpdate;


    public float CurrentAmmoCharge { get => _currentAmmoCharge; }
    public float CurrentAmmoCount { get => _currentAmmoCount; }

    public Ammo(int ammoCapacity)
	{
        _ammoCapacity = ammoCapacity;
        _currentAmmoCount = 0;
    }

    public void ChargeAmmo(float deltaTime)
	{
        _currentAmmoCharge = Mathf.Min(_ammoCapacity, _currentAmmoCharge + deltaTime);
    }
    
    public bool TryConsumeAmmo(int amount)
	{
        if (amount > _currentAmmoCount) return false;

        _currentAmmoCount -= amount;
        _currentAmmoCharge = 0f;
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
