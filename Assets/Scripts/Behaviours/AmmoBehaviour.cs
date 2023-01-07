using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShootSystem
{
    public class AmmoBehaviour : MonoBehaviour
    {
        [SerializeField] private Collider2D hitbox;
        [SerializeField] private int _ammoCost;

        private Ammo ammo;

        public Ammo Ammo { get => ammo; }

        // Start is called before the first frame update
        void Awake()
        {
            ammo = new Ammo(_ammoCost);
        }
    }
}
