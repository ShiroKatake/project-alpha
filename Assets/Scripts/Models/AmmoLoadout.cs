using System.Collections.Generic;

namespace ShootSystem
{
    public class AmmoLoadout
    {
        private Dictionary<int, AmmoType> _ammoLoadout = new Dictionary<int, AmmoType>();

        public AmmoLoadout()
        {
            _ammoLoadout = new Dictionary<int, AmmoType>();
        }

        public AmmoLoadout(params AmmoType[] ammoType)
        {
            _ammoLoadout = new Dictionary<int, AmmoType>();
			for (int i = 0; i < ammoType.Length; i++)
			{
                AddAmmoToLoadout(i, ammoType[i]);
			}
        }

        public void AddAmmoToLoadout(int loadoutIndex, AmmoType ammoType)
        {
            if (ammoType == null) return;

            if (ammoType.loadoutIndex > -1)
            {
                RemoveAmmoFromLoadout(ammoType.loadoutIndex);
            }

            // This will update the current index or create a new one if it doesn't exist
            ammoType.loadoutIndex = loadoutIndex;
            _ammoLoadout[loadoutIndex] = ammoType;
        }

        public void RemoveAmmoFromLoadout(int loadoutIndex)
        {
            if (!_ammoLoadout.ContainsKey(loadoutIndex))
            {
                return;
            }

            // Remove the key instead of setting value to null will make checking whether or not a ammoType is assigned to it quicker
            _ammoLoadout[loadoutIndex].loadoutIndex = -1;
            _ammoLoadout.Remove(loadoutIndex);
        }

        public AmmoType GetAmmo(int loadoutIndex)
        {
            if (!_ammoLoadout.ContainsKey(loadoutIndex)) return null;

            return _ammoLoadout[loadoutIndex];
        }
    }
}
