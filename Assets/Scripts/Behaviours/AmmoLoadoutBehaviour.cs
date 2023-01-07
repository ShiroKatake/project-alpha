using System.Collections.Generic;
using UnityEngine;

namespace ShootSystem
{
    public class AmmoLoadoutBehaviour : MonoBehaviour
    {
        [SerializeField] private AmmoBehaviour _ammo1;
        [SerializeField] private AmmoBehaviour _ammo2;
        [SerializeField] private AmmoBehaviour _ammo3;

        private AmmoLoadout _ammoLoadout;

        public AmmoLoadout AmmoLoadout { get => _ammoLoadout; }

        void Awake()
        {
            _ammoLoadout = new AmmoLoadout(_ammo1.Ammo, _ammo2.Ammo, _ammo3.Ammo);
        }
    }
}
