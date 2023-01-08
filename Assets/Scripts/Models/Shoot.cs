using UnityEngine;

namespace ShootSystem
{
    public class Shoot
    {

        private AmmoMagazine _ammoMagazine;
        private AmmoLoadout _ammoLoadout;
        private AmmoType _loadedAmmoType;

        public Shoot(AmmoMagazine ammoMagazine, AmmoLoadout ammoLoadout)
        {
            _ammoMagazine = ammoMagazine;
            _ammoLoadout = ammoLoadout;
        }

        public void LoadAmmo(int loadoutIndex)
        {
            _loadedAmmoType = _ammoLoadout.GetAmmo(loadoutIndex);
            Debug.Log("Loaded");
        }

        public void ShootAmmo(int loadedAmmoLoadoutIndex)
        {
            // You can press down Ability2 then Ability1, then release Ability2
            // and fire ammo1 without checking loadedAmmoLoadoutIndex
            if (_loadedAmmoType == null || _loadedAmmoType.loadoutIndex != loadedAmmoLoadoutIndex) return;

            if (!_ammoMagazine.TryConsumeAmmo(_loadedAmmoType.ammoCost))
            {
                Debug.Log("Whiff");
                return;
            }

            Debug.Log($"Releasing {_loadedAmmoType.ammoCost}");
            _loadedAmmoType = null;
        }
    }
}
