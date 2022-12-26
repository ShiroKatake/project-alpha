using System.Collections.Generic;
using UnityEngine;

namespace ShootSystem
{
    public class BulletLoadoutBehaviour : MonoBehaviour
    {
        [SerializeField] private Bullet _bullet1;
        [SerializeField] private Bullet _bullet2;
        [SerializeField] private Bullet _bullet3;

        private BulletLoadout _bulletLoadout;

        public BulletLoadout BulletLoadout { get => _bulletLoadout; }

        void Start()
        {
            _bulletLoadout = new BulletLoadout(new Dictionary<int, Bullet>());
            _bulletLoadout.AddBulletToLoadout(0, _bullet1);
            _bulletLoadout.AddBulletToLoadout(1, _bullet2);
            _bulletLoadout.AddBulletToLoadout(2, _bullet3);
        }
    }
}
