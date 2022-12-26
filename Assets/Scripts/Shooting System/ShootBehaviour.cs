using UnityEngine;
using System.Collections.Generic;

public class ShootBehaviour : MonoBehaviour
{
    [SerializeField] private int _ammoCapacity;
    [SerializeField] private float _ammoChargeSpeed;
    [SerializeField] private float _ammoRefillSpeed;

    [Header("Bullet Loadout")]
    [SerializeField] private Bullet _bullet1;
    [SerializeField] private Bullet _bullet2;
    [SerializeField] private Bullet _bullet3;

    private Ammo _ammo;
    private BulletLoadout _bulletLoadout;
    private Bullet _loadedBullet;

    private void Start()
    {
        _ammo = new Ammo(_ammoCapacity);
		_bulletLoadout = new BulletLoadout(new Dictionary<int, Bullet>());

        // Test code
		_bulletLoadout.AddBulletToLoadout(0, _bullet1);
        _bulletLoadout.AddBulletToLoadout(1, _bullet2);
        _bulletLoadout.AddBulletToLoadout(2, _bullet3);
    }

	private void Update()
	{
        _ammo.RefillAmmo(_ammoRefillSpeed * Time.deltaTime);
    }

	public void LoadBullet(int loadoutIndex)
    {
        _loadedBullet = _bulletLoadout.GetBullet(loadoutIndex);
        Debug.Log("Loaded");
    }

    public void ShootBullet()
    {
        if (_loadedBullet == null) return;

        if (!_ammo.TryConsumeAmmo(_loadedBullet.AmmoCost))
		{
            Debug.Log("Whiff");
            return;
        }

        Debug.Log($"Releasing {_loadedBullet.AmmoCost}");
    }
}
