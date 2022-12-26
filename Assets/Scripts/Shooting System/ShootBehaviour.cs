using UnityEngine;
using System.Collections.Generic;

namespace ShootSystem
{
    public class ShootBehaviour : MonoBehaviour
    {
        private Ammo _ammo;
        private BulletLoadout _bulletLoadout;
        private Shoot _shoot;

        public Shoot Shoot { get => _shoot; }

        private void Start()
        {
            _ammo = GetComponent<AmmoBehaviour>().Ammo;
            _bulletLoadout = GetComponent <BulletLoadoutBehaviour>().BulletLoadout;
            _shoot = new Shoot(_ammo, _bulletLoadout);
        }
    }
}
