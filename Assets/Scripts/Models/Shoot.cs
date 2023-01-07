using UnityEngine;

namespace ShootSystem
{
    public class Shoot
    {
        private struct LoadedAmmo
        {
            public Ammo ammo;
            public int loadoutIndex;
        }

        private AmmoMagazine _ammoMagazine;
        private AmmoLoadout _ammoLoadout;
        private LoadedAmmo _loadedAmmo;

        public Shoot(AmmoMagazine ammoMagazine, AmmoLoadout ammoLoadout)
        {
            _ammoMagazine = ammoMagazine;
            _ammoLoadout = ammoLoadout;
        }

        public void LoadAmmo(int loadoutIndex)
        {
            _loadedAmmo.loadoutIndex = loadoutIndex;
            _loadedAmmo.ammo = _ammoLoadout.GetAmmo(loadoutIndex);
            Debug.Log("Loaded");
        }

        public void ShootAmmo(int loadedAmmoLoadoutIndex)
        {
            // You can press down Ability2 then Ability1, then release Ability2
            // and fire ammo1 without checking loadedAmmoLoadoutIndex
            if (_loadedAmmo.ammo == null || _loadedAmmo.loadoutIndex != loadedAmmoLoadoutIndex) return;

            if (!_ammoMagazine.TryConsumeAmmo(_loadedAmmo.ammo.AmmoCost))
            {
                Debug.Log("Whiff");
                return;
            }

            Debug.Log($"Releasing {_loadedAmmo.ammo.AmmoCost}");
            _loadedAmmo.ammo = null;
        }
    }
}
