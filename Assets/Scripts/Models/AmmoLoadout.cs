using System.Collections.Generic;

namespace ShootSystem
{
    public class AmmoLoadout
    {
        private Dictionary<int, Ammo> _ammoLoadout = new Dictionary<int, Ammo>();

        public AmmoLoadout()
        {
            _ammoLoadout = new Dictionary<int, Ammo>();
        }

        public AmmoLoadout(params Ammo[] ammo)
        {
            _ammoLoadout = new Dictionary<int, Ammo>();
			for (int i = 0; i < ammo.Length; i++)
			{
                AddAmmoToLoadout(i, ammo[i]);
			}
        }

        public void AddAmmoToLoadout(int loadoutIndex, Ammo ammo)
        {
            if (ammo == null) return;

            if (ammo.LoadoutIndex > -1)
            {
                RemoveAmmoFromLoadout(ammo.LoadoutIndex);
            }

            // This will update the current index or create a new one if it doesn't exist
            ammo.LoadoutIndex = loadoutIndex;
            _ammoLoadout[loadoutIndex] = ammo;
        }

        public void RemoveAmmoFromLoadout(int loadoutIndex)
        {
            if (!_ammoLoadout.ContainsKey(loadoutIndex))
            {
                return;
            }

            // Remove the key instead of setting value to null will make checking whether or not a ammo is assigned to it quicker
            _ammoLoadout[loadoutIndex].LoadoutIndex = -1;
            _ammoLoadout.Remove(loadoutIndex);
        }

        public Ammo GetAmmo(int loadoutIndex)
        {
            if (!_ammoLoadout.ContainsKey(loadoutIndex)) return null;

            return _ammoLoadout[loadoutIndex];
        }
    }
}
