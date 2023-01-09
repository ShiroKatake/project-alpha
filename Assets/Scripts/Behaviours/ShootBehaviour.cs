using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.TestTools;

namespace ShootSystem
{
    public class ShootBehaviour : MonoBehaviour
    {
        [SerializeField] private Ammo _ammoPrefab;
        [SerializeField] private Transform _firePoint;

        private AmmoMagazine _ammoMagazine;
        private AmmoLoadout _ammoLoadout;

        private AmmoType _loadedAmmoType;
        private ObjectPool<Ammo> _ammoPool;

        private void Awake()
        {
            _ammoMagazine = GetComponent<AmmoMagazineBehaviour>().AmmoMagazine;
            _ammoLoadout = GetComponent <AmmoLoadoutBehaviour>().AmmoLoadout;
            _ammoPool = new ObjectPool<Ammo>(CreateAmmo, OnGetAmmo, OnReleaseAmmo, OnDestroyAmmo, false, 5, 10);
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

            Debug.Log($"Getting {_loadedAmmoType.ammoCost}");
            _ammoPool.Get();
            _loadedAmmoType = null;
        }

        [ExcludeFromCoverage]
        #region Object Pool Functions
        private Ammo CreateAmmo()
		{
            _ammoPrefab.AmmoType = _loadedAmmoType;
            return Instantiate(_ammoPrefab);
        }

        private void OnGetAmmo(Ammo ammo)
		{
            ammo.OnAmmoDie((ammo) => _ammoPool.Release(ammo));
			ammo.AmmoType = _loadedAmmoType;
			ammo.transform.position = _firePoint.position;
            ammo.gameObject.SetActive(true);
        }

        private void OnReleaseAmmo(Ammo ammo)
		{
            ammo.gameObject.SetActive(false);
        }

        private void OnDestroyAmmo(Ammo ammo)
		{
            Destroy(ammo.gameObject);
        }
		#endregion
	}
}
