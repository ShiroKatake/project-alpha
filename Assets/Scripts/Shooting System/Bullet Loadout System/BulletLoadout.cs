using UnityEngine;
using System.Collections.Generic;

namespace ShootSystem
{
    public struct BulletLoadout
    {
        private Dictionary<int, Bullet> _bulletLoadout;

        public BulletLoadout(Dictionary<int, Bullet> bulletLoadout)
        {
            _bulletLoadout = bulletLoadout;
        }

        public void AddBulletToLoadout(int loadoutIndex, Bullet bullet)
        {
            if (bullet == null) return;

            if (bullet.LoadoutIndex > -1)
            {
                RemoveBulletFromLoadout(bullet.LoadoutIndex);
            }

            // This will update the current index or create a new one if it doesn't exist
            bullet.LoadoutIndex = loadoutIndex;
            _bulletLoadout[loadoutIndex] = bullet;
        }

        public void RemoveBulletFromLoadout(int loadoutIndex)
        {
            if (!_bulletLoadout.ContainsKey(loadoutIndex))
            {
                return;
            }

            // Remove the key instead of setting value to null will make checking whether or not a bullet is assigned to it quicker
            _bulletLoadout[loadoutIndex].LoadoutIndex = -1;
            _bulletLoadout.Remove(loadoutIndex);
        }

        public Bullet GetBullet(int loadoutIndex)
        {
            if (!_bulletLoadout.ContainsKey(loadoutIndex)) return null;

            return _bulletLoadout[loadoutIndex];
        }
    }
}
