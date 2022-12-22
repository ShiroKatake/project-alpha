using System;
using System.Collections;
using System.Collections.Generic;

public class Ammo
{
    private float _ammoCapacity;
    private float _currentAmmoCount;
    
    private float _currentAmmoCharge;
    private float _ammoChargeSpeed;

    private float _ammoRefillSpeed;
    private float _ammoRefillDelay;

    private event Action _onCurrentAmmoCountUpdate;
    private event Action _onAmmoCapcityUpdate;

    private bool IsShootable { get; set; }
    private bool _isRefillable;
    private bool _canRefill;

    public void ChargeAmmo(float deltaTime)
	{
        if (!IsShootable) return;
        _currentAmmoCharge += _ammoChargeSpeed * deltaTime;
    }
     
    public void ConsumeAmmo(float bulletCost)
	{
        _currentAmmoCount -= bulletCost;
    }

    public void RefillAmmo(float deltaTime)
    {
        if (_currentAmmoCount < _ammoCapacity)
		{
            _currentAmmoCount += _ammoRefillSpeed * deltaTime;
        }
        else if (_currentAmmoCount > _ammoCapacity)
		{
            _currentAmmoCount = _ammoCapacity;
        }
    }

    public void AddAmmoCapacity(float increaseAmount)
    {
        _ammoCapacity += increaseAmount;
        _onAmmoCapcityUpdate?.Invoke();
    }
}
