using UnityEngine;

namespace ShootSystem
{
    public class Ammo : MonoBehaviour
    {
        [SerializeField] private AmmoType _ammoType;

        public AmmoType AmmoType => _ammoType;

		private void OnTriggerEnter2D(Collider2D collision)
		{
			// Bring back to pool
		}
	}
}