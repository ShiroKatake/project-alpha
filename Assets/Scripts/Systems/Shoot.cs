using UnityEngine;

namespace ShootSystem
{
    public class Shoot
    {
        private struct LoadedBullet
        {
            public Bullet bullet;
            public int loadoutIndex;
        }

        private Ammo _ammo;
        private BulletLoadout _bulletLoadout;
        private LoadedBullet _loadedBullet;

        public Shoot(Ammo ammo, BulletLoadout bulletLoadout)
        {
            _ammo = ammo;
            _bulletLoadout = bulletLoadout;
        }

        public void LoadBullet(int loadoutIndex)
        {
            _loadedBullet.loadoutIndex = loadoutIndex;
            _loadedBullet.bullet = _bulletLoadout.GetBullet(loadoutIndex);
            Debug.Log("Loaded");
        }

        public void ShootBullet(int loadedBulletLoadoutIndex)
        {
            // You can press down Ability2 then Ability1, then release Ability2
            // and fire bullet1 without checking loadedBulletLoadoutIndex
            if (_loadedBullet.bullet == null || _loadedBullet.loadoutIndex != loadedBulletLoadoutIndex) return;

            if (!_ammo.TryConsumeAmmo(_loadedBullet.bullet.AmmoCost))
            {
                Debug.Log("Whiff");
                return;
            }

            Debug.Log($"Releasing {_loadedBullet.bullet.AmmoCost}");
            _loadedBullet.bullet = null;
        }
    }
}
