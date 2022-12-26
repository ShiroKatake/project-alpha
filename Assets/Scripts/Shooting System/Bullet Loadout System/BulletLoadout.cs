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

            if (_bulletLoadout.ContainsKey(loadoutIndex) && _bulletLoadout[loadoutIndex] == bullet)
            {
                Debug.Log($"That bullet is already assigned to slot ${loadoutIndex + 1}");
                return;
            }

            // This will update the current index or create a new one if it doesn't exist
            _bulletLoadout[loadoutIndex] = bullet;
        }

        public void RemoveBulletFromLoadout(int loadoutIndex)
        {
            if (!_bulletLoadout.ContainsKey(loadoutIndex))
            {
                Debug.Log($"There is no bullet with that cost to remove");
                return;
            }

            // Remove the key instead of setting value to null will make checking whether or not a bullet is assigned to it quicker
            _bulletLoadout.Remove(loadoutIndex);
        }

        public Bullet GetBullet(int loadoutIndex)
        {
            if (!_bulletLoadout.ContainsKey(loadoutIndex)) return null;

            return _bulletLoadout[loadoutIndex];
        }
    }
}
