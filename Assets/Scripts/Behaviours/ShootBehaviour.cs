using UnityEngine;

namespace ShootSystem
{
    public class ShootBehaviour : MonoBehaviour
    {
        private AmmoMagazine _ammoMagazine;
        private AmmoLoadout _ammoLoadout;
        private Shoot _shoot;

        public Shoot Shoot { get => _shoot; }

        private void Awake()
        {
            _ammoMagazine = GetComponent<AmmoMagazineBehaviour>().AmmoMagazine;
            _ammoLoadout = GetComponent <AmmoLoadoutBehaviour>().AmmoLoadout;
            _shoot = new Shoot(_ammoMagazine, _ammoLoadout);
        }
    }
}
